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
    [Route("/api/account")]
    public class AccountController : ControllerApi
    {
        public AccountController(MySqlConnection connection) : base(connection) { }

        /// <summary>
        /// Efetua o login no sistema
        /// </summary>
        /// <response code="200">Retorna o json com o token e a role do usuário.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            return Executar(
                () => 
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    return servico.FazerLoginGerarToken(model);
                }
            );
        }


        /// <summary>
        /// Criar uma conta de fornecedor no sistema
        /// </summary>
        /// <response code="200">Retorna o json com um token jwt e a role do usuário recém criado.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpPost]
        [Route("criar-fornecedor")]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult CriarContaFornecedor([FromBody] CriarContaFornecedorRequest model)
        {
            return Executar(
                () =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarFornecedor(new FornecedorRepositorio(_connection), model);
                    return servico.FazerLoginGerarToken(new LoginRequest() { Email = model.Email, Senha = model.Senha });
                }
            );
        }

        /// <summary>
        /// Criar uma conta de cliente no sistema
        /// </summary>
        /// <response code="200">Retorna o json com um token jwt e a role do usuário recém criado.</response>
        /// <response code="400">Retorna string com a mensagem de erro.</response>
        [HttpPost]
        [Route("criar-cliente")]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult CriarContaCliente([FromBody] CriarContaClienteRequest model)
        {
            return Executar(
                () =>
                {
                    var servico = new AccountServico(new UsuariosRepositorio(_connection));
                    servico.CriarCliente(new ClienteRepositorio(_connection), model);
                    return servico.FazerLoginGerarToken(new LoginRequest() { Email = model.Email, Senha = model.Senha });
                }
            );
        }
    }
}
