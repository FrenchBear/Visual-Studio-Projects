// This is the main project file for VC++ application project
// generated using an Application Wizard.
// //
// 2001 PV
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

#using <mscorlib.dll>

using namespace System;

class MaClasseDeBase
{
public:
	MaClasseDeBase()
	{
	}

	~MaClasseDeBase()
	{
	}

	virtual void MaMethode()
	{
		Console::WriteLine("MaClasseDebase::MaMethode");
	}
};

class MaClasse : public MaClasseDeBase
{
public:
	MaClasse()
	{
	}

	~MaClasse()
	{
	}

	virtual void MaMethode()
	{
		Console::WriteLine("MaClasse::MaMethode");
	}
};

void Zap2(MaClasseDeBase* b)
{
	b->MaMethode();
}

void Zap()
{
	MaClasse c;
	MaClasseDeBase b;

	Zap2(&b);
	Zap2(&c);
}

// This is the entry point for this application
int main(void)
{
	Zap();
	Console::WriteLine("Hello World");

	Console::Write("\n(pause) ");
	Console::ReadLine();
	return 0;
}
