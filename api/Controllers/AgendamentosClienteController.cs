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
    [Route("/api/agendamentos/cliente")]
    [Authorize(Roles = Usuario.TIPO_CLIENTE)]
    public class AgendamentosClienteController : ControllerApi
    {
        public AgendamentosClienteController(MySqlConnection connection) : base(connection) { }

        /// <summary>
        /// Lista os agendamentos do cliente autenticado
        /// </summary>
        /// <response code="200">Retorna a lista paginada com os agendamentos do cliente.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteHomeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get([FromQuery] int pagina)
        {
            return Executar(
                () => 
                {
                    return new ClienteServico(_connection).BuscarAgendamentos(GetClienteId(), pagina);
                }
            );
        }

        /// <summary>
        /// Cancelar um agendamento pendente
        /// </summary>
        /// <response code="200">Agendamento alterado com sucesso.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpPut]
        [Route("cancelar/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Cancelar([FromRoute] int id)
        {
            return Executar(
                () =>
                {
                    new AgendamentosServico(_connection).CancelarAgendamento(id, null, GetClienteId(), GetUsuarioId());
                    return true;
                }
            );
        }

        /// <summary>
        /// Finalizar um agendamento pendente
        /// </summary>
        /// <response code="200">Agendamento alterado com sucesso.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpPut]
        [Route("finalizar/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Finalizar([FromRoute] int id)
        {
            return Executar(
                () =>
                {
                    new AgendamentosServico(_connection).FinalizarAgendamento(id, null, GetClienteId(), GetUsuarioId());
                    return true;
                }
            );
        }

    }
}
