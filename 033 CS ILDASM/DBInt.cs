using System;

#pragma warning disable 1591

namespace MaBibliotheque
{
    public struct DBInt
    {
        public static readonly DBInt Null = new DBInt();
        private int value;
        private bool defined;

        public bool IsNull { get { return !defined; } }

        DBInt(int x)
        {
            value = x;
            defined = true;
        }

        public static DBInt operator +(DBInt x, DBInt y)
        {
            if (!x.defined || !y.defined) return Null;
            return new DBInt(x.value + y.value);
        }

        public static implicit operator DBInt(int x)
        {
            return new DBInt(x);
        }

        public static explicit operator int(DBInt x)
        {
            if (x.defined)
                return x.value;
            else
                throw new Exception("Valeur NULL");
        }

        public override string ToString()
        {
            if (defined)
                return value.ToString();
            else
                return "<NULL>";
        }
    }
}