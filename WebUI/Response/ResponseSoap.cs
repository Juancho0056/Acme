using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AcmeWebUI.Models;

namespace AcmeWebUI.Response
{
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "EnvioPedidoAcmeResponse", Namespace = "http://WSDLs/EnvioPedidos/")]
        public EnvioPedidoAcmeResponse EnvioPedidoAcmeResponse { get; set; }
    }
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; } = new Header();

        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
    }
    [XmlRoot(ElementName = "EnvioPedidoAcmeResponse", Namespace = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme")]
    public class EnvioPedidoAcmeResponse
    {
        [XmlElement(ElementName = "EnvioPedidoResponse", Namespace = "")]
        public EnvioPedidoResponse EnvioPedidoResponse { get; set; }
    }

    public class EnvioPedidoResponse
    {
        
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
    }

    //public class ResponseSoap
    //{
    //    public Envelope Envelope { get; set; }
    //}

}
