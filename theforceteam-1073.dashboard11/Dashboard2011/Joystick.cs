using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dashboard2011
{
    public partial class Joystick : UserControl
    {
        PictureBox pb = null;
        public Joystick()
        {
            InitializeComponent();
            pb = new PictureBox() { Width = Width, Height = Height };
            this.Controls.Add(pb);
            drawImage();
        }

        private float max;

        private float x;
        private float y;

        public float X
        {
            get { return x; }
            set
            {
                this.x = value;
                drawImage();
            }
        }
        public float Y
        {
            get { return y; }
            set
            {
                this.y = value;
                drawImage();
            }
        }
        public float Max
        {
            get { return max; }
            set
            {
                max = value;
                drawImage();
            }
        }

        Pen p = new Pen(Color.Red, 2);
        SolidBrush br = new SolidBrush(Color.Green);
        float rad = 7;
        void drawImage()
        {
            int size = this.Width;

            int cent = size / 2;

            float xdist = size * x / (2*max);
            float ydist = -size * y / (2*max);

            Bitmap b = new Bitmap(pb.Width, pb.Width);
            var g = Graphics.FromImage(b);

            g.FillEllipse(br, cent - rad, cent - rad, 2 * rad, 2 * rad);
            g.DrawLine(p, (float)(cent), (float)(cent), cent + xdist, cent + ydist);

            this.pb.Image = b;

            this.label1.Text = string.Format("X: {0:0.00}", x);
            this.label2.Text = string.Format("Y: {0:0.00}", y);
        }
    }
}
