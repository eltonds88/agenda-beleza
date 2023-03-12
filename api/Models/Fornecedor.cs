namespace AgendaBeleza.Api.Models
{
    public class Fornecedor : UsuarioEndereco
    {
        public string? Descricao { get; set; }

        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Whatsapp { get; set; }

        public int QtdAvaliacoes { get; set; }
        public decimal? AvaliacaoMedia { get; set; }

        public ICollection<FornecedorServico> Servicos { get; set; } = new List<FornecedorServico>();
        public ICollection<FornecedorHorario> Horarios { get; set; } = new List<FornecedorHorario>();
    }
}
