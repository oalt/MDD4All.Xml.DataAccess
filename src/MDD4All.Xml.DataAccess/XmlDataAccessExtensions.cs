using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MDD4All.Xml.DataAccess
{
    public static class XmlDataAccessExtensions
    {
        public static string SerializeToXml<T>(this T objectToSerialize)
        {
            string result = string.Empty;

            try
            {
                using (StringWriter stringwriter = new StringWriter())
                {
                    XmlWriter xmlWriter = XmlWriter.Create(stringwriter, new XmlWriterSettings
                    {
                        OmitXmlDeclaration = true,
                        ConformanceLevel = ConformanceLevel.Auto,
                        Indent = true
                    });

                    XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                    xmlSerializerNamespaces.Add("", "");

                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(xmlWriter, objectToSerialize, xmlSerializerNamespaces);
                    result = stringwriter.ToString();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return result;
        }
    }
}
