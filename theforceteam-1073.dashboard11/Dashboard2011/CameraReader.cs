using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Threading;
using System.Net;
using System.IO;
namespace Dashboard2011
{
    public class CameraReader
    {
        string url;
        string username;
        string password;
        char ident;
        Queue queue;
        WebImgBuilder builder;
        public CameraReader(string url, string username, string password, Queue queue, string dir, char ident)
        {
            this.url = url;
            this.username = username;
            this.password = password;
            this.queue = queue;
            this.ident = ident;

            builder = new WebImgBuilder(queue,dir,ident);

            thread = new Thread(new ThreadStart(run));
            GlobalStuff.receiverthreads.Add(thread);
            thread.Start();
        }

        Thread thread;

        private const int buffsize = 0x8000;
        int imgnum = 0;
        private const string imgpath = "C:/2011matches/RayTraceDash{0}.jpg";
        private void run()
        {
            if (GlobalStuff.Sim && ident == 'W')
            {
                while (true)
                {
                    Thread.Sleep(40);

                    int i = imgnum + 1;
                    for (; File.Exists(string.Format(imgpath, i)); i++) { }
                    i--;

                    if (i == imgnum)
                    {
                        continue;
                    }

                    Bitmap b = null;
                    try
                    {
                        b = new Bitmap(string.Format(imgpath, i));
                    }
                    catch (Exception) { continue; }

                    GlobalStuff.imgqueuef.Enqueue(b);

                    imgnum = i;
                }
            }
            else
            {
                while (true)
                {
                retry:
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Credentials = new NetworkCredential(username, password);

                    try
                    {
                        WebResponse resp = req.GetResponse();
                        var stream = resp.GetResponseStream();
                        stream.ReadTimeout = 300;

                        byte[] buffer = new byte[buffsize];
                        while (true)
                        {
                            int read = stream.Read(buffer, 0, buffsize);
                            if (read == 0) { throw new TimeoutException(); }
                            builder.addBytes(buffer, read);

                            Thread.Sleep(20);
                        }
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(10);
                        goto retry;
                    }
                }
            }
        }
    }
}
