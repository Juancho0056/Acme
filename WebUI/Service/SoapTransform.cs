using AcmeWebUI.Models;
using AcmeWebUI.Response;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AcmeWebUI.Service
{
    public static class SoapTransform
    {
        public static string Transformar(string soapResponse, string nodo) => QuitarEspaciosNombre(XElement.Parse(soapResponse)).LimpiarXml().ToJson(nodo);

        
        
       static string QuitarEspaciosNombre(XElement xml) 
       {
            try
            {
                if (!xml.HasElements) 
                {
                    var element = new XElement(xml.Name.LocalName);
                    element.Value = xml.Value;

                    foreach (var attribute in xml.Attributes())
                    {
                        element.Add(attribute);
                    }
                    return element.ToString();
                }
                return new XElement(xml.Name.LocalName, xml.Elements().Select(x => QuitarEspaciosNombre(x))).ToString();
            }
            catch (Exception)
            {
                throw;
            } 
       }

        static string LimpiarXml(this string response) => response.Replace("amp;", "").Replace("&lt;", "<").Replace("&gt;", ">");

        static string ToJson(this string response, string nodo) 
        {


            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(response)))
            {

                using (var reader = new StreamReader(stream))
                {
                    var xmlDoc = XDocument.Load(reader);
                    var xmlSerializer = new XmlSerializer(typeof(Response.Envelope));
                   
                    XName ns = nodo;
                    var codigoNodo = xmlDoc.Descendants(ns).FirstOrDefault();
                    return JsonConvert.SerializeXNode(codigoNodo);    
                }
            }
        }
        
    }
}
