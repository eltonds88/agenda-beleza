using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using AgendaBeleza.Api.ViewModels;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace AgendaBeleza.Api.Servicos
{
    public class AccountServico
    {
        private readonly UsuariosRepositorio _usuarioRepositorio;
        public AccountServico(UsuariosRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public LoginResponse FazerLoginGerarToken(LoginRequest viewModel) 
        {
            var usuario = _usuarioRepositorio.BuscarusuarioPorEmailSenha(viewModel.Email, viewModel.Senha);
            if (usuario == null)
            {
                throw new Exception("Usuário ou senha não encontrados");
            }

            List<Claim> claims = new()
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim("FornecedorId", usuario.FornecedorId?.ToString() ?? "0"),
                new Claim("ClienteId", usuario.ClienteId?.ToString() ?? "0"),
                new(ClaimTypes.Role, usuario.Role)
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("L//aa69/un5Nf+yU9/unf+X-");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://agendabeleza.letz.dev",
                Audience = "https://agendabeleza.letz.dev/login",
                Subject = new ClaimsIdentity(new GenericIdentity(usuario.Email, "Login"), claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
                Nome = usuario.Nome,
                Role = usuario.Role
            };
        }

        private void ChecarEmailEmUso(string? email)
        {
            if (_usuarioRepositorio.BuscarusuarioPorEmail(email) != null)
            {
                throw new Exception("Email já cadastrado");
            }
        }

        private static Usuario CriarUsuario(CriarContaUsuarioRequest model)
        {
            return new Usuario()
            {
                CpfCnpj = model.CpfCnpj,
                Email = model.Email,
                Nome = model.Nome,
                Senha = model.Senha,
                Telefone = model.Telefone
            };
        }

        public static void PreencherEndereco(UsuarioEndereco endereco, CriarContaEnderecoRequest model)
        {
            endereco.Bairro = model.Bairro;
            endereco.Cep = model.Cep;
            endereco.Cidade = model.Cidade;
            endereco.Complemento = model.Complemento;
            endereco.Logradouro = model.Logradouro;
            endereco.Numero = model.Numero;
            GeolocationService.BuscarGeolocalizacao(string.Format("{0}, {1}. {2} - {3}/{4}",
                    endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.Cidade, endereco.Uf),
                    out var lat, out var lng);
            endereco.Latitude = lat;
            endereco.Longitude = lng;
        }

        public void CriarCliente(ClienteRepositorio clienteRepositorio, CriarContaClienteRequest model)
        {
            ChecarEmailEmUso(model.Email);
            Usuario usuario = CriarUsuario(model);
            var cliente = new Cliente()
            {
                DtNascimento = model.DtNascimento,
                Sexo = model.Sexo,
                Uf = model.Uf
            };
            PreencherEndereco(cliente, model);

            clienteRepositorio.CriarCliente(cliente, usuario);
        }

        public void CriarFornecedor(FornecedorRepositorio fornecedorRepositorio, CriarContaFornecedorRequest model)
        {
            ChecarEmailEmUso(model.Email);
            Usuario usuario = CriarUsuario(model);
            var fornecedor = new Fornecedor() 
            {
                AvaliacaoMedia = null,
                Descricao = model.Descricao,
                Facebook = model.Facebook,
                Instagram = model.Instagram,
                QtdAvaliacoes = 0,
                Twitter = model.Twitter,
                Whatsapp = model.Whatsapp
            };
            PreencherEndereco(fornecedor, model);

            foreach (var item in model.Servicos)
            {
                var tempoSplited = item.TempoMedioServico.Split(":");

                var tempo = Convert.ToDecimal(tempoSplited[0]);
                tempo += Convert.ToDecimal(tempoSplited[1]) / 60m;

                fornecedor.Servicos.Add(new FornecedorServico()
                {
                    TipoServicoId = item.TipoServicoId,
                    TempoMedioText = item.TempoMedioServico,
                    TempoMedio = tempo
                });
            }

            foreach (var item in model.Horarios)
            {
                fornecedor.Horarios.Add(new FornecedorHorario() { 
                    DiaSemana = item.DiaSemana,
                    ExpedienteFim = item.ExpedienteFim,
                    ExpedienteInicio = item.ExpedienteInicio,
                    Fechado = item.Fechado,
                    IntervaloFim = item.IntervaloFim,
                    IntervaloInicio = item.IntervaloInicio
                });
            }

            fornecedorRepositorio.CriarFornecedor(fornecedor, usuario);
        }
    }
}
