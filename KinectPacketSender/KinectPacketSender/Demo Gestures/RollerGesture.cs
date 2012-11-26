using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace KinectPacketSender.Demo_Gestures
{
    class RollerGesture : TelemetryGesture
    {
        private bool on_off;
        public RollerGesture(bool on_off)
        {
            this.on_off = on_off;
        }
        protected override double getDelayTimeSeconds()
        {
            return 0.5;
        }
        public override bool isDoingGesture()
        {
            if (on_off)
            {
                return touching(HAND_LEFT, HEAD);
            }
            else
            {
                return touching(HAND_RIGHT, HEAD);
            }
        }
        public override char getID()
        {
            return on_off ? 'U' : '_';
        }
    }
}
