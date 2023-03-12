namespace AgendaBeleza.Api.Models
{
    public class FornecedorServico
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int TipoServicoId { get; set; }
        public decimal TempoMedio { get; set; }
        public string? TempoMedioText { get; set; }
    }
}
