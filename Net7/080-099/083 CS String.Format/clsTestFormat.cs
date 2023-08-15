// 83 CS Format
// Tests de String.Format
// 2003-08-03   PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
//
// The format parameter is embedded with zero or more format items of the form, {index[,alignment][:formatString]}, where:
//
// index
//   A zero-based integer that indicates which element in a list of objects to format.
//   The mandatory index component, also called a parameter specifier, is a number starting from 0 that identifies
//   a corresponding element in the list of values. That is, the format item whose parameter specifier is 0 formats
//   the first value in the list, the format item whose parameter specifier is 1 formats the second value in the list,
//   and so on.
//   Multiple format items can refer to the same element in the list of values by specifying the same parameter specifier.
//   For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying
//   a source string like this: "{0:X} {0:E} {0:N}".
//   Each format item can refer to any parameter. For example, if there are three values, you can format the second,
//   first, and third value by specifying a source string like this: "{1} {0} {2}". A value that is not referenced
//   by a format item is ignored. A runtime exception results if a parameter specifier designates an item outside
//   the bounds of the list of values.
//
// alignment
//   An optional integer indicating the minimum width of the region to contain the formatted value. If the length of the
//   formatted value is less than alignment, then the region is padded with spaces. If alignment is negative, the formatted
//   value is left justified in the region; if alignment is positive, the formatted value is right justified. If alignment
//   is not specified, the length of the region is the length of the formatted value.
//   The comma is required if alignment is specified.
//
// formatString
//   An optional string of formatting codes. If formatString is not specified and the corresponding argument implements
//   the IFormattable interface, then a null reference (Nothing) is used as the IFormattable.ToString format string.
//   Therefore, all implementations of IFormattable.ToString are required to allow a null reference (Nothing) as
//   a format string, and return default formatting of the object representation as a String.
//   If formatString is not specified, the general ("G") format specifier is used.
//   The colon is required if formatString is specified.
//
//
// Processing Order
//   If the value to be formatted is null (Nothing in Visual Basic), an empty string ("") is returned.
//   If the type to be formatted implements the ICustomFormatter interface, the ICustomFormatter.Format method is called.
//   If the preceding step does not format the type, and the type implements the IFormattable interface,
//   the IFormattable.ToString method is called.
//	 If the preceding step does not format the type, the type's ToString method, which is inherited from the Object class,
//   is called.
//   Alignment is applied after the preceding steps have been performed.
//
// The leading and trailing brace characters, '{' and '}', are required. To specify a single literal brace character
// in format, specify two leading or trailing brace characters; that is, "{{" or "}}".
// 2023-01-10	PV		Net7

using System;
using System.Globalization;
using System.Threading;
using static System.Console;

internal readonly struct Complex: IFormattable
{
    private readonly double x, y;

    public Complex(double r, double i)
    {
        x = r;
        y = i;
    }

    #region Membres de IFormattable

    public string ToString(string format, IFormatProvider formatProvider)
    {
        format ??= "G";     // if (format == null) format = "G";

        var cFormat = format[..1].ToUpper().ToCharArray()[0];

        return cFormat switch
        {
            'P' => "<" + Math.Sqrt(x * x + y * y) + ";" + Math.Atan2(y, x) + ">",
            _ => "[" + x + ";" + y + "]",
        };
    }

    #endregion Membres de IFormattable
}

internal class TestFormat
{
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        DoOutput("Formats généraux d'entiers", 0xcafe, new string[] { "{0:G}", "{0:00000000}", "{0:########}", "{0,10}", "{0:d8}", "{0:x}", "{0:x8}", "{0:X}", "{0:n}", "{0:n0}" });
        DoOutput("Format spécifiques d'entiers", 1234567, new string[] { "{0:#,##0}", "{0:0,}", "{0:#,##0,}", "{0:0.00%}", "{0:[##-##-##]}" });
        DoOutput("Formats de décimaux", 3141.5926, new string[] { "{0:G}", "{0,12}", "{0:e}", "{0:f3}", "{0:C}", "{0:n1}", "{0:p}", "{0:p1}", "{0:r}" });
        DoOutput("Formats de dates", DateTime.Now, new string[] { "{0:dddd dd MMMM yyyy}", "{0:dd/MM/yy}", "{0:hh:mm:ss}" });
        DoOutput("Formats de types spécifiques", new Complex(1, 2), new string[] { "{0}", "{0:P}", "{0:R}" });

        WriteLine("Plusieurs sections: format 0.00;(0.00);Zero");
        WriteLine("{0,-20}|{1}|", "1.234", $"{1.234:0.00;(0.00);Zero}");
        WriteLine("{0,-20}|{1}|", "-1.234", $"{-1.234:0.00;(0.00);Zero}");
        WriteLine("{0,-20}|{1}|", "0", $"{0:0.00;(0.00);Zero}");
        WriteLine();

        DoOutput("Format spécifiques d'entiers", 1234567, new string[] { "{0:#,##0}", "{0:0,}", "{0:#,##0,}", "{0:0.00%}" });

        WriteLine("Passage en culture US");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
        DoOutput("Formats de décimaux", 3141.5926, new string[] { "{0:G}", "{0:C}" });
        DoOutput("Formats de dates", DateTime.Now, new string[] { "{0:dddd dd MMMM yyyy}" });

        //Console.ReadLine();
    }

    private static void DoOutput(string sTitre, object o, string[] tFormat)
    {
        WriteLine(sTitre);
        foreach (var sFormat in tFormat)
        {
            WriteLine("{0,-20}|{1}|", sFormat, string.Format(sFormat, o));
        }
        WriteLine();
    }
}
