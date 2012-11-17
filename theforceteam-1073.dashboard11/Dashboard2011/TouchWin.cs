using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dashboard2011
{
    public partial class TouchWin : Form
    {
        Queue<Bitmap> retroin = new Queue<Bitmap>();
        Queue<List<PointF>> retroout = new Queue<List<PointF>>();
        Queue<Rectangle> searchq = new Queue<Rectangle>();
        RetroDetector detecror;
        List<PointF> tapes;
        
        public TouchWin()
        {
            InitializeComponent();
        }

        Bitmap pegs;
        private void Loaded(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            int startXPos = this.Width;
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(startXPos - this.Width, 0);

            //Cursor.Hide();

            detecror = new RetroDetector(retroin, retroout, searchq);
            timer1.Enabled = true;
            timer1.Start();

            searchq.Enqueue(new Rectangle(0, 0, 1, 1));

            #region graphics init.
            // PegsBox.Width do in one place only
            pegs = new Bitmap(this.PegsBox.Width, this.PegsBox.Height);
            var g = Graphics.FromImage(pegs);
            int poles = 225;
            g.FillRectangle(new SolidBrush(Color.Gray), 0, 0, PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c1 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c2 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c3 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c4 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c5 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(poles, poles, poles)), (c6 - cw / 2) * PegsBox.Width, 0, cw * PegsBox.Width, PegsBox.Height);
            float rad = .022F;
            int tapecol = 255;
            for (int col = 0; col < 6; col++)
            {
                float x = 0;
                switch (col)
                {
                    case 0: x = c1 * PegsBox.Width; break;
                    case 1: x = c2 * PegsBox.Width; break;
                    case 2: x = c3 * PegsBox.Width; break;
                    case 3: x = c4 * PegsBox.Width; break;
                    case 4: x = c5 * PegsBox.Width; break;
                    case 5: x = c6 * PegsBox.Width; break;
                }

                float _x = x - rad * PegsBox.Width;
                float _y1 = ((col != 1 && col != 4) ? h1 * PegsBox.Height : (h1 - offset) * PegsBox.Height) - rad * PegsBox.Width;
                float _y2 = ((col != 1 && col != 4) ? h2 * PegsBox.Height : (h2 - offset) * PegsBox.Height) - rad * PegsBox.Width;
                float _y3 = ((col != 1 && col != 4) ? h3 * PegsBox.Height : (h3 - offset) * PegsBox.Height) - rad * PegsBox.Width;
                g.FillEllipse(new SolidBrush(Color.FromArgb(tapecol, tapecol, tapecol)), _x, _y1, 2 * rad * PegsBox.Width, 2 * rad * PegsBox.Width);
                g.FillEllipse(new SolidBrush(Color.FromArgb(tapecol, tapecol, tapecol)), _x, _y2, 2 * rad * PegsBox.Width, 2 * rad * PegsBox.Width);
                g.FillEllipse(new SolidBrush(Color.FromArgb(tapecol, tapecol, tapecol)), _x, _y3, 2 * rad * PegsBox.Width, 2 * rad * PegsBox.Width);
            }
            this.PegsBox.Image = pegs;
            #endregion
        }
        bool hasreceivedtapes = false;
        int imgwid = 0, imghei = 0;

        /// <summary>
        /// Coordinates of tape
        /// </summary>
        int xtape = 0, ytape = 0; // coordinates of tape

        Pen p = new Pen(Color.Red, 2);
        Bitmap image = null;
        private void Tick(object sender, EventArgs e)
        {
            if (GlobalStuff.imgqueuef.Count > 0)
            {
                #region dequeue image
            redo:
                image = GlobalStuff.imgqueuef.Dequeue() as Bitmap;
                if (image == null)
                {
                    if (GlobalStuff.imgqueuef.Count > 0) { goto redo; }
                    else return;
                }
                #endregion

                imgwid = image.Width;
                imghei = image.Height;
                retroin.Enqueue(new Bitmap(image));

                #region displaying image
                this.ImgBox.Height = (this.ImgBox.Width * imghei) / imgwid;
                
                Bitmap drawn = new Bitmap(image);

                var g = Graphics.FromImage(drawn);

                g.DrawRectangle(p, xtape - rectx, ytape - recty, 2 * rectx, 2 * recty);

                this.ImgBox.Image = new Bitmap(drawn, ImgBox.Size);
                #endregion

                GlobalStuff.imgqueuef.Clear(); // avoid buildup
            }

            if (retroout.Count > 0)
            {
                tapes = retroout.Dequeue();
                retroout.Clear();

                if (tapes != null)
                {
                    if (!hasreceivedtapes)
                    {
#if false
                        // first tapes received are twilight list of all visible tapes
                        // ***** change what it does with these tapes
                        Bitmap shower = new Bitmap(image);
                        var g = Graphics.FromImage(image);

                        foreach (var t in tapes)
                        {
                            g.DrawEllipse(p, t.X - 5, t.Y - 5, 10, 10);
                        }

                        image.Save("C:/tapes.png");
#endif

                        hasreceivedtapes = true;
                    }
                    else if (tapes.Count > 0)
                    {
                        if (!GlobalStuff.Zombie)
                        {
                            xtape = (int)tapes[0].X;
                            ytape = (int)tapes[0].Y;
                        }


                        searchq.Enqueue(new Rectangle(xtape - rectx, ytape - recty, 2 * rectx, 2 * recty));

                        if (RetroAuto)
                        {
                            float camanglex = 54;
                            float camangley = 50; // ***** real values should be here.

                            float xoff = (tapes[0].X - imgwid / 2) * camanglex / imgwid;
                            float yoff = (tapes[0].Y - imghei / 2) * camangley / imghei;

                            GlobalStuff.SendData(RetroAutoID, xoff, yoff);
                        }
                    }
                }
            }

            this.Text = string.Format("Touch Screen Window (x={0}, y={1})", GlobalStuff.xpeg, GlobalStuff.ypeg);
        }

        Pen pen = new Pen(Color.Yellow, 6.0f);
        byte xpeg;
        byte ypeg;
        const float c1 = .11F;
        const float c2 = .25F;
        const float c3 = .39F;
        const float c4 = .61F;
        const float c5 = .75F;
        const float c6 = .89F;
        const float cw = .018F;
        const float h1 = .9F;
        const float h2 = .6F;
        const float h3 = .3F;
        const float offset = .12F;


        bool RetroAuto = false;
        int rectx = 22;
        int recty = 10;
        //
        private void CamBox_click(object sender, MouseEventArgs e)
        {
            RetroAuto = true; // drive to tape;
            xtape = e.X * imgwid / ImgBox.Width;
            ytape = e.Y * imghei / ImgBox.Height;
            retroout.Clear();
            searchq.Enqueue(new Rectangle(xtape - rectx, ytape - recty, 2 * rectx, 2 * recty));
        }


        #region sending ID's
        const char AutomateID = 'A';
        const char HeightID = 'H';
        const char RetroAutoID = 'R';
        #endregion

        private void PegsBox_click(object sender, MouseEventArgs e)
        {
            //MouseEventArgs e = new MouseEventArgs(0, 0, pegs.Width - ee.Y, ee.X, 0);

            int x1 = Math.Abs((int)(c1 * pegs.Width) - e.X);
            int x2 = Math.Abs((int)(c2 * pegs.Width) - e.X);
            int x3 = Math.Abs((int)(c3 * pegs.Width) - e.X);
            int x4 = Math.Abs((int)(c4 * pegs.Width) - e.X);
            int x5 = Math.Abs((int)(c5 * pegs.Width) - e.X);
            int x6 = Math.Abs((int)(c6 * pegs.Width) - e.X);

            int xmin = x1;
            byte _xmin = 1;

            if (x2 < xmin) { xmin = x2; _xmin = 2; }
            if (x3 < xmin) { xmin = x3; _xmin = 3; }
            if (x4 < xmin) { xmin = x4; _xmin = 4; }
            if (x5 < xmin) { xmin = x5; _xmin = 5; }
            if (x6 < xmin) { xmin = x6; _xmin = 6; }

            bool _offset = _xmin == 2 || _xmin == 5;

            float y1 = h1 * pegs.Height;
            float y2 = h2 * pegs.Height;
            float y3 = h3 * pegs.Height;

            float off = offset * pegs.Height;
            if (_offset)
            {
                y1 -= off;
                y2 -= off;
                y3 -= off;
            }

            float d1 = Math.Abs(y1 - e.Y);
            float d2 = Math.Abs(y2 - e.Y);
            float d3 = Math.Abs(y3 - e.Y);

            float ymin = d1;
            byte _ymin = 1;

            if (d2 < ymin) { ymin = d2; _ymin = 2; }
            if (d3 < ymin) { ymin = d3; _ymin = 3; }

            xpeg = _xmin;
            ypeg = _ymin;

            float xdraw = 0;
            switch (xpeg)
            {
                case 1: xdraw = c1 * pegs.Width; break;
                case 2: xdraw = c2 * pegs.Width; break;
                case 3: xdraw = c3 * pegs.Width; break; 
                case 4: xdraw = c4 * pegs.Width; break;
                case 5: xdraw = c5 * pegs.Width; break;
                case 6: xdraw = c6 * pegs.Width; break;
            }

            float ydraw = 0;
            switch (ypeg)
            {
                case 1: ydraw = y1; break;
                case 2: ydraw = y2; break;
                case 3: ydraw = y3; break;
            }

            float size = 28;
            Bitmap b = new Bitmap(pegs);
            Graphics g = Graphics.FromImage(b);

            g.DrawRectangle(pen, xdraw - size, ydraw - size, size * 2, size * 2);

            this.PegsBox.Image = b;

            int h = 2 * ypeg - (xpeg == 2 || xpeg == 5 ? 0 : 1);
            //GlobalStuff.SendData(HeightID, h);
            GlobalStuff.SendData(AutomateID, 7-xpeg, ypeg);
        }

        private void NoAuto_Click(object sender, EventArgs e)
        {
            RetroAuto = false;
        }

        private void mdblclick(object sender, MouseEventArgs e)
        {
            // ***** comment out eventually
            searchq.Enqueue(new Rectangle(0, 0, 0, 0));
        }

        private void SetPincher_Click(object sender, EventArgs e)
        {
            GlobalStuff.SendData('P');
        }

    }
}
