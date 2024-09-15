// 527 CS List Serialization
// Example of serialization and deserialization of a list
//
// 2015-04-15   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace CS527;

internal class Program
{
    private static void Main(string[] args)
    {
        // Prepare data
        var groupsList = new List<LauncherGroup>
        {
            new() { Name = "Group 1", SquaresList = [new() { Name = "Square 1.1", Image = "Image 1.1" }, new() { Name = "Square 1.2", Image = "Image 1.2" }] },
            new() { Name = "Group 2", SquaresList = [new() { Name = "Square 2", Image = "Image 2" }] },
            new() { Name = "Group 3", SquaresList = [new() { Name = "Square 3.1", Image = "Image 3.1" }, new() { Name = "Square 3.2", Image = "Image 3.2" }, new() { Name = "Square 3.3", Image = "Image 3.3" }] }
        };

        LauncherConfiguration configuration = new() { GoupsList = groupsList };

        var menuFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LauncherMenus.xml");
        XmlSerializer serializer = new(typeof(LauncherConfiguration));
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");

        // Write
        XmlWriterSettings settings = new()
        {
            //settings.OmitXmlDeclaration = true;
            Indent = true
        };
        using (var writer = XmlWriter.Create(menuFile, settings))
        {
            writer.WriteStartElement("MicrobiologyLauncherMenus");
            writer.WriteAttributeString("version", "1");
            serializer.Serialize(writer, configuration, ns);
            writer.WriteEndElement();
        }

        // Read
        LauncherConfiguration configuration2;
        using var reader = XmlReader.Create(menuFile);
        do
            _ = reader.Read();
        while (reader.NodeType != XmlNodeType.Element);
        if (reader.Name != "MicrobiologyLauncherMenus")
            Debugger.Break();
        if (reader.GetAttribute("version") != "1")
            Debugger.Break();
        ;
        _ = reader.Read();
        configuration2 = (LauncherConfiguration)serializer.Deserialize(reader);
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
