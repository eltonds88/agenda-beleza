using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.Repositorios;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Servicos
{
    public class AgendamentosServico
    {
        private readonly MySqlConnection connection;
        public AgendamentosServico(MySqlConnection connection)
        {
            this.connection = connection;
        }

        private Agendamento CheckAgendamentoPertenceUsuario(int agendamentoId, int? fornecedorId, int? clienteId, AgendamentoRepositorio agendamentoRepositorio)
        {
            var agendamento = agendamentoRepositorio.BuscarPorId(agendamentoId);
            if (fornecedorId.HasValue && agendamento.FornecedorId != fornecedorId)
            {
                throw new Exception("Agendamento não pertence ao usuário autenticado");
            }
            if (clienteId.HasValue && agendamento.ClienteId != clienteId)
            {
                throw new Exception("Agendamento não pertence ao usuário autenticado");
            }
            return agendamento;
        }

        private void CheckPodeAlterarStatus(Agendamento agendamento)
        {
            if (agendamento.StatusAgendamento != Agendamento.PENDENTE)
            {
                throw new Exception("Agendamento não está pendente e não pode ser alterado");
            }
        }

        public void FinalizarAgendamento(int agendamentoId, int? fornecedorId, int? clienteId, int usuarioId)
        {
            var agendamentoRepositorio = new AgendamentoRepositorio(connection);
            var agendamento = CheckAgendamentoPertenceUsuario(agendamentoId, fornecedorId, clienteId, agendamentoRepositorio);
            CheckPodeAlterarStatus(agendamento);
            agendamentoRepositorio.AlterarStatus(agendamentoId, usuarioId, Agendamento.FINALIZADO);
        }

        public void CancelarAgendamento(int agendamentoId, int? fornecedorId, int? clienteId, int usuarioId)
        {
            var agendamentoRepositorio = new AgendamentoRepositorio(connection);
            var agendamento = CheckAgendamentoPertenceUsuario(agendamentoId, fornecedorId, clienteId, agendamentoRepositorio);
            CheckPodeAlterarStatus(agendamento);
            agendamentoRepositorio.AlterarStatus(agendamentoId, usuarioId, Agendamento.CANCELADO);
        }
    }
}
