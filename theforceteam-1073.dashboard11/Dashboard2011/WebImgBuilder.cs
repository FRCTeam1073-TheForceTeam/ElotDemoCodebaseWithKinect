using System;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Collections;


namespace Dashboard2011
{
    public class WebImgBuilder
    {
        Queue imgq;
        string imgdirname;
        char ident;
        public WebImgBuilder(Queue imgq, string imgdirname, char ident)
        {
            this.imgq = imgq;
            this.imgdirname = imgdirname;
            this.ident = ident;
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

            if (imagestream.Length < header.Length) { return; }
            if (!beginning(buffer))
            {
                needsNext = true;
                imagestream = new MemoryStream();
                errors++;
                return;
            }
            if (imagestream.Length >= header.Length + 15)
            {
                int len = 0;
                // get length
                int i = 0;
                for (i = header.Length; ; i++)
                {
                    if (buffer[i] >= 0x30 && buffer[i] <= 0x39) { len *= 10; len += buffer[i] - 0x30; }
                    else break; // not ASCII #'s anymore
                }
                if (imagestream.Length >= len + i + secondheaderlen+followersize)// enough to create new image; the 4 corresponds to DADA sequence
                {
                    System.Drawing.Bitmap b = null;
                    try
                    {
                        // create bitmap from 8 with len bytes here
                        b = new System.Drawing.Bitmap(new MemoryStream(buffer, i+secondheaderlen, len)); // creates bitmap from bytes

                        /**/
                        BinaryWriter bw = new BinaryWriter(new FileStream(imgdirname + "/" + imgnum.ToString() + ident+".jpg", FileMode.Create)); // ident indicates which camera
                        bw.Write(buffer, i+secondheaderlen, len); // records image to file
                        bw.Close();
                        /**/

                        GlobalStuff.Write(ident, BitConverter.GetBytes(imgnum));

                        imgq.Enqueue(b); // add image to queue
                        imgnum++;
                    }
                    catch (Exception)
                    {
                        imagestream = new MemoryStream(); // start of image lost
                        errors++;
                        needsNext = true;
                        return;
                    }

                    // create bitmap
                    int numremaining = (int)(imagestream.Length) - (len + i+secondheaderlen+followersize);
                    byte[] remaining = new byte[numremaining];

                    // remove the used bytes from the stream.  Hopefully, the next bytes are the beginning of the next image
                    imagestream.Position = len + i+secondheaderlen+followersize;

                    imagestream.Read(remaining, 0, numremaining);
                    imagestream = new MemoryStream();
                    imagestream.Write(remaining, 0, remaining.Length);

                    goto redo; // tries to create another image from remaining bytes.
                }
            }
        }

        byte[] header = {
                            0x2d, 0x2d, 0x6d, 0x79, 0x62, 0x6f, 0x75, 0x6e, 
                            0x64, 0x61, 0x72, 0x79, 0x0d, 0x0a, 0x43, 0x6f, 
                            0x6e, 0x74, 0x65, 0x6e, 0x74, 0x2d, 0x54, 0x79, 
                            0x70, 0x65, 0x3a, 0x20, 0x69, 0x6d, 0x61, 0x67, 
                            0x65, 0x2f, 0x6a, 0x70, 0x65, 0x67, 0x0d, 0x0a, 
                            0x43, 0x6f, 0x6e, 0x74, 0x65, 0x6e, 0x74, 0x2d, 
                            0x4c, 0x65, 0x6e, 0x67, 0x74, 0x68, 0x3a, 0x20
                        };

        const int secondheaderlen = 4; // DADA sequence
        const int followersize = 2; // two bytes of a gap for some reason between images. ?????
        /// <summary>
        /// Checks if a byte array contains the header that indicates the beginning of a new image.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool beginning(byte[] b)
        {
            //if (b.Length < header.Length) { return false; }

            for (int i = 0; i < 4; i++)
            {
                if (b[i] != header[i]) { return false; }
            }
            return true;
        }
    }
}