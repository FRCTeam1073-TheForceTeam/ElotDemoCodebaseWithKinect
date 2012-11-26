using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Research.Kinect;
using Microsoft.Research.Kinect.Nui;
using KinectPacketSender.Demo_Gestures;
using KinectGestureBase;
namespace KinectPacketSender
{
    public partial class Form1 : Form
    {
        List<TelemetryGesture> gestures;
        Runtime nui;    
        public Form1()
        {
            nui = new Runtime();
            gestures = new List<TelemetryGesture>();
            gestures.Add(new ArmAboveHead(true));
           // gestures.Add(new ArmAboveHead(false));
            //gestures.Add(new Victory());
            //gestures.Add(new XboxArmOut());
            InitializeComponent();
            try
            {
                nui.Initialize(RuntimeOptions.UseSkeletalTracking | RuntimeOptions.UseColor); // Test for Kinect
                nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);
                foreach (TelemetryGesture g in gestures) g.updateGesture(); 
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please connect a Kinect...");
                return;
            }
        }
        void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            foreach (SkeletonData data in e.SkeletonFrame.Skeletons)
            {
                Gesture.updateJoints(data);
                foreach (TelemetryGesture gesture in gestures)
                {
                    if (gesture.timeDelayHasPassed())    //check for time delay.
                    {
                        if (gesture.isDoingGesture())   //check to see if the gesture is being performed.
                        {

                            short val = gesture.getAdditionalData();
                            if (val == TelemetryGesture.NO_ONE_CARES)
                            {
                                GlobalStuff.SendData(gesture.getID());
                            }
                            else
                            {
                                GlobalStuff.SendData(gesture.getID(), val);
                            }
                            gesture.updateGesture();
                            const string line = "\n=======================================";
                            richTextBox1.Text += line;
                            richTextBox1.Text += "Performing:\t" + gesture.getDescription();
                            richTextBox1.Text += "\nSending Command:\t" + gesture.getID();
                            richTextBox1.Text += "\nRobot Functionality:\t " + gesture.getRobotDescription();
                            if (gesture.getAdditionalData() != TelemetryGesture.NO_ONE_CARES)
                            {
                                richTextBox1.Text += "\nAdditional Robot Data:\t" + gesture.getAdditionalData();
                            }
                        }
                    }
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
