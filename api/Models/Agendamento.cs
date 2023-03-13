namespace AgendaBeleza.Api.Models
{
    public class Agendamento
    {
		public const string PENDENTE = "Pendente";
        public const string FINALIZADO = "Finalizado";
        public const string CANCELADO = "Cancelado";

        public int Id { get; set; }
		public int FornecedorId { get; set;}
        public int ClienteId { get; set; }
        public int TipoServiceId { get; set; }
		public DateTime DataAgendamento { get; set; }
		public DateTime HoraInicio { get; set; }
		public DateTime HoraFim { get; set;}
		public int? Avaliacao { get; set; }
        public string StatusAgendamento { get; set; } = PENDENTE;
    }
}
