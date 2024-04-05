// 527 CS List Serialization
// Example of serialization and deserialization of a list
// 2015-04-15 FPVI

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace SerCol
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Prepare data
            List<LauncherGroup> groupsList;
            groupsList = new List<LauncherGroup>
            {
                new LauncherGroup { Name = "Group 1", SquaresList = new List<LauncherSquare> { new LauncherSquare { Name = "Square 1.1", Image = "Image 1.1" }, new LauncherSquare { Name = "Square 1.2", Image = "Image 1.2" } } },
                new LauncherGroup { Name = "Group 2", SquaresList = new List<LauncherSquare> { new LauncherSquare { Name = "Square 2", Image = "Image 2" } } },
                new LauncherGroup { Name = "Group 3", SquaresList = new List<LauncherSquare> { new LauncherSquare { Name = "Square 3.1", Image = "Image 3.1" }, new LauncherSquare { Name = "Square 3.2", Image = "Image 3.2" }, new LauncherSquare { Name = "Square 3.3", Image = "Image 3.3" } } }
            };

            var Configuration = new LauncherConfiguration { GoupsList = groupsList };

            string MenuFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LauncherMenus.xml");
            var serializer = new XmlSerializer(typeof(LauncherConfiguration));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // Write
            var settings = new XmlWriterSettings
            {
                //settings.OmitXmlDeclaration = true;
                Indent = true
            };
            using (var writer = XmlWriter.Create(MenuFile, settings))
            {
                writer.WriteStartElement("MicrobiologyLauncherMenus");
                writer.WriteAttributeString("version", "1");
                serializer.Serialize(writer, Configuration, ns);
                writer.WriteEndElement();
            }

            // Read
            LauncherConfiguration Configuration2;
            using (var reader = XmlReader.Create(MenuFile))
            {
                do
                    reader.Read();
                while (reader.NodeType != XmlNodeType.Element);
                if (reader.Name != "MicrobiologyLauncherMenus") Debugger.Break();
                if (reader.GetAttribute("version") != "1") Debugger.Break(); ;
                reader.Read();
                Configuration2 = (LauncherConfiguration)serializer.Deserialize(reader);
            }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    public class LauncherConfiguration
    {
        public List<LauncherGroup> GoupsList;
    }

    public class LauncherGroup
    {
        public string Name { get; set; }
        public List<LauncherSquare> SquaresList;
    }

    public class LauncherSquare
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}