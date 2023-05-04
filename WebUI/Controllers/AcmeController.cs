
using AcmeWebUI.Helpers;
using AcmeWebUI.Models;
using AcmeWebUI.Response;
using AcmeWebUI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AcmeWebUI.Controllers
{

    public class AcmeController : ApiControllerBase
    {
        /// <summary>
        /// B.	Realizar transformación de la petición de json a xml
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult> EnviarAcmeB([FromBody]List<Pedido> pedidos)
        {
          
            var soapRequest = new EnvioPedidoAcme()
            {
                EnvioPedidoRequest = pedidos
            };
            Models.Envelope env = new Models.Envelope()
            { 
                Body = new Models.Body() 
                {
                    EnvioPedido = soapRequest
                }
            };

          
            return Ok(env.Serialize());
        }
        /// <summary>
        /// C.	Realizar transformación de la respuesta de xml a json
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult> ConsultarAcmeC()
        {

            using (var client = new HttpClient())
            {
                var content = new StringContent("text/xml");
                var actionUrl = "http://WSDLs/EnvioPedidos/EnvioPedidosAcme";

                client.DefaultRequestHeaders.Add("SOAPAction", actionUrl);
                using (var response = await client.PostAsync("https://run.mocky.io/v3/19217075-6d4e-4818-98bc-416d1feb7b84", content))
                {
                    string? responseString = await response.Content.ReadAsStringAsync();


                    EnvioPedidoAcmeResponse? objeto = JsonSerializer.Deserialize<Response.EnvioPedidoAcmeResponse>(SoapTransform.Transformar(responseString, "EnvioPedidoResponse"));

                    var objetoRespuesta = new 
                    {
                        enviarPedidoRespuesta = new 
                        {
                            codigoEnvio = objeto?.EnvioPedidoResponse.Codigo,
                            estado = objeto?.EnvioPedidoResponse.Mensaje
                        }
                    };
                    return Ok(objetoRespuesta);
                }
            }
        }

    }
}
