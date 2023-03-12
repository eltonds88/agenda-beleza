namespace AgendaBeleza.Api.ViewModels
{
    public class ClienteHomeRequest
    {
        public int? TipoServicoId { get; set; }
        public string? Texto { get; set; }
        public int RaioBuscaEmKm { get; set; } = 20;
        public int Pagina { get; set; } = 1;
    }

    public class ClienteHomeItemResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Classificacao { get; set; }
        public int QtdAvaliacoes { get; set; }
        public string? Endereco { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Descricao { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? WhatsApp { get; set; }
        public string? Telefone { get; set; }
        public decimal Distancia { get; set; }
    }

    public class ClienteHomeResponse
    {
        public int TotalItens { get; set; }
        public ICollection<ClienteHomeItemResponse> Itens { get; set; } = new List<ClienteHomeItemResponse>();
    }
}
