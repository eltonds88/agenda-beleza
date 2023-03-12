using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Repositorios
{
    public class AgendamentoRepositorio : RepositorioBase
    {
        public AgendamentoRepositorio(MySqlConnection connection) : base(connection) { }

        public ICollection<ClienteAgendamento> BuscarAgendamentosCliente(int pagina, int clienteId, out int totalItens)
        {
            var parametros = CreateParameters("@clienteId", clienteId);
            var query = $" ( select a.id, ts.nome as tipo_servico, fu.nome as fornecedor, a.data_agendamento, a.status_agendamento " +
                $" from agendamentos a join fornecedores f on f.id = a.fornecedor_id " +
                $" join usuarios fu on fu.id = f.usuario_id join tipos_servicos ts on ts.id = a.tipo_servico_id " +
                $" where a.cliente_id = @clienteId ) as result ";
            totalItens = Conn.ExecuteScalar<int>($"select count(1) from {query}", parametros, Transaction);
            return Conn.Query<ClienteAgendamento>(
                    $"select * from {query} order by data_agendamento desc limit {(pagina < 2 ? 0 : (pagina - 1) * 20)}, 20",
                    parametros, transaction: Transaction).ToList();
        }

    }
}
