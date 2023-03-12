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
    [Route("/api/agendamentos")]
    [Authorize]
    public class AgendamentosController : ControllerApi
    {
        public AgendamentosController(MySqlConnection connection) : base(connection) { }

        /// <summary>
        /// Lista os agendamentos do cliente autenticado
        /// </summary>
        /// <response code="200">Retorna a lista paginada com os agendamentos do cliente.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpGet]
        [Route("cliente")]
        [ProducesResponseType(typeof(ClienteHomeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [Authorize(Roles = Usuario.TIPO_CLIENTE)]
        public IActionResult Get([FromQuery] int pagina)
        {
            return Executar(
                () => 
                {
                    return new ClienteServico(_connection).BuscarAgendamentos(GetClienteId(), pagina);
                }
            );
        }

    }
}
