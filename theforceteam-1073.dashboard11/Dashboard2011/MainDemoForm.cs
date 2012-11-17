using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Research.Kinect.Nui;
using System.IO;
using Coding4Fun.Kinect.Common;
using Coding4Fun.Kinect.WinForm;
using Dashboard2011;
namespace KinectDemo
{//evin, greg, rachel... under the helpful wing of mr. c 
    public partial class MainDemoForm : Form
    {
        public MainDemoForm() { InitializeComponent(); }

        Runtime nui;
      //  VideoFeedForm videoForm;    //used for video feed
        int frameCount = 0;
        DateTime startTime = new DateTime();
        Point speedLastPoint;

        DateTime clawStartTime = new DateTime();
        DateTime elevatorStartTime = new DateTime();
        DateTime changeDirectionStartTime = new DateTime();
        DateTime tankDriveDateTime = new DateTime();
        DateTime resetDateTime = new DateTime();

        bool isMovingForward = true;    //used for the flex tank drive 

        enum levels { baseLvl, one, two, three, four, five, six };    //used in demo to correspond to peg positions... if we go through with this i think there's an enum on elot.
        enum wingState { leftWing, rightWing, fullThrottleTurbo, kiwi };
        wingState tankDrivePosition;
        private void Form1_Load(object sender, EventArgs e)
        {

            

            nui = new Runtime();
            this.Location = new Point(0, 0);
            //videoForm = new VideoFeedForm(new Point(this.Location.X, this.Location.Y + this.Height));
            label1.ForeColor = this.BackColor;

            //videoForm.Show(this);
            try
            {
                nui.Initialize(RuntimeOptions.UseSkeletalTracking | RuntimeOptions.UseColor); // Test for Kinect
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Runtime initialization failed. Please make sure Kinect device is plugged in.");
                return;
                //i don't kill the app at this point because it might be useful for people to see the UI even though we have no kinect running.
            }

            try
            { nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color); }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Failed to open stream. Please make sure to specify a supported image type and resolution.");
                return;
            }
            nui.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(nui_ColorFrameReady);
            nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);

            currentHeight = levels.baseLvl; //set elevator height to the bast level
        }
        void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            
            SkeletonFrame skeletonFrame = e.SkeletonFrame;
            int iSkeleton = 0;
            int savedFrameCount = frameCount;
            int speedX = 0;
            int speedY = 0;
            foreach (SkeletonData data in skeletonFrame.Skeletons) // multiple skeleton's because if you leave frame, when you come back your a different Sleleton ID
            {
                if (SkeletonTrackingState.Tracked == data.TrackingState)
                {
                    startTime = DateTime.Now;

                    if (canMove(resetDateTime, 2.0)) { resetBot(data.Joints[JointID.HandLeft], data.Joints[JointID.HandRight], data.Joints[JointID.ShoulderLeft], data.Joints[JointID.ShoulderRight], data.Joints[JointID.HipCenter]); }
                    else
                    {
                        isResetMode = false;
                        resetLabel.Text = "In Reset Mode:\t" + isResetMode.ToString();
                    }

                    Joint head = data.Joints[JointID.Head];
                    Joint leftKnee = data.Joints[JointID.KneeLeft];
                    Joint rightKnee = data.Joints[JointID.KneeRight];
                    Joint leftHand = data.Joints[JointID.HandLeft];
                    Joint rightHand = data.Joints[JointID.HandRight];
                    Joint leftShoulder = data.Joints[JointID.ShoulderLeft];
                    Joint rightShoulder = data.Joints[JointID.ShoulderRight];

                    //TODO: go fix this elevator logic with rookies.
                    //that would be cool.
                  //  if (canMove(elevatorStartTime, 1.0)) { moveElevator(data.Joints[JointID.WristLeft], data.Joints[JointID.WristRight], data.Joints[JointID.ShoulderCenter]); }
                    if (canMove(clawStartTime, 2.0)) { moveClaw(leftKnee.Position.X, rightKnee.Position.X); }
                    if (canMove(changeDirectionStartTime, 1.0)) { changeDirection(leftHand, head); }
                    if (canMove(tankDriveDateTime, 0.5)) { spreadYourWingsAndFly(leftHand,rightHand, leftShoulder, rightShoulder, head.Position.Y); }
                    frameCount++;
                    if (frameCount <= 1)
                        startTime = DateTime.Now;
                    TimeSpan elapsedTime = DateTime.Now - startTime;
                    double fps = 0;
                    if (elapsedTime.TotalSeconds > 0)
                        fps = frameCount / elapsedTime.TotalSeconds;
                    if (frameCount % 10 == 0)
                    {
                        speedX = (int)(speedLastPoint.X / elapsedTime.TotalSeconds);
                        speedY = (int)(speedLastPoint.Y / elapsedTime.TotalSeconds);
                    }
               }

                iSkeleton++;
            } // for each skeleton

            if (savedFrameCount == frameCount)
            {
                label1.ForeColor = this.BackColor;
                frameCount = 0;
            }
        }
        void nui_ColorFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            // 32-bit per pixel, RGBA image
            PlanarImage image = e.ImageFrame.Image;
            Bitmap bitmap = e.ImageFrame.ToBitmap();
            Program.kinectVid.pictureBox1.Image = bitmap; 
        }
        
        private void kill()
        {
            MessageBox.Show("The program will close", "Try plugging in a kinnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            System.Environment.Exit(1);
        }
        levels currentHeight = levels.baseLvl;


        bool canMove(DateTime move, double waitTime)//each method corresponds to a robot action.depending on userInput or mechanical design, there needs to be a delay between mehtod calls
        {
            if (move == new DateTime())  //returns true for method call. (i.e.   elevator's datetime var is NULL the first time, so we give back true)
                return true;
            if ((DateTime.Now - move).TotalSeconds >= waitTime)
                return true;
            else
                return false;
        }

        void moveElevator(Joint leftHand, Joint rightHand, float shoulderZ, float headY)
        {
            int i = 0;  //used for pbars
        }
//            const float ARM_ABOVE_SHOLDER_MIN = 0.f;
             const float ARM_EXTENSION_DISTANCE = 0.3f;
        /*


         /  if ((leftHand.Position.Y  >= ARM_ABOVE_SHOLDER_MIN && (rightHand.Position.Y - shoulderCenter.Position.Y) >= ARM_ABOVE_SHOLDER_MIN)
            {
                elevatorStartTime = DateTime.Now;
                if (currentHeight != levels.six)
                {
                    switch (currentHeight)
                    {
                        //moves up.
                        case levels.baseLvl: currentHeight = levels.one; break;
                        case levels.one: currentHeight = levels.two; break;
                        case levels.two: currentHeight = levels.three; break;
                        case levels.three: currentHeight = levels.four; break;
                        case levels.four: currentHeight = levels.five; break;
                        case levels.five: currentHeight = levels.six; break;
                    }
                    i = 1;
                }
            } */
            /*else if ((shoulderZ - ARM_EXTENSION_DISTANCE >= leftHand.Position.Z) && (shoulderZ - ARM_EXTENSION_DISTANCE >= rightHand.Position.Z))
            {
                if (currentHeight != levels.baseLvl)
                {
                    switch (currentHeight)
                    {
                        //moves down
                        case levels.one: currentHeight = levels.baseLvl; break;
                        case levels.two: currentHeight = levels.one; break;
                        case levels.three: currentHeight = levels.two; break;
                        case levels.four: currentHeight = levels.three; break;
                        case levels.five: currentHeight = levels.four; break;
                        case levels.six: currentHeight = levels.five; break;
                    }
                    i = -1;
                }
            }
             
            progressBar1.Value += i;
            GlobalStuff.SendData('L', getPegInteger(currentHeight));
            elevatorStartTime = DateTime.Now;       
        } */
        int getPegInteger(levels input)
        {
            switch (input)
            {
                case levels.baseLvl:     return 0; 
                case levels.one:         return 1;
                case levels.two:         return 2;
                case levels.three:       return 3; 
                case levels.four:        return 4; 
                case levels.five:        return 5; 
                case levels.six:         return 6; 
            }
            return 23232; //never gets reached, just passed so that the compiler will shut up
        }
        bool clawState = true;
       
        void moveClaw(float leftKnee, float rightKnee)
        {
            const float MIN_DIST = 0.25f; //should later be scaled dynamically
            const float MAX_DIST = 0.40f;

            float kneeDistance = Math.Abs(leftKnee - rightKnee);
           //MessageBox.Show("" + kneeDistance + "\nShould be:\n" + MIN_DIST + "\n" + MAX_DIST);

            if (kneeDistance >= MIN_DIST && kneeDistance <= MAX_DIST)
            {
                //move claw, this checks out
                clawState = true;
                clawStartTime = DateTime.Now;
            }
            else { clawState = false; }
            clawLabel.Text = "Clawstate:\t" + clawState.ToString();
            int sendClawState = (clawState) ? 0 : 1;    //0 is open.
            GlobalStuff.SendData('K', sendClawState);
        }
        void changeDirection(Joint leftHand, Joint head)
        {
            const float MIN_THRESHOLD = 0.07f;
            const float MAX_THRESHOLD = 0.10f;

            float x = Math.Abs(leftHand.Position.X - head.Position.X);  //x and z is probably enough.
            float z = Math.Abs(leftHand.Position.Z - head.Position.Z);  //y is an extra param that we don't need.

            if (x >= MIN_THRESHOLD && x <= MAX_THRESHOLD && z >= MIN_THRESHOLD && z <= MAX_THRESHOLD)
            {
               // MessageBox.Show("Your hand is on your head.");
                changeDirectionStartTime = DateTime.Now;
                isMovingForward = !isMovingForward;
            }

            isForwardLabel.Text = "Direction:\t" + isMovingForward.ToString();  //label in gui
        }
        Joint selectHandFromBox(Joint left, Joint right)
        {
            Joint j = (useLeftHand.Checked) ? left : right;
            return j;
        }
        void spreadYourWingsAndFly(Joint leftHand, Joint rightHand, Joint leftShoulder, Joint rightShoulder, float headY)
        {
            //we pass in head because we don't want to accidentilly pull off an elevator.
         
            const float X_MIN = 0.55f;
            const float X_MAX = 0.75f;

            const float Z = 0.6f;

            //these vars are a bit redundant, but they simplify the coding and improve readibility
            float leftXRange = Math.Abs(leftHand.Position.X - leftShoulder.Position.X);
            float rightXRange = Math.Abs(rightHand.Position.X - rightShoulder.Position.X);
            float leftZRange = Math.Abs(leftHand.Position.Z - leftShoulder.Position.Z);
            float rightZRange = Math.Abs(rightHand.Position.Z - rightShoulder.Position.Z);

            bool leftXTest = (leftXRange >= X_MIN && leftXRange <= X_MAX) ? true : false;
            bool rightXTest = (rightXRange >= X_MIN && rightXRange <= X_MAX) ? true : false;
            bool yTest = (leftHand.Position.Y < headY && rightHand.Position.Y < headY) ? true : false;
            bool leftZTest = (leftZRange >= Z && leftZRange <= Math.Abs(Z)) ? true : false;
            bool rightZTest = (rightZRange >= Z && rightZRange <= Math.Abs(Z)) ? true : false;
            //remember, we want y test to fail...

            tankDrivePosition = getTankState(leftXTest, rightXTest, yTest, leftZTest, rightZTest);
            tankDirectionLabel.Text = tankDrivePosition.ToString();
            if (tankDrivePosition != wingState.kiwi)
                tankDriveDateTime = DateTime.Now;
        }
        wingState getTankState(bool leftx, bool rightx, bool y, bool leftz, bool rightz)
        {
            if (leftx && !rightx)
            {
                if (leftz)
                    return wingState.leftWing;
            }
            else if (rightx && !leftx)
            {
                if (rightz)
                    return wingState.rightWing;
            }
            else if (leftx && rightx && leftz && rightz)
                return wingState.fullThrottleTurbo;
            return wingState.kiwi;
        }
        bool isResetMode = false;
        void resetBot(Joint leftHand, Joint rightHand, Joint leftShoulder, Joint rightShoulder, Joint hipCenter)
        {

            //done with the const thing...
            float X_THRESHOLD = (leftShoulder.Position.X + rightShoulder.Position.X) / 2;
            float Y_MIN = hipCenter.Position.Y;
            float Y_MAX = (leftShoulder.Position.Y + rightShoulder.Position.Y) /2;  //compiler won't let this be final.
            const float Z_THRESHOLD = 0.40f;
            
            float x1 = Math.Abs(leftShoulder.Position.X - leftHand.Position.X);
            float x2 = Math.Abs(rightShoulder.Position.X - rightHand.Position.X);

            float y = ((Math.Abs(leftHand.Position.Y + rightHand.Position.Y))/2);

            bool xTest = (leftHand.Position.X > leftShoulder.Position.X && leftHand.Position.X < rightShoulder.Position.X && rightHand.Position.X > leftShoulder.Position.X && rightHand.Position.X < rightShoulder.Position.X) ? true : false;
            bool yTest = (y > Y_MIN || y < Y_MAX) ? true : false;   //placeholder for time being...

            //if average shoulder to hand z measurements is greater than some z value.

            bool zTest = (((Math.Abs(leftHand.Position.Z - leftShoulder.Position.Z) + Math.Abs(rightHand.Position.Z - rightShoulder.Position.Z)) / 2) > Z_THRESHOLD) ? false : true;

            if (xTest && yTest && zTest)
            {
                isResetMode = true;
               // MessageBox.Show(isResetMode.ToString());
                    isResetMode = true;
                    //reset claw
                    clawState = false;
                           //send packets
                    GlobalStuff.SendData('K', 1);
                    currentHeight = levels.baseLvl;
                    progressBar1.Value = 0;
              //      GlobalStuff.SendData('L', 0);
                    //reset method delays.
               
            }
            resetLabel.Text = "In Reset Mode:\t" + isResetMode.ToString();
        }

    }
}