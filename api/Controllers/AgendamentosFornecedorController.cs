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
    [Route("/api/agendamentos/fornecedor")]
    [Authorize(Roles = Usuario.TIPO_FORNECEDOR)]
    public class AgendamentosFornecedorController : ControllerApi
    {
        public AgendamentosFornecedorController(MySqlConnection connection) : base(connection) { }

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
                    new AgendamentosServico(_connection).CancelarAgendamento(id, GetFornecedorId(), null, GetUsuarioId());
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
                    new AgendamentosServico(_connection).FinalizarAgendamento(id, GetFornecedorId(), null, GetUsuarioId());
                    return true;
                }
            );
        }

    }
}
