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
    public partial class Analog : UserControl
    {
        public Analog()
        {
            InitializeComponent();
        }
        private int port;
        public int PortNumber
        {
            get { return port; }
            set
            {
                port = value;
                update();
            }
        }

        private float val;
        public float Value
        {
            get { return val; }
            set
            {
                val = value;
                update();
            }
        }

        private void update()
        {
            this.analogLabel.Text = string.Format("Port {0}", port);
            int _val = (int)(val * analogProgB.Maximum + .5);
            if (_val > analogProgB.Maximum) { val = analogProgB.Maximum - 1; }
            else if (_val < analogProgB.Minimum) { val = analogProgB.Minimum; }

            try
            {
                this.analogProgB.Value = _val;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void load(object sender, EventArgs e)
        {
            update();
        }
    }
}
