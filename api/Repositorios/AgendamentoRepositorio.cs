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

        public Agendamento BuscarPorId(int agendamentoId)
        {
            var parametros = CreateParameters("@id", agendamentoId);
            return
                Conn.Query<Agendamento>(
                        "select * " +
                        " from agendamentos " +
                        " where id = @id ",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }

        public void AlterarStatus(int agendamentoId, int usuarioId, string status)
        {
            try
            {
                BeginTransaction();
                var query = "update agendamentos set status_agendamento = @status where id = @id ";
                var parametros = CreateParameters("@status", status, "@id", agendamentoId);
                Conn.Execute(query, parametros, transaction: Transaction);

                query = "insert into agendamento_historico(agendamento_id, usuario_id, status_agendamento, dt_historico) values (@agendamentoId, @usuarioId, @statusAgendamento, @dtHistorico)";
                ExecuteInsert(
                    query,
                    new Tuple<string, object?>[] {
                        new("@agendamentoId", agendamentoId),
                        new("@usuarioId", usuarioId),
                        new("@statusAgendamento", status),
                        new("@dtHistorico", DateTime.Now)
                    }
                );

                Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }


    }
}
