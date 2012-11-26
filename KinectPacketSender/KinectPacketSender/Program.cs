using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KinectPacketSender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public static class GlobalStuff
    {
        public static System.Collections.Queue udpqueue;
        public static System.Collections.Queue netqueue;
     
        private static System.Net.Sockets.UdpClient sender = new System.Net.Sockets.UdpClient(senderport);
        private static System.Net.IPEndPoint senderEP = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(RobotIP), senderport);
        private const int senderport = 1130;
        public const string RobotIP = "10.10.73.2";
        
        private static ushort sendcnt = 0;

        public static void SendData(params object[] o)
        {
            string s = sendcnt.ToString() + '\t';
            foreach (object ob in o) { s += ob.ToString() + '\t'; }

            var data = System.Text.Encoding.ASCII.GetBytes(s);
            // send multiple times
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    sender.Send(data, data.Length, senderEP);
                    System.Threading.Thread.Sleep(5); // ***** may not be necessary
                }
                catch (System.Net.Sockets.SocketException) { }
            }
            sendcnt++;
        }


    }
}
