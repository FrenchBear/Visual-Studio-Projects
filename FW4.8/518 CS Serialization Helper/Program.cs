// 518 CS Serialization Helper
// Example of serialization in memory
// From http://stackoverflow.com/questions/1564718/using-stringwriter-for-xml-serialization
// 2014-02-14   PV

using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS518
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new Ba
            {
                Val = 25
            };

            string s1 = Serialize<Ba>(x);
            string s2 = x.ToXmlString();
            Debugger.Break();
        }

        public static string Serialize<T>(T value)
        {
            if (value == null)
                return null;

            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlWriterSettings
            {
                Encoding = new UnicodeEncoding(false, false), // no BOM in a .NET string
                Indent = true,
                OmitXmlDeclaration = false
            };

            using (var textWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return default;

            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlReaderSettings();
            // No settings need modifying here

            using (var textReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }

    // Extension method
    public static class XmlTools
    {
        public static string ToXmlString<T>(this T input)
        {
            using (var writer = new StringWriter())
            {
                input.ToXml(writer);
                return writer.ToString();
            }
        }

        public static void ToXml<T>(this T objectToSerialize, Stream stream) => new XmlSerializer(typeof(T)).Serialize(stream, objectToSerialize);

        public static void ToXml<T>(this T objectToSerialize, StringWriter writer) => new XmlSerializer(typeof(T)).Serialize(writer, objectToSerialize);
    }

    public class Ba
    {
        private int _val = 42;

        [DefaultValue(42)]      // Avoid serialization of default value
        public int Val
        {
            get => _val;
            set => _val = value;
        }
    }
}