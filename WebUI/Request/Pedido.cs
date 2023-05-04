using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AcmeWebUI.Models
{
    
    public class Pedido
    {
        [XmlElement(ElementName ="pedido", Namespace ="")]
        public int numPedido { get; set; }
        [XmlElement(ElementName = "Cantidad", Namespace = "")]
        public int cantidadPedido { get; set; }
        
        [XmlElement(ElementName = "EAN", Namespace = "")]
        public string codigoEAN { get; set; } = string.Empty;

        
        [XmlElement(ElementName = "Producto", Namespace = "")]
        public string nombreProducto { get; set; } = string.Empty;

        
        [XmlElement(ElementName = "cedula", Namespace = "")]
        public string numDocumento { get; set; } = string.Empty;

        
        [XmlElement(ElementName = "direccion", Namespace = "")]
        public string direccion { get; set; } = string.Empty;
        


    }
}
