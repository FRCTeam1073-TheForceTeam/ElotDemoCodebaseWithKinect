using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Research.Kinect.Nui;
using KinectGestureBase;
namespace KinectPacketSender
{
    public abstract class TelemetryGesture : Gesture{
        public const short NO_ONE_CARES = 37; // it's a "sexy prime" ;-)
        public abstract char getID();   //return command to send down to the robot for Elot's DashboardReciever.cpp
        public virtual short getAdditionalData() { return NO_ONE_CARES; }
        public virtual string getRobotDescription() { return ""; } //Description of Action Performed on Robot
    }
}
