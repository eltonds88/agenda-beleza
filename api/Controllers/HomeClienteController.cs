using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using AgendaBeleza.Api.Servicos;
using AgendaBeleza.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace AgendaBeleza.Api.Controllers
{
    [Route("/api/cliente/home")]
    [Authorize(Roles = Usuario.TIPO_CLIENTE)]
    public class HomeClienteController : ControllerApi
    {
        public HomeClienteController(MySqlConnection connection) : base(connection) { }

        /// <summary>
        /// Listar os fornecedores próximos ao cliente
        /// </summary>
        /// <response code="200">Retorna a lista paginada com os estabelecimentos próximos ao cliente.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteHomeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get([FromQuery] ClienteHomeRequest model)
        {
            return Executar(
                () => 
                {
                    return new ClienteServico(_connection).BuscarFornecedoresProximos(model, GetClienteId());
                }
            );
        }

    }
}
