namespace AgendaBeleza.Api.Models
{
    public class Usuario
    {
        public const string TIPO_FORNECEDOR = "FORNECEDOR";
        public const string TIPO_CLIENTE = "CLIENTE";

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? CpfCnpj { get; set; }
        public string Role { get; set; } = string.Empty;

        public int? ClienteId { get; set; }
        public int? FornecedorId { get; set; }

    }
}
