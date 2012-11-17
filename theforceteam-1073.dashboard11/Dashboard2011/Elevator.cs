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
    public partial class Elevator : UserControl
    {
        float[] leftPegs = { 2.69f, 5.79f, 8.91f };
        float[] rightPegs = { 3.35f, 6.44f, 9.54f };
        double maxhei = 10;
        double pos;
        public Tube tube = Tube.Circle;
        public float[] LeftPegs
        {
            get
            {
                return leftPegs;
            }
            set
            {
                leftPegs = value;
                UpdateAll();
            }
        }
        public float[] RightPegs
        {
            get
            {
                return rightPegs;
            }
            set
            {
                rightPegs = value;
                UpdateAll();
            }
        }
        public double Max
        {
            get
            {
                return maxhei;
            }
            set
            {
                maxhei = value;
                UpdateAll();
            }
        }
        public double Position
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
                UpdateAll();
            }
        }

        public void UpdateAll()
        {
            double scale = Height / maxhei;

            Bitmap b = new Bitmap(Width, Height);
            var g = Graphics.FromImage(b);
            var br = new SolidBrush(Color.Black);

            g.FillRectangle(
                br,
                0, 0, Width, Height
                );

            float x = this.Width / 2;
            float y = (float)(Height - pos * scale);
            float size = Width * .8f;

            switch (tube)
            {
                case Tube.Circle:
                    g.FillEllipse(new SolidBrush(Color.White), x - size / 2, y - size / 2, size, size);
                    g.FillEllipse(br, x - size / 4, y - size / 4, size/2, size/2);
                    break;
                case Tube.Square:
                    g.FillRectangle(new SolidBrush(Color.Blue), x - size / 2, y - size / 2, size, size);
                    g.FillRectangle(br, x - size / 4, y - size / 4, size / 2, size / 2);
                    break;
                case Tube.Triangle:
                    float[] angles = { 0, (float)(2 * Math.PI / 3), (float)(4 * Math.PI / 3) };
                    PointF[] pnts1 = new PointF[angles.Length];
                    PointF[] pnts2 = new PointF[angles.Length];
                    for (int i = 0; i < angles.Length; i++)
                    {
                        pnts1[i] = new PointF(
                            (float)(x + size * Math.Cos(angles[i])),
                            (float)(y + size * Math.Sin(angles[i]))
                            );
                        pnts2[i] = new PointF(
                            x + (float)(.5 * size * Math.Cos(angles[i])),
                            y + (float)(.5 * size * Math.Sin(angles[i]))
                            );
                    }
                    g.FillPolygon(
                        new SolidBrush(Color.Red),
                        pnts1
                        );
                    g.FillPolygon(
                        br,
                        pnts2
                        );
                    break;
            }

            Pen blue = new Pen(Color.Blue, 4);

            foreach(var h in leftPegs)
            {
                g.DrawLine(blue, 0, (float)(Height - h * scale), 10, (float)(Height - h * scale));
            }

            foreach (var h in rightPegs)
            {
                g.DrawLine(blue, Width - 10, (float)(Height - h * scale), Width, (float)(Height - h * scale));
            }

            this.pictureBox1.Image = b;
        }

        public Elevator()
        {
            InitializeComponent();
            this.pictureBox1.Size = this.Size;
            UpdateAll();
        }

        private void resize(object sender, EventArgs e)
        {
            this.pictureBox1.Size = this.Size;
            UpdateAll();
        }
    }

    public enum Tube
    {
        Triangle,
        Circle,
        Square,
        Uber
    }
}