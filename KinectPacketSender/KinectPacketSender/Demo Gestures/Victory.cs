using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KinectGestureBase;
namespace KinectPacketSender.Demo_Gestures
{
    class Victory : TelemetryGesture
    {
        public Victory() { }
        public override bool isDoingGesture()
        {
            float HipRightShoulderRighty_THRESHOLD = getDistanceY(SHOULDER_RIGHT, HIP_RIGHT) / 2;
            if (ELBOW_RIGHT.Y > SHOULDER_RIGHT.Y)
                return false;
            if (ELBOW_RIGHT.Y < HIP_RIGHT.Y)
                return false;
            float ElbowPosition_THRESHOLD = 0.18f;
            float Elbowdistance = getDistanceY(ELBOW_RIGHT, SHOULDER_RIGHT);
            if (!(Elbowdistance <= HipRightShoulderRighty_THRESHOLD + ElbowPosition_THRESHOLD) && !(Elbowdistance >= HipRightShoulderRighty_THRESHOLD - ElbowPosition_THRESHOLD))
            {
                return false;
            }
            if (!(getDistanceX(HAND_RIGHT, SHOULDER_RIGHT) > 0.15f)) return false;
            
            return true;
        }
        public override string getDescription()
        {
            return "VICTORY!!!!!!!";
        }
        public override char getID()
        {
            return '+';
        }
    }
}
