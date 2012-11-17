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
    public partial class Pwm : UserControl
    {
        public Pwm()
        {
            InitializeComponent();
        }
        private int port;
        public int PortNumber
        {
            get { return port; }
            set { port = value; updateUI(); }
        }
        private float internalVal = 0;
        public int Value
        {
            get { return (int)(internalVal * 128 + 128); }
            set
            {
                if (value < 0 || value > 255)
                {
                    internalVal = 0;
                }
                else
                {
                    internalVal = (value - 128.0f) / 128.0f;
                }
                updateUI();
            }
        }
        private void updateUI()
        {
            pwmProgress.Value = (int)((internalVal + 1) * 50);
            PWNReadout.Text = internalVal.ToString();
            PWNname.Text = port.ToString();
        }
        private void pwn_Load(object sender, EventArgs e)
        {
            updateUI();
        }
    }
}