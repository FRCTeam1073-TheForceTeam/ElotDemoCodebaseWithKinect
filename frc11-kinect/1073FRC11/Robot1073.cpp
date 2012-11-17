//////////////////////////////////////////////////////////
// Filename: Robot1073.cpp
// Author:   
// Date:     January 23, 2011
//
// Description: This file contains the main defintion for the Team1073 Robot.
//
///////////////////////////////////////////////////////////
#include "Robot1073.h"

const float initialCameraServoPosition = .60f;

Robot1073::Robot1073(void)
: targetPole(2),targetFoot(3)
{	
	std::cout <<"\n\n\n";
	for(int i = 0; i < 50; i++) std::cout<< "==";
	std::cout << "Welcome to Elot's Demo Mode!\n\n";
	std::cout <<"\tThis version of the code is lightwieght and optimized for "
			<< "heavy use in non-competitive environments. It gives users:\n"
			<< "\t>A Complete teleoperated mode\n"
			<< "\t>Kinect Support with KinectGestureLib that is integrated into "
			<< "the project's dashboard\n"
			<< "\t>No autonomous to avoid crashes and confusion.\n\n";
	
	
	cameraManager = NULL;
	camera = NULL;
	

	driverStation = DriverStation::GetInstance();
	
	systemTimer = new Timer();
	systemTimer->Reset();
	systemTimer->Start();
	
	matchTimer = new MatchTimer();
	

	// main Robot Instantiations from UserIncludes
	leftMotorJaguar = new SmartJaguarMotorEncoder(CAN_LeftMotorAddress, DriveWheelPulsesPerFoot, IsLeftMotorReversed, IsLeftEncoderReversed);
	rightMotorJaguar = new SmartJaguarMotorEncoder(CAN_RightMotorAddress, DriveWheelPulsesPerFoot, IsRightMotorReversed, IsRightEncoderReversed);
	
	
	// Reset the encoders on the drive train Jags
	leftMotorJaguar->ResetEncoder();
	rightMotorJaguar->ResetEncoder();
	
	pincerJaguar = new SmartJaguarMotorEncoder(CAN_PincerMotorAddress, 0, IsPincerMotorReversed);
	armJaguar = new SmartJaguarMotorEncoder(CAN_ElevatorArmMotorAddress, 0, IsArmMotorReversed);
	
	elevatorJaguarMotorA = new SmartJaguarMotorEncoder(CAN_ElevatorUpDownAMotorAddress, ElevatorPulsesPerFoot, false, true);
	
	// Only the "A" motor has an optical encoder
	elevatorJaguarMotorA->ResetEncoder();

	
	retroIlluminator = new Victor(PWM_RetroIlluminator);
	rollerRelay = new Relay(RELAY_PincerRoller);
	elevatorBrakeServo = new Servo(PWM_ElevatorBrakeServo);
	minibotFirstStageServo = new Servo(PWM_MinibotFirstStageServo);
	minibotSecondStageServo = new Servo(PWM_MinibotSecondStageServo);
	
	// Should rev
	leftJoystick = new SmartJoystick(USB_LeftJoystickPort);
	rightJoystick = new SmartJoystick(USB_RightJoystickPort);
	operatorJoystick = new SmartJoystick(USB_OperatorJoystickPort);
	
	gyro = new SmartGyro(ANALOG_GyroPort);
	gyro->Reset();
	
	cameraServo = new Servo(PWM_ChassisCamera);
	cameraServo->Set(initialCameraServoPosition);
	
	leftLineSensor = new DigitalInput(DIO_LeftLightSensorPort);
	middleLineSensor = new DigitalInput(DIO_MiddleLightSensorPort);
	rightLineSensor = new DigitalInput(DIO_RightLightSensorPort);
	scopeLoop = new DigitalOutput(DIO_ScopeLoopTest);
	
	magEncoder = new AnalogChannel(ANALOG_ElevatorArmMagneticEncoder);
	magPincerEncoder = new AnalogChannel(ANALOG_PincerMagneticEncoder);
	
	encoders = new Encoders1073(gyro, leftMotorJaguar, rightMotorJaguar);
	
	pincer = new Pincer(pincerJaguar, rollerRelay, magPincerEncoder, operatorJoystick);
	elevator = new Elevator(elevatorJaguarMotorA, elevatorBrakeServo, operatorJoystick);
	arm = new Arm(armJaguar, operatorJoystick, magEncoder);
	
	navigation = new Navigation(encoders, gyro);
	drive = new LNDrive(leftMotorJaguar, rightMotorJaguar, leftJoystick, rightJoystick, navigation, encoders, gyro);
	lineFollower = new LineFollower(drive, leftJoystick, rightJoystick, leftLineSensor, middleLineSensor, rightLineSensor, leftMotorJaguar, navigation);
	minibot = new Minibot(minibotFirstStageServo, minibotSecondStageServo, rightJoystick, operatorJoystick, arm, pincer);// .33333333333333333333333
	dashboardSender = new DashboardSender();
	dashboardReceiver = new DashboardReceiver();
	driverMessages = new DriverMessages();
	
	//Release the Kraken!
	kraken = new KrakenDrive(this);
	
	SetTargetPoleAndFoot(targetPole, targetFoot);
	
	// Launch the background thread....
	InitializeTheZombieZone(this);
	InitializeDashboardReceiverThread(this, dashboardReceiver);
	
}

void Robot1073::OperatorControl(void)
{
	encoders->ResetEncoders();
	float initial_gyro = gyro->GetAngle();
	
	retroIlluminator->Set(1.0);

	printf("Left Jag current control mode = %d\n", leftMotorJaguar->GetControlMode() );
	printf("Gyro is %lf\n", initial_gyro);
	
	matchTimer->StartOperator();
	while (IsOperatorControl() /*&& IsEnabled()  */) 
	{
		DoPeriodicServiceFunctions();	
		Wait(WaitTime);				// wait for a motor update time
	}
	
	retroIlluminator->Set(0);
	
	float final_gyro = gyro->GetAngle();
	printf("Exiting OperatorControl() Gyro is %lf, difference %lf\n", final_gyro, final_gyro - initial_gyro );

}

void Robot1073::DoPeriodicServiceFunctions()
{
		bool isTestMode = rightJoystick->GetRawButton(DriverMessagesTestButton);
		bool minibotDeploying = rightJoystick->GetRawButton(MinibotSafetyButton);
		
		if(isTestMode)
		{
			return;
		}
		
		if(minibotDeploying)
		{
			minibot->PeriodicService();
			drive->PeriodicService();
			elevator->PeriodicService();
			arm->PeriodicService();
			
			return;
		}

		if(IsOperatorControl())
			drive->PeriodicService();	// Drive Only in tele mode..
		
		
		elevator->PeriodicService();
		arm->PeriodicService();  
		pincer->PeriodicService();
		kraken->PeriodicService();
#ifdef  _MSC_VER
		// Simulation Hack!
		drive->SimulationHack();
		// Simulation Only to flush stdio stuff such that it can be monitored..
		fflush(stdout);
		
#endif
}


void Robot1073::ZombieZonePeriodicService()
{
		// Don't send data until dashboard is in sync w/robot code dashboardSender->SendData(this);
	
	scopeLoop->Set(true);
	driverMessages->PeriodicService(this);
	scopeLoop->Set(false);
	dashboardSender->SendData(this);
	scopeLoop->Set(true);
	navigation->PeriodicService();
	scopeLoop->Set(false);
}

void Robot1073::SetTargetPoleAndFoot(int polePos, int footPos)
{
	// Clip at setpoints to within the allowed possible range or else bad things happen...
	if(polePos >6) polePos = 6;
	if(polePos <1) polePos = 1;
	if(footPos >3) footPos = 3;
	if(footPos <1) footPos = 1;
	
	targetPole = polePos;		// Store the current Pole target (1-6)
	targetFoot = footPos;		// and foot target	(1-3)

#if 1
		if(polePos == 2 || polePos == 5)
		{
			lineFollower->retroTape = false;
		}
		else 
		{
			lineFollower->retroTape = true;
		}
#endif
	
	elevator->UpdateTargetPoleAndFoot(targetPole, targetFoot);
	kraken->UpdateTargetPole(targetPole);
	kraken->UpdateTargetFoot(targetFoot);
	navigation->StartPositionRobotToColumn(targetPole);
	if(!navigation->GetHasStarted())
		navigation->SetStartPosition();

}

START_ROBOT_CLASS(Robot1073);
