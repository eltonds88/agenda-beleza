namespace AgendaBeleza.Api.Models
{
    public class FornecedorHorario
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int DiaSemana { get; set; }
        public bool Fechado { get; set; }
        public string? ExpedienteInicio { get; set; }
        public string? IntervaloInicio { get; set; }
        public string? IntervaloFim { get; set; }
        public string? ExpedienteFim { get; set; }
    }
}
