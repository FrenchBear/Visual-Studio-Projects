﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ValidateSchema
{
    class Program
    {
        static void Main()
        {
            XmlReaderSettings roundingInfosSettings = new XmlReaderSettings();
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


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static void RoundingInfosSettingsValidationEventHandler(object sender, ValidationEventArgs e)
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
