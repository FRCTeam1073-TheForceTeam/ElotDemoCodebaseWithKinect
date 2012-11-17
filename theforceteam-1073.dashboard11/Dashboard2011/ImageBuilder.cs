using System;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Collections;


namespace Dashboard2011
{
    public class ImageBuilder
    {
        Queue imgq;
        Queue numq;
        string imgdirname;
        public ImageBuilder(Queue imgq,Queue numq,string imgdirname)
        {
            this.imgq = imgq;
            this.numq = numq;
            this.imgdirname = imgdirname;
        }

        MemoryStream imagestream = new MemoryStream(); // the memory stream to which image data bytes are added
        int imgnum = 0;
        int errors = 0;
        bool needsNext = true; // means program has lost start of image
        public void addBytes(byte[] bytes, int num)
        {
            if (needsNext && !beginning(bytes)) { return; } // if it gets lost, it will wait for a packet that begins at the beginning of an image.
            needsNext = false;
            imagestream.Write(bytes, 0, num);   // write bytes

            redo:
            byte[] buffer = imagestream.GetBuffer();  //get buffer

            // ***** just added next line; don't lose beginning just because not enough bytes found
            if (imagestream.Length < 4) { return; }
            if (!beginning(buffer)) // checks for 0x 01 00 00 00 header that represents beginning of new image
            {
                needsNext = true;
                imagestream = new MemoryStream();
                errors++;
                return;
            }
            if (imagestream.Length >= 8)
            {
                int len = 0x1000000 * buffer[4] + 0x10000 * buffer[5] + 0x100 * buffer[6] + buffer[7]; // second group of 4 bytes is size of image
                if (imagestream.Length >= len + 8)// enough to create new image
                {
                    System.Drawing.Bitmap b = null;
                    try
                    {
                        // create bitmap from 8 with len bytes here
                        b = new System.Drawing.Bitmap(new MemoryStream(buffer, 8, len)); // creates bitmap from bytes
                        BinaryWriter bw = new BinaryWriter(new FileStream(imgdirname + "/" + imgnum.ToString() + ".jpg", FileMode.Create));
                        GlobalStuff.Write('I', BitConverter.GetBytes(imgnum));
                        bw.Write(buffer, 8, len); // records image to file
                        bw.Close();
                    }
                    catch (Exception)
                    {
                        imagestream = new MemoryStream(); // start of image lost
                        errors++;
                        needsNext = true;
                        return;
                    }

                    if (b != null)
                    {
                        imgq.Enqueue(b); // add image to queue
                        numq.Enqueue(imgnum);

                        imgnum++;
                    }
                    // create bitmap
                    int numremaining = (int)(imagestream.Length) - (len + 8);
                    byte[] remaining = new byte[numremaining];

                    // remove the used bytes from the stream.  Hopefully, the next bytes are the beginning of the next image
                    imagestream.Position = len + 8;
                    imagestream.Read(remaining, 0, numremaining);
                    imagestream = new MemoryStream();
                    imagestream.Write(remaining, 0, remaining.Length);

                    goto redo; // tries to create another image from remaining bytes.
                }
            }
        }

        /// <summary>
        /// Checks if a byte array contains the 0x 01 00 00 00 header that indicates the beginning of a new image.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool beginning(byte[] b)
        {
            //if (b.Length < 4) { return false; } ***** just deleted
            return (b[0] == 1 && b[1] == 0 && b[2] == 0 && b[3] == 0);
        }
    }
}