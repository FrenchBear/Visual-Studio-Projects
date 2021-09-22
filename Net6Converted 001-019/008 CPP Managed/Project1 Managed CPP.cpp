// 008 CPP Managed
// This is the main project file for VC++ application project generated using an Application Wizard.
//
// 2001 PV
// 2006-10-01	PV	VS2005
// 2012-02-25   PV  VS2010
// 2017-04-30	PV	VS2017

#using <mscorlib.dll>

using namespace System;

// This is the entry point for this application
int main(void)
{
	// TODO: Please replace the sample code below with your own.
	Console::WriteLine("Hello World");

	int j;
	int a[10];

	j = 3;
	a[12] = 0;		// Baaaaaad !

	Console::Write("\n(pause) ");
	Console::ReadLine();
	return 0;
}