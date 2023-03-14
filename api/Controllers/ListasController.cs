using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using AgendaBeleza.Api.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;

namespace AgendaBeleza.Api.Controllers
{
    [Route("/api/listas")]
    public class ListasController : ControllerApi
    {
        public ListasController(MySqlConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Buscar cidades
        /// </summary>
        /// <response code="200">Lista de cidades contendo o texto informado, no máximo 30 resultados.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpGet]
        [Route("cidades")]
        [ProducesResponseType(typeof(ICollection<Cidade>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult BuscarCidades([FromQuery]string cidade)
        {
            return Executar(
                () =>
                {
                    return new ListasRepositorio(_connection).BuscarCidades(cidade);
                }
            );
        }

        /// <summary>
        /// Buscar tipos de servicos
        /// </summary>
        /// <response code="200">Lista com os tipos de serviços.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpGet]
        [Route("tipos-servicos")]
        [ProducesResponseType(typeof(ICollection<TipoServico>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult TiposServicos()
        {
            return Executar(
                () =>
                {
                    return new ListasRepositorio(_connection).ListarTiposServicos();
                }
            );
        }
    }
}
