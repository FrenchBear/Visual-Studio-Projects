// 527 CS List Serialization
// Example of serialization and deserialization of a list
// 2015-04-15 FPVI

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SerCol
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare data
            List<LauncherGroup> groupsList;
            groupsList = new List<LauncherGroup>();
            groupsList.Add(new LauncherGroup { name = "Group 1", SquaresList = new List<LauncherSquare> { new LauncherSquare { name = "Square 1.1", image = "Image 1.1" }, new LauncherSquare { name = "Square 1.2", image = "Image 1.2" } } });
            groupsList.Add(new LauncherGroup { name = "Group 2", SquaresList = new List<LauncherSquare> { new LauncherSquare { name = "Square 2", image = "Image 2" } } });
            groupsList.Add(new LauncherGroup { name = "Group 3", SquaresList = new List<LauncherSquare> { new LauncherSquare { name = "Square 3.1", image = "Image 3.1" }, new LauncherSquare { name = "Square 3.2", image = "Image 3.2" }, new LauncherSquare { name = "Square 3.3", image = "Image 3.3" } } });

            LauncherConfiguration Configuration = new LauncherConfiguration { GoupsList = groupsList };

            string MenuFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LauncherMenus.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(LauncherConfiguration));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // Write
            XmlWriterSettings settings = new XmlWriterSettings();
            //settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(MenuFile, settings))
            {
                writer.WriteStartElement("MicrobiologyLauncherMenus");
                writer.WriteAttributeString("version", "1");
                serializer.Serialize(writer, Configuration, ns);
                writer.WriteEndElement();
            }


            // Read
            LauncherConfiguration Configuration2;
            using (XmlReader reader = XmlReader.Create(MenuFile))
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
        public string name { get; set; }
        public List<LauncherSquare> SquaresList;
    }

    public class LauncherSquare
    {
        public string name { get; set; }
        public string image { get; set; }
    }

}


