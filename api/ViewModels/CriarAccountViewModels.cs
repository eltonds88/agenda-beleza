using System.ComponentModel.DataAnnotations;

namespace AgendaBeleza.Api.ViewModels
{
    #region compartilhado
    public class CriarContaEnderecoRequest 
    {
        [Required]
        public string? Logradouro { get; set; }
        [Required]
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        [Required]
        public string? Bairro { get; set; }
        [Required]
        public string? Cidade { get; set; }
        [Required]
        public string? Uf { get; set; }
        public string? Cep { get; set; }
    }

    public class CriarContaUsuarioRequest : CriarContaEnderecoRequest
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? CpfCnpj { get; set; }
    }
    #endregion compartilhado

    #region cliente
    public class CriarContaClienteRequest : CriarContaUsuarioRequest
    {
        public string? Sexo { get; set; }
        public DateTime? DtNascimento { get; set; }
    }
    #endregion cliente

    #region fornecedor
    public class CriarContaFornecedorRequest : CriarContaUsuarioRequest
    {
        [Required]
        public string? Descricao { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Whatsapp { get; set; }
        public ICollection<CriarContaServicoFornecedorRequest> Servicos { get; set; } = new List<CriarContaServicoFornecedorRequest>();
        public ICollection<CriarContaHorarioFornecedorRequest> Horarios { get; set; } = new List<CriarContaHorarioFornecedorRequest>();
    }

    public class CriarContaServicoFornecedorRequest 
    {
        [Required]
        public int TipoServicoId { get; set; }
        [Required]
        public string TempoMedioServico { get; set; } = string.Empty;
    }

    public class CriarContaHorarioFornecedorRequest 
    {
        [Required]
        public int DiaSemana { get; set; }
        [Required]
        public bool Fechado { get; set; }
        public string? ExpedienteInicio { get; set; }
        public string? IntervaloInicio { get; set; }
        public string? IntervaloFim { get; set; }
        public string? ExpedienteFim { get; set; }
    }
    #endregion fornecedor

}
