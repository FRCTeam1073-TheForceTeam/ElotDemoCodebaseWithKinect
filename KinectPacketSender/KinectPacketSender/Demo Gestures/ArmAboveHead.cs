using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace KinectPacketSender.Demo_Gestures
{
    class ArmAboveHead : TelemetryGesture
    {
        private bool on_off;
        public ArmAboveHead(bool on_off) {this.on_off = on_off; }
        public override bool isDoingGesture()
        {
            const float threshold = 0.15f;
            if (on_off)
            {
                return getDistanceY(HEAD, HAND_LEFT) > threshold;
            }
            else
            {
                return getDistanceY(HEAD, HAND_RIGHT) > threshold;
            }
        }
        protected override double getDelayTimeSeconds()
        {
            return 1.2;
        }
        public override string getDescription()
        {
            return "The left arm is above the head";
        } 
        public override char  getID()
        {
            return on_off ? (char) 0 : 'J'; //null characters
        }
        public override string getRobotDescription()
        {
            return ""; 
        }
    }
} 
