using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AcmeWebUI.Helpers
{
    public static class XmlHelper
    {
        public static string Serialize<T>(this T obj) 
        {
            string xml = string.Empty;
            XmlSerializer serializer= new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true,
            };
            using (var stringWriter = new Utf8StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                    ns.Add("env", "http://WSDLs/EnvioPedidos/EnvioPedidosAcme");
                    ns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                    serializer.Serialize(xmlWriter, obj, ns);
                    xml = stringWriter.ToString();
                }

            }
            return xml;
        }
    }
}
