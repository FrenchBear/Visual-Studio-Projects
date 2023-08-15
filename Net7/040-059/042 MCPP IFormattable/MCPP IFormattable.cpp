// Essais de formateurs en C++
//
// 2001-02-18	PV
// 2006-10-01	PV		Version VS 2005
// 2012-02-25   PV		VS2010
// 2017-04-30	PV		VS2017; Git
// 2021-09-18   PV		VS2022, Net6
// 2023-01-10	PV		Net7

#include "stdafx.h"

using namespace System;

value class Complexe : public IFormattable
{
private:
	double r, i;

public:
	Complexe(double r, double i)
	{
		this->r = r;
		this->i = i;
	}

	virtual String^ ToString() override
	{
		return String::Concat("(", r.ToString(), ";", i.ToString(), ")");
	}

	virtual String^ ToString(String^ sFormat, IFormatProvider^ fp)
	{
		if (String::IsNullOrEmpty(sFormat)) return this->ToString();

		if (String::Compare(sFormat->ToLower(), "p") == 0)
			return  String::Concat("[", (Math::Sqrt(i * i + r * r)).ToString(), ";", (Math::Atan2(i, r) / Math::PI * 180).ToString(), "]");

		return ToString();
	}
};

// This is the entry point for this application
int main(array<System::String^>^ args)
{
	Console::WriteLine("{0:N0}", System::Int16::MaxValue);
	Console::WriteLine("{0:N0}", System::Int32::MaxValue);
	Console::WriteLine("{0:N0}", System::Int64::MaxValue);

	Complexe c(1, 1);
	Console::WriteLine("{0}", c.ToString());
	Console::WriteLine("{0}", (Object^)c);
	Console::WriteLine("{0:P}", (Object^)c);

	Console::Write("\n(pause) ");
	Console::ReadLine();
	return 0;
}
