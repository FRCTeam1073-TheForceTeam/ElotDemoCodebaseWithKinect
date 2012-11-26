using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KinectGestureBase;
namespace KinectPacketSender.Demo_Gestures
{
    class XboxArmOut : TelemetryGesture
    {
        public XboxArmOut() { }
        public override bool isDoingGesture()
        {

            /*
             * Testing the gesture... so last meeting you wrote the gesture and it wasn't working
             * You now have to test each component of the gesture. You can guess and tweak different values,
             * but your best bet is to look at what the Kienct actually is reading. 
             * Here's how we can go through that process...
             */ 

            //make distance values variables. the syntax is
            //float NAME = value;
            float hipRightHandRightX = getDistanceX(HIP_RIGHT, HAND_RIGHT); //here's an example of one.
            float hipRightHandX_THRESHOLD = 0.25f;  //you have to attach an f suffix when you enter a float variable
            //then, in the if statement, replace conditions with the variable you declared... i did it below.
            //also replace the threshold with the variable.
            if (!(hipRightHandRightX > hipRightHandX_THRESHOLD))
            {
                //now one of the conditions for the if statement has been replaced with variables.
                //if we got here in the code, it means this if statement failed - the user didn't do the gesture right.
                //let's take a look at what kind of values we are reading.
            //    MessageBox.Show("the right hip and right hand distance is " + hipRightHandRightX + " we want it to be bigger than " + hipRightHandX_THRESHOLD);
                //if this part of the gesture fails - that messagebox will display the hipRightHandRightX value
                //if the user is doing the gesture correctly, you're threshold migh tbe too big/too small.


                return false;
            }
            float HipleftHandLeftx = getDistanceX(HIP_LEFT, HAND_LEFT);
            float HipleftHandLeftx_THRESHOLD = 0.5f;
            if (!(HipleftHandLeftx < HipleftHandLeftx_THRESHOLD))
            {
              //MessageBox.Show(" the hip left hand left x value is " + HipleftHandLeftx + " it should be less than " + HipleftHandLeftx_THRESHOLD);
                return false;
            }
            float HipRightHandrighty= getDistanceY(HIP_RIGHT, HAND_RIGHT);
            float HipRightHandRighty_THRESHOLD = 0.3f;
            if (!(HipRightHandrighty < HipRightHandRighty_THRESHOLD))
            {
                //MessageBox.Show(" the hip right hand right y value is " + HipRightHandrighty + " it should be less than" + HipRightHandRighty_THRESHOLD);
                return false;
            }
            float HipRightHandRightZ = getDistanceZ(HIP_RIGHT, HAND_RIGHT);
            float HipRightHandRightZ_THRESHOLD = 0.2f;
            if (!(HipRightHandRightZ < HipRightHandRightZ_THRESHOLD))
            {
                //MessageBox.Show(" the hip right hand right z value is " + HipRightHandRightZ + " it should be less than " + HipRightHandRightZ_THRESHOLD);
                return false;
            }
            return true;
        }
        public override string getDescription()
        {
            return "Xbox Gesture";
        }
        protected override double getDelayTimeSeconds()
        {
            return 1.0;
        }
        public override char getID()
        {
            return '<';
        }
    }
}
