namespace AgendaBeleza.Api.Models
{
    public class ClienteAgendamento
    {
        public int Id { get; set; }
        public string TipoServico { get; set; } = string.Empty;
        public string Fornecedor { get; set; } = string.Empty;
        public DateTime DataAgendamento { get; set; }
        public string StatusAgendamento { get; set; } = string.Empty;
    }
}
