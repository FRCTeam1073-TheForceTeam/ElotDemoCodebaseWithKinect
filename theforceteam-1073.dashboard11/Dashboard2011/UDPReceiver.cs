using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Dashboard2011
{
    class UDPReceiver
    {
        UdpClient UDPC = null;
        IPEndPoint EP = null;
        Queue q = null;
        public UDPReceiver(int port, string IP, Queue q)
        {
            UDPC = new UdpClient(port);
            EP = new IPEndPoint(IPAddress.Parse(IP), port);
            this.q = q;
        }

        private Thread thread;
        public void Start()
        {
            thread = new Thread(new ThreadStart(receiver));
            GlobalStuff.receiverthreads.Add(thread);
            thread.Start();
        }

        private void receiver()
        {
            while (true)
            {
                var bytes = UDPC.Receive(ref EP);
                if (bytes != null) {
                    q.Enqueue(bytes);
                    GlobalStuff.Write('U', bytes);
                }

                Thread.Sleep(2);
            }
        }
    }
}
