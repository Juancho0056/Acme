using Microsoft.Net.Http.Headers;
using System.Text;

namespace AcmeWebUI.Helpers
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
        
    }
}
