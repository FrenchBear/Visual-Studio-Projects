// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2017-04-30	PV		VS2017, Git
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

// This is the main DLL file.

#using <mscorlib.dll>

namespace Mixte20
{
#include "ClasseC.h"

	C::C()
	{
		System::Console::WriteLine("C.ctor");
	}
}

