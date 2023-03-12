namespace AgendaBeleza.Api.ViewModels
{
    public class AgendamentoClienteItemResponse
    {
        public long Id { get; set; }
        public string TipoServico { get; set; } = string.Empty;
        public string Fornecedor { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class AgendamentoClienteResponse
    {
        public int TotalItens { get; set; }
        public ICollection<AgendamentoClienteItemResponse> Itens { get; set; } = new List<AgendamentoClienteItemResponse>();
    }
}
