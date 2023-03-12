using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using AgendaBeleza.Api.ViewModels;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Servicos
{
    public class ClienteServico
    {
        private readonly ClienteRepositorio clienteRepositorio;
        private readonly FornecedorRepositorio fornecedorRepositorio;

        public ClienteServico(MySqlConnection connection) 
        {
            clienteRepositorio = new ClienteRepositorio(connection);
            fornecedorRepositorio = new FornecedorRepositorio(connection);
        }

        public ClienteHomeResponse BuscarFornecedoresProximos(ClienteHomeRequest model, int clienteId)
        {
            Cliente cliente = clienteRepositorio.BuscarPorId(clienteId);

            ICollection<FornecedorUsuario> fornecedores = fornecedorRepositorio.BuscarFornecedores(
                model.TipoServicoId, model.Texto, model.RaioBuscaEmKm, 
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
    }
}
