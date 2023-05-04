using System.Xml.Serialization;

namespace AcmeWebUI.Models
{
    [XmlRoot(ElementName = "EnvioPedidoAcme", Namespace = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme")]
    public class EnvioPedidoAcme
    {
        [XmlElement(ElementName = "EnvioPedidoRequest", Namespace = "")]
        public List<Pedido> EnvioPedidoRequest { get; set; } = new List<Pedido>();
    
    }

    public class Header 
    {
    
    }
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "EnvioPedidoAcme", Namespace = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme")]
        public EnvioPedidoAcme EnvioPedido { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; } = new Header();

        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }


    }

}
