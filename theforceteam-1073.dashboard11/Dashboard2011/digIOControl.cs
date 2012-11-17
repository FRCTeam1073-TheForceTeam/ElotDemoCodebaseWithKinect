using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Dashboard2011
/*ALRIGHT...
 * WHEN I'm actually able to read the values from the main program we NEED
 * to set the label status to equal the 2 predefined labels: "good" or "bad"
 * Everything else should be ok.
 */
{
    public partial class DigIO : UserControl
    {
        public DigIO()
        {
            InitializeComponent();
        }
 
        private int port;
        public int portNum
        {
            get { return port; }
            set
            {
                port = value;
                PortNB.Text = "Port: " + value.ToString();
            }
        }
        private void digIOControl_Load(object sender, EventArgs e)
        {
            formatLabels();
        }

        private bool on = false;
        public bool On
        {
            get { return on; }
            set
            {
                on = value;
                formatLabels();
            }
        }
        private void formatLabels()
        {
            this.direction.Text = dir ? read : write;
            this.status.Text = on ? "1" : "0";
        }
        bool dir;
        const string read = "In";
        const string write = "Out";
        public bool Dir
        {
            get { return dir; }
            set { dir = value; formatLabels(); }
        }
    }
}