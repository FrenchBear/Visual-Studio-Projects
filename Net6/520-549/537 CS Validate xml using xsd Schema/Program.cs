// 2021-09-26   PV      VS2022; Net6

using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;

namespace ValidateSchema
{
    internal class Program
    {
        private static void Main()
        {
            XmlReaderSettings roundingInfosSettings = new();
            roundingInfosSettings.Schemas.Add("http://tempuri.org/RoundingInfos.xsd", "roundingInfos.xsd");
            roundingInfosSettings.ValidationType = ValidationType.Schema;
            roundingInfosSettings.ValidationEventHandler += new ValidationEventHandler(RoundingInfosSettingsValidationEventHandler);

            XmlReader roundingInfos = XmlReader.Create("RoundingInfos-1.e5r", roundingInfosSettings);

            while (roundingInfos.Read())
            {
                Console.Write(roundingInfos.NodeType + " ");
                if (roundingInfos.NodeType == XmlNodeType.Element || roundingInfos.NodeType == XmlNodeType.EndElement)
                    Console.Write(roundingInfos.Name);
                Console.WriteLine();
            }
        }

        private static void RoundingInfosSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
            Debugger.Break();
        }
    }
}