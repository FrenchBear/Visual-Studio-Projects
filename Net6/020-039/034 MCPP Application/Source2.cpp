#using <mscorlib.dll>

using namespace System;

ref class k1
{
};

ref class BaseClass
{
public:
	int PublicFunc()
	{
		return 0;
	}
protected:
	int ProtectedFunc()
	{
		return 0;
	}
private:
	int PrivateFunc()
	{
		return 0;
	}
};

ref class DerivedClass1 : public BaseClass
{ };

/*
class DerivedClass2 : private BaseClass
{ };

class DerivedClass3 : protected BaseClass
{ };
*/