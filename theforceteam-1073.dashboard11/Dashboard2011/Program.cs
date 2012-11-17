//#define SIM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using KinectDemo;
#if SIM
#warning Simulation mode
#endif
namespace Dashboard2011
{
    static class Program
    {

        static public MainDemoForm kinectForm;
        static public VideoFeedForm kinectVid;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            //kinect

            #region kill netconsole & look at other processes
            var prcsss = System.Diagnostics.Process.GetProcessesByName("NetConsole");
            if (prcsss.Length > 0)
            {
                foreach (var p in prcsss)
                {
                    p.Kill();
                }
                System.Threading.Thread.Sleep(1000);
            }

            prcsss = System.Diagnostics.Process.GetProcessesByName("Dashboard");
            if (prcsss.Length > 0)
            {
                foreach (var p in prcsss)
                {
                    p.Kill();
                }
                System.Threading.Thread.Sleep(1000);
            }

            if (System.Diagnostics.Process.GetProcessesByName("Driver Station").Length == 0)
            {
                MessageBox.Show("Driver station is not running.  This could cause problems with dashboard.");
            }
            #endregion

            #region recording initialization
            string filename = DateTime.Now.ToString("dddd_dd_MMMM_yyyy_HH_mm_ss");
            GlobalStuff.filepath += filename + ".match";
            GlobalStuff.imgdirname += filename;
            
            #endregion

            #region directory stuff
            if (!Directory.Exists(GlobalStuff.imgdirname)) { Directory.CreateDirectory(GlobalStuff.imgdirname); }
            if (!Directory.Exists(GlobalStuff.imgdirname)) { Directory.CreateDirectory(GlobalStuff.imgdirname); }
            #endregion
            GlobalStuff.sw = new BinaryWriter(new FileStream(GlobalStuff.filepath, FileMode.Create));

            GlobalStuff.Write('D', System.Text.Encoding.ASCII.GetBytes(GlobalStuff.imgdirname)); // record where images are stored

            // initialize queues
            GlobalStuff.imgqueue = new Queue(128);
            GlobalStuff.imgqueuef = new Queue(128);
            /*
            GlobalStuff.numqueue = new Queue(128);
            GlobalStuff.numqueuef = new Queue(128);
            */
            GlobalStuff.udpqueue = new Queue(128);
            GlobalStuff.netqueue = new Queue(128);

            GlobalStuff.udpqueue.Enqueue(new byte[1018]); // ***** needed?

#if false
            GlobalStuff.imagebuilder = new ImageBuilder(
                GlobalStuff.FlashCamIsWeb ? GlobalStuff.imgqueue : GlobalStuff.imgqueuef,
                GlobalStuff.FlashCamIsWeb ? GlobalStuff.numqueue : GlobalStuff.numqueuef,
                GlobalStuff.imgdirname
                );

            GlobalStuff.tcprec = new TcpReceiver(1180, GlobalStuff.RobotIP, GlobalStuff.imagebuilder.addBytes);
#endif
            /**/
            GlobalStuff.creader = new CameraReader("http://10.10.73.3:80/axis-cgi/mjpg/video.cgi",
                "root", "admin",
                GlobalStuff.imgqueuef,
                //GlobalStuff.numqueuef,
                GlobalStuff.imgdirname,
                'W'
                );
            /**/
            GlobalStuff.creader2 = new CameraReader("http://10.10.73.9:80/axis-cgi/mjpg/video.cgi",
                "root", "admin",
                GlobalStuff.imgqueue,
                            //GlobalStuff.numqueue,
                GlobalStuff.imgdirname,
                'I'
                );
            /**/

            new System.Threading.Thread(new System.Threading.ThreadStart(SecondaryWin)).Start();


            Application.EnableVisualStyles();
                /*
                 * SetCompatibleTextRenderingDefault must be called before the first IWin32Window object is created in the application. */
            Application.SetCompatibleTextRenderingDefault(false);

            kinectForm = new MainDemoForm();
            kinectForm.Show();
            kinectVid = new VideoFeedForm();
            kinectVid.Show();
            Application.Run(new DashWin());
         
        }

        private static void SecondaryWin()
        {
            Application.Run(new TouchWin());
        }
    }
    public static class GlobalStuff
    {
        public static System.Collections.Queue imgqueue;
        public static System.Collections.Queue imgqueuef;
        /*
        public static System.Collections.Queue numqueue;
        public static System.Collections.Queue numqueuef;
        */
        public static System.Collections.Queue udpqueue;
        public static System.Collections.Queue netqueue;
        public static string imgdirname = "C:/2011matches/";

        public static CameraReader creader;
        public static CameraReader creader2;

        #region sending stuff
#if SIM
        public static void Load()
        {
            sender.Connect("127.0.0.1", senderport);
        }
        private static System.Net.Sockets.UdpClient sender = new System.Net.Sockets.UdpClient();
        public static bool Sim = true;
#else
        public static void Load() { }
        private static System.Net.Sockets.UdpClient sender = new System.Net.Sockets.UdpClient(senderport);
        private static System.Net.IPEndPoint senderEP = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(RobotIP), senderport);
        public static bool Sim = false;
#endif
        private const int senderport = 1130;
        public const string RobotIP = "10.10.73.2"; // was 10.10.73.2 *****

        //private static System.Net.IPEndPoint senderEP = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(RobotIP), senderport);
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
                    sender.Send(data, data.Length
#if !SIM
                        ,senderEP
#endif
                        );
                    System.Threading.Thread.Sleep(5); // ***** may not be necessary
                }
                catch (System.Net.Sockets.SocketException) { }
            }
            Write('S', System.Text.Encoding.ASCII.GetBytes(s));
            sendcnt++;
        }
        #endregion
        #region recording stuff
        public static string filepath = "C:/2011matches/";
        public static BinaryWriter sw;
        public static void Write(char c, byte[] o)
        {
            try
            {
                sw.Write(DateTime.Now.Ticks); // long
                sw.Write(o.Length);           // int
                sw.Write(c);                  // char
                sw.Write(o);                  // byte[]
            }
            catch (ObjectDisposedException) { }
            catch (Exception) { }
        }

        /// <summary>
        /// Every thread that receives stuff should be added to the list so they can be suspended & resumed for playback
        /// </summary>
        public static List<System.Threading.Thread> receiverthreads = new List<System.Threading.Thread>();
        #endregion

        public static byte xpeg = 1;
        public static byte ypeg = 1;

        public static bool Zombie = false;
    }
}
