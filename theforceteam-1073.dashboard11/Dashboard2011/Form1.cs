using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Dashboard2011
{
    public partial class DashWin : Form
    {
        UDPReceiver packets = new UDPReceiver(1165, GlobalStuff.RobotIP, GlobalStuff.udpqueue);
        UDPReceiver netcons = new UDPReceiver(6666, GlobalStuff.RobotIP, GlobalStuff.netqueue);

        public DashWin()
        {
            InitializeComponent();

            #region add IO controls
            // dig. IO's
            for (int i = 0, y = 10; i < digiocnt; i++, y += 30)
            {
                DigIO temp = new DigIO() { Location = new Point(15, y), portNum = i };
                this.IOTab.Controls.Add(temp);
                IOconts[i] = temp;
            }

            // PWM's
            for (int i = 0, y = 10; i < pwmcnt; i++, y += 30)
            {
                Pwm temp = new Pwm() { Location = new Point(150, y), PortNumber = i };
                this.IOTab.Controls.Add(temp);
                PWMconts[i] = temp;
            }

            // Analogs
            for (int i = 0, y = 10; i < analogcnt; i++, y += 35)
            {
                Analog temp = new Analog() { Location = new Point(500, y), PortNumber = i };
                this.IOTab.Controls.Add(temp);
                Anconts[i] = temp;
            }
            #endregion
        }

        private void Resized(object sender, EventArgs e)
        {
            this.tabControl1.Size = this.Size;
        }

        private Bitmap pieces;
        private void Loaded(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            GlobalStuff.Load();

            this.tabControl1.Size = this.Size;
            map = new Bitmap("field.PNG");

            

            this.packetmon.Enabled = true;
            this.packetmon.Start();
            this.cameramon.Enabled = true;
            this.cameramon.Start();

            packets.Start();
            netcons.Start();

            #region graphics init
            pieces = new Bitmap("pieces.PNG");
            this.PieceBox.Height = PieceBox.Width * pieces.Height / pieces.Width;
            pieces = new Bitmap(pieces, PieceBox.Size);
            this.PieceBox.Image = pieces;
            #endregion

            JoyChart.ChartAreas[0].AxisX.LabelStyle.Format = "0.0";
            CurrentChart.ChartAreas[0].AxisX.LabelStyle.Format = "0.0";


            //position added code
            tabControl1.SelectedIndex = 1;
        }

        #region Tab Funcs

        Bitmap map;
        const int l = 127;
        const int r = 884;
        const int t = 31;
        const int b = 412;
        const float fw = 54f;
        const float fh = 27f;

        double[] radii = { .6, 1.5,1.5,1.5,1.5 };
        double[] angles = { 0, .7, Math.PI - .7, Math.PI + .7, -.7 };
        SolidBrush ellipsebrush = new SolidBrush(Color.FromArgb(110, 255, 255, 0));
        SolidBrush robotbrush = new SolidBrush(Color.Blue);
        int[] baits = { 112, 148, 184, 257, 294, 329 };
        //int[] baits = { 329, 294, 257, 184, 148, 112 };
        private void DoNaviTab(RoboData rd)
        {
            // in pixels/foot
            float scalex = (r - l) / fw;
            float scaley = (b - t) / fh;

            float cx = rd.Y * scalex + l;
            float cy = rd.X * scaley + t;
            float rx = rd.SY * scalex;
            float ry = rd.SX * scaley;

            Bitmap img = new Bitmap(map);
            var g = Graphics.FromImage(img);

            g.FillEllipse(ellipsebrush, cx - rx, cy - ry, 2 * rx, 2 * ry);

            PointF[] points = new PointF[radii.Length];
            for (int i = 0; i < radii.Length; i++)
            {
                double rnew = radii[i] * scalex;
                double anew = angles[i] + Math.PI/2 - rd.Heading;
                double x = cx + rnew * Math.Cos(anew);
                double y = cy + rnew * Math.Sin(anew);
                points[i] = new PointF((float)x, (float)y);
            }
            g.FillPolygon(robotbrush, points);

            if (rd.xpeg > 0)
            {
                g.DrawLine(red, (float)l, (float)baits[rd.xpeg - 1], cx, cy);

                PointF mid = new PointF((l + cx) / 2, (baits[rd.xpeg - 1] + cy) / 2);

                if (baits[rd.xpeg - 1] > cy) { mid.Y += 5; }
                else { mid.Y -= 20; }

                g.DrawString(string.Format("{0:0.0} ft @ {0:0} o", rd.PegDist, rd.PegAngle * 180 / Math.PI), new Font(FontFamily.GenericSansSerif, 15F), new SolidBrush(Color.Red), mid);
            }

            this.NaviBox.Image = img;

            this.elevator2.Position = rd.ElevatorHeight;
            ElevLab.Text = string.Format("{0:0.00} ft", rd.ElevatorHeight);
        }

        Pen red = new Pen(Color.Red,2.5f);
        Pen gre = new Pen(Color.Green,2f);
        Pen blu = new Pen(Color.Blue,2f);
        private void DoDriverTab(RoboData rd)
        {
            this.Time.Text = string.Format("Time left: {0:0.0} ({1})", rd.TimeLeft, rd.Mode);

            Bitmap angleimg = new Bitmap(this.AngleBox.Width, this.AngleBox.Height);
            var g = Graphics.FromImage(angleimg);

            float targx = AngleBox.Height * sin(rd.PegAngle);
            float targy = AngleBox.Height * cos(rd.PegAngle);
            float baitx = AngleBox.Height * sin(rd.BaitAngle);
            float baity = AngleBox.Height * cos(rd.BaitAngle);
            g.DrawLine(gre, AngleBox.Height, AngleBox.Height, AngleBox.Height + targx, AngleBox.Height - targy);
            g.DrawLine(blu, AngleBox.Height, AngleBox.Height, AngleBox.Height + baitx, AngleBox.Height - baity);
            g.DrawEllipse(red, 0, 0, AngleBox.Width, AngleBox.Width);
            this.AngleBox.Image = angleimg;

            this.PegLab.Text = string.Format("Peg Angle: {0:0.0}", rd.PegAngle);
            this.BaitLab.Text = string.Format("Bait Angle: {0:0.0}", rd.BaitAngle);

            this.PegDistLab.Text = string.Format("{0:0.00} ft", rd.PegDist);
            this.BaitDistLab.Text = string.Format("{0:0.00} ft", rd.BaitDist);

            //this.elevator1.Height = 3;
            this.elevator1.Position = rd.ElevatorHeight;
            this.elevator1.tube = Tube.Triangle;

            // line sensors! width and height should be 150 and 100
            Bitmap lineSensorImage = new Bitmap(this.LineSensorPictureBox.Width, this.LineSensorPictureBox.Height);
            var g2 = Graphics.FromImage(lineSensorImage);

            float diameter = lineSensorImage.Width * 40 / 150; // should equal 40
            float space = lineSensorImage.Width * 5 / 150;
            if (rd.leftLineSensor)
                g2.FillEllipse(new SolidBrush(Color.Red), space, space, diameter, diameter);
            else
                g2.FillEllipse(new SolidBrush(Color.Green), space, space, diameter, diameter);

            if (rd.middleLineSensor)
                g2.FillEllipse(new SolidBrush(Color.Red), space * 3 + diameter, space, diameter, diameter);
            else
                g2.FillEllipse(new SolidBrush(Color.Green), space * 3 + diameter, space, diameter, diameter);

            if (rd.rightLineSensor)
                g2.FillEllipse(new SolidBrush(Color.Red), space * 5 + 2 * diameter, space, diameter, diameter);
            else
                g2.FillEllipse(new SolidBrush(Color.Green), space * 5 + 2 * diameter, space, diameter, diameter);
            this.LineSensorPictureBox.Image = lineSensorImage;
        
        }
        private void DoConstsTab(RoboData rd) { }

        const int timerange = 10;

        long inittime = DateTime.Now.Ticks;
        private void DoMiscTab(RoboData rd)
        {
            this.joystickL.X = rd.LjoyX;
            this.joystickL.Y = rd.LjoyY;
            this.joystickR.X = rd.RjoyX;
            this.joystickR.Y = rd.RjoyY;
            this.Accel.X = rd.XAccel;
            this.Accel.Y = rd.YAccel;

#if true
            float time = rd.Time;
            JoyChart.Series[0].Points.AddXY(time, rd.LjoyY);
            JoyChart.Series[1].Points.AddXY(time, rd.RjoyY);

            if (rd.Time > timerange)
            {
                JoyChart.ChartAreas[0].AxisX.Minimum = rd.Time - timerange;
                JoyChart.ChartAreas[0].AxisX.Maximum = rd.Time;
            }
            else
            {
                JoyChart.ChartAreas[0].AxisX.Minimum = 0;
                JoyChart.ChartAreas[0].AxisX.Maximum = timerange;
            }
            CurrentChart.ChartAreas[0].AxisX.Minimum = JoyChart.ChartAreas[0].AxisX.Minimum;
            CurrentChart.ChartAreas[0].AxisX.Maximum = JoyChart.ChartAreas[0].AxisX.Maximum;

            CurrentChart.Series["LCurrent"].Points.AddXY(time, rd.LCurrent);
            CurrentChart.Series["RCurrent"].Points.AddXY(time, rd.RCurrent);
            CurrentChart.Series["PincherCurrent"].Points.AddXY(time, rd.PincherCurrent);
            CurrentChart.Series["ArmCurrent"].Points.AddXY(time, rd.ArmCurrent);
            CurrentChart.Series["ElevatorCurrent"].Points.AddXY(time, rd.ElevatorCurrent);

            CurrentChart.Series["Total"].Points.AddXY(time, rd.LCurrent + rd.RCurrent + rd.PincherCurrent + rd.ArmCurrent + rd.ElevatorCurrent); // total current
#endif

            this.UdpId.Text = string.Format("UDP ID: {0}", rd.PacketID);
            this.SkipsLab.Text = string.Format("Skips: {0}", skips);
            this.SkippedLab.Text = string.Format("Skipped: {0}", skipped);
            this.DroppedLab.Text = string.Format("Dropped: {0}", dropped);

            this.Lenc.Text = string.Format("L. Enc: {0}", rd.LEncoder);
            this.Renc.Text = string.Format("R. Enc: {0}", rd.REncoder);

            double vel = Math.Sqrt(rd.XVel * rd.XVel + rd.YVel * rd.YVel);
            this.SpeedLab.Text = string.Format("Speed: {0:0.0} ft/s (Mach {1:.000000})", vel, vel / 1095);
        }

        const int digiocnt = 16; // ***** use real numbers
        DigIO[] IOconts = new DigIO[digiocnt];
        const int pwmcnt = 10;
        Pwm[] PWMconts = new Pwm[pwmcnt];
        const int analogcnt = 8;
        Analog[] Anconts = new Analog[analogcnt];
        private void DoIOTab(RoboData rd)
        {
            for (int i = 0; i < digiocnt; i++)
            {
                IOconts[i].On = rd.GetDigIO(i);
                IOconts[i].Dir = rd.GetDigIOState(i);
            }

            for (int i = 0; i < pwmcnt; i++)
            {
                PWMconts[i].Value = rd.PWMs[i];
            }

            for (int i = 0; i < analogcnt; i++)
            {
                Anconts[i].Value = rd.analogs[i];
            }
        }
        int indexnum = 1;
        private void send()
        {
            GlobalStuff.SendData('X', indexnum);
        }
        private void GeneralUpdate(RoboData rd)
        {
            this.checks.Text = string.Format("Checks: {0}", checkcnt);

            if (rd.DelayMeasurer == indexnum)
            {
                indexnum++;
                new Thread(new ThreadStart(send)).Start(); // send on different thread so not blocking call
            }

            GlobalStuff.xpeg = rd.xpeg;
            GlobalStuff.ypeg = rd.ypeg;

            this.Text = rd.DCBA25 == 0xDCBA25 ? "Dashboard" : "Dashboard (No valid data)";
            GlobalStuff.Zombie = !rd.IsEnabled;
        }
        #endregion

        private RoboData rd;
        TabPage lastpage = null;

        Pen tapepen = new Pen(Color.Red, 2.5f);
        int checkcnt = 0;
        int skips = 0;
        uint skipped = 0;
        uint lastID = uint.MaxValue;
        long dropped = 0;
        bool first = true;
        private void packetcheck(object sender, EventArgs e)
        {
            checkcnt++;
            if (GlobalStuff.udpqueue.Count > 0)
            {
                rd = new RoboData((byte[])GlobalStuff.udpqueue.Dequeue());

                int expectedskipped = GlobalStuff.udpqueue.Count;
                GlobalStuff.udpqueue.Clear();

                if (rd.PacketID - lastID > 1)
                {
                    if (!first)
                    {
                        uint _skipped = rd.PacketID - (lastID + 1);
                        skips++;
                        skipped += _skipped;
                        dropped += _skipped - expectedskipped;
                    }
                    else first = false;
                }
                lastID = rd.PacketID;

                if (this.tabControl1.SelectedTab == lastpage)
                {
                    lastpage = null; // cause update
                }
            }
            if (this.tabControl1.SelectedTab != lastpage)
            {
                if (this.tabControl1.SelectedTab == NaviTab) { DoNaviTab(rd); }
                else if (this.tabControl1.SelectedTab == DriverTab) { DoDriverTab(rd); }
                else if (this.tabControl1.SelectedTab == MiscTab) { DoMiscTab(rd); }
                else if (this.tabControl1.SelectedTab == NetTab) { }
                else if (this.tabControl1.SelectedTab == IOTab) { DoIOTab(rd); }

                this.lastpage = this.tabControl1.SelectedTab;
            }
            GeneralUpdate(rd);

            while (GlobalStuff.netqueue.Count > 0)
            {
                byte[] b = (byte[])GlobalStuff.netqueue.Dequeue();
                //GlobalStuff.netqueue.Clear(); // don't clear -- print everything
                if (b == null) { continue; }
                this.NetConsBox.Text += Encoding.ASCII.GetString(b);
            }

            if (GlobalStuff.imgqueue.Count > 0)
            {
                this.QueueCntLab.Text = string.Format("{0} images in queue", GlobalStuff.imgqueue.Count); // too many images in queue = lag

                var img = GlobalStuff.imgqueue.Dequeue() as Bitmap;
                GlobalStuff.imgqueue.Clear();

                int w = this.Cam1.Width;
                int h = (w * img.Height) / img.Width;
                Cam1.Height = h;
                Cam1.Image = new Bitmap(img, Cam1.Size);

                this.CameraBox.Size = Cam1.Size;
                this.CameraBox.Image = Cam1.Image;
            }
        }

        Pen pen = new Pen(Color.Yellow, 6.0f);

        byte piece = 0;
        private void PieceBox_click(object sender, MouseEventArgs e)
        {
            double x = ((double)(e.X)) / PieceBox.Width;

            Bitmap b = new Bitmap(pieces);
            Graphics g = Graphics.FromImage(b);

            float off = .1f * PieceBox.Height;
            float size = PieceBox.Height - 5 * off;
            if (x < .33333)
            {
                g.DrawRectangle(pen, off, off, size, size);
                piece = 0;
            }
            else if (x < .66666)
            {
                g.DrawRectangle(pen, .33333f*PieceBox.Width+off, off, size, size);
                piece = 1;
            }
            else
            {
                g.DrawRectangle(pen, .66666f*PieceBox.Width+off, off, size, size);
                piece = 2;
            }
            this.PieceBox.Image = b;
        }

        private void cameramon_tick(object sender, EventArgs e)
        {
            //
        }

        #region playback thread
        string imgdir = string.Empty;
        System.IO.BinaryReader br;
        string path = string.Empty;
        void play()
        {
            br = new System.IO.BinaryReader(new System.IO.FileStream(path, System.IO.FileMode.Open));

            long prevtime = long.MaxValue;
            while (true)
            {
                try
                {
                    long time = br.ReadInt64();

                    long ticknum = DateTime.Now.Ticks + (time - prevtime);

                    int size = br.ReadInt32();
                    char type = br.ReadChar();
                    byte[] bytes = br.ReadBytes(size);

                    Bitmap b = null;

                    long curr = DateTime.Now.Ticks;
                    int wait = (int)((ticknum - curr) / 10000);
                    if (wait > 2000) { wait = 0; }
                    Thread.Sleep(wait > 0 ? wait : 0);

                    if (type == 'I')
                    {
                        b = new Bitmap(imgdir + '/' + BitConverter.ToInt32(bytes, 0).ToString() + type + ".jpg");
                    }
                    else if (type == 'W')
                    {
                        b = new Bitmap(imgdir + '/' + BitConverter.ToInt32(bytes, 0).ToString() + type + ".jpg");
                    }


                    

                    switch (type)
                    {
                        case 'U': (size == 1018 ? GlobalStuff.udpqueue : GlobalStuff.netqueue).Enqueue(bytes); break;
                        case 'D': imgdir = System.Text.Encoding.ASCII.GetString(bytes); break;
                        case 'I': GlobalStuff.imgqueue.Enqueue(b); break;
                        case 'W': GlobalStuff.imgqueuef.Enqueue(b); break;
                    }
                    prevtime = time;
                }
                catch (ArgumentException) { }
                catch (Exception)
                {
                    br.Close();
                    br = new System.IO.BinaryReader(new System.IO.FileStream(path, System.IO.FileMode.Open));
                    prevtime = long.MaxValue;
                }
            }
        }

        Thread playthread;
        private void OpenMatch(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // suspend all receiver threads
                foreach (Thread t in GlobalStuff.receiverthreads)
                {
                    t.Suspend();
                }

                if (playthread != null) { playthread.Abort(); }

                path = openFileDialog1.FileName;
                playthread = new Thread(new ThreadStart(play));
                playthread.Start();
            }
        }
        #endregion

        private void Close(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 5000; i++)
            {
                string s = "C:/2011matches/RayTraceDash" + i.ToString() + ".jpg";

                if (System.IO.File.Exists(s))
                {
                    try
                    {
                        System.IO.File.Delete(s);
                    }
                    catch (Exception) { }
                }
            }

            // Delete recordings if none exists
            GlobalStuff.sw.Close();
            var stream = new System.IO.FileStream(GlobalStuff.filepath, System.IO.FileMode.Open);
            if (stream.Length <= sizeof(long) + sizeof(int) + sizeof(char) + GlobalStuff.imgdirname.Length)
            {
                stream.Close();
                System.IO.File.Delete(GlobalStuff.filepath);
                System.IO.Directory.Delete(GlobalStuff.imgdirname);
            }

            // Kill dashboard so it doesn't continue running in background.
            var prcsss = System.Diagnostics.Process.GetProcessesByName("Dashboard2011");
            foreach (var p in prcsss)
            {
                p.Kill();
            }
        }

        private void GetFromRobot(object sender, EventArgs e)
        {
            playthread.Abort();

            // resume all receiver threads
            foreach (Thread t in GlobalStuff.receiverthreads)
            {
                t.Resume();
            }
        }

        private float sin(float f)
        {
            return (float)Math.Sin(f * Math.PI / 180);
        }
        private float cos(float f)
        {
            return (float)Math.Cos(f * Math.PI / 180);
        }

        private void NetConsBox_TextChanged(object sender, EventArgs e)
        {
            this.NetConsBox.ScrollToCaret();
        }

        private void SendRPMbutton_Click(object sender, EventArgs e)
        {
            string topSpeed = this.topRPMTextBox.Text;
            string botttomSpeed = this.BottomRPMTextBox.Text;

            if (topSpeed.Length > 0 && botttomSpeed.Length > 0)
                GlobalStuff.SendData('Q', topSpeed, botttomSpeed);
        }

        private void resetSpeedDropButton_Click(object sender, EventArgs e)
        {
            GlobalStuff.SendData('P');
        }


    }
}
