//////////////////////////////////////////////////////////
// Filename: Autonomous.cpp
// Author:   
// Date:     February 2, 2011
// 
// Description: This file contains the main definition for the Team1073 Robot.
//
//////////////////////////////////////////////////////////
#include "Robot1073.h"
void Robot1073::Autonomous(void)
{
	
	encoders->ResetEncoders();
	
	matchTimer->StartAutonomous();
	navigation->SetStartPosition();
	navigation->Start();
	
	while (IsAutonomous())
	{
		puts("Logomotion Autonomous is Nonexistant in Elot's Demo Mode...");
		break;
	}
	kraken->StopAll();
}
