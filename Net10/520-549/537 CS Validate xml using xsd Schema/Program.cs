// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using static System.Console;

namespace CS537;

internal class Program
{
    private static void Main()
    {
        XmlReaderSettings roundingInfosSettings = new();
        _ = roundingInfosSettings.Schemas.Add("http://tempuri.org/RoundingInfos.xsd", "roundingInfos.xsd");
        roundingInfosSettings.ValidationType = ValidationType.Schema;
        roundingInfosSettings.ValidationEventHandler += new ValidationEventHandler(RoundingInfosSettingsValidationEventHandler);

        var roundingInfos = XmlReader.Create("RoundingInfos-1.e5r", roundingInfosSettings);

        while (roundingInfos.Read())
        {
            Write(roundingInfos.NodeType + " ");
            if (roundingInfos.NodeType is XmlNodeType.Element or XmlNodeType.EndElement)
                Write(roundingInfos.Name);
            WriteLine();
        }
    }

    private static void RoundingInfosSettingsValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
        {
            Write("WARNING: ");
            WriteLine(e.Message);
        }
        else if (e.Severity == XmlSeverityType.Error)
        {
            Write("ERROR: ");
            WriteLine(e.Message);
        }
        Debugger.Break();
    }
}
