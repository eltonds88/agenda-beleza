using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using AgendaBeleza.Api.ViewModels;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Servicos
{
    public class ClienteServico
    {
        private readonly MySqlConnection connection;

        public ClienteServico(MySqlConnection connection) 
        {
            this.connection = connection;
        }

        public ClienteHomeResponse BuscarFornecedoresProximos(ClienteHomeRequest model, int clienteId)
        {
            var clienteRepositorio = new ClienteRepositorio(connection);
            var fornecedorRepositorio = new FornecedorRepositorio(connection);

            Cliente cliente = clienteRepositorio.BuscarPorId(clienteId);
            ICollection<FornecedorUsuario> fornecedores = fornecedorRepositorio.BuscarFornecedores(
                model.TiposServicosIds, model.Texto, model.RaioBuscaEmKm, 
                cliente.Latitude, cliente.Longitude, model.Pagina, out int totalItens);

            var response = new ClienteHomeResponse()
            {
                TotalItens = totalItens,
                Itens = fornecedores
                    .Select(f => new ClienteHomeItemResponse() { 
                        Classificacao = f.AvaliacaoMedia,
                        Descricao = f.Descricao,
                        Endereco = f.GetEndereco(),
                        Facebook = f.Facebook,
                        Id = f.Id,
                        Instagram = f.Instagram ,
                        Latitude = f.Latitude,
                        Longitude = f.Longitude,
                        Nome = f.Nome,
                        QtdAvaliacoes = f.QtdAvaliacoes,
                        Telefone = f.Telefone,
                        Twitter = f.Twitter,
                        WhatsApp = f.Whatsapp,
                        Distancia = f.Distancia
                    })
                    .ToList()
            };
            return response;
        }

        public AgendamentoClienteResponse BuscarAgendamentos(int clienteId, int pagina)
        {
            var agendamentoRepositorio = new AgendamentoRepositorio(connection);
            var agendamentos = agendamentoRepositorio.BuscarAgendamentosCliente(pagina, clienteId, out var totalItens);

            var response = new AgendamentoClienteResponse() { 
                TotalItens = totalItens,
                Itens = agendamentos.Select(a => new AgendamentoClienteItemResponse()
                {
                    Data = a.DataAgendamento,
                    Fornecedor = a.Fornecedor,
                    Id = a.Id,
                    Status = a.StatusAgendamento,
                    TipoServico = a.TipoServico
                }).ToList()
            };
            return response;
        }
    }
}
