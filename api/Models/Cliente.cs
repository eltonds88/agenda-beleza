namespace AgendaBeleza.Api.Models
{
    public class Cliente : UsuarioEndereco
    {
		public string? Sexo { get; set; }
		public DateTime? DtNascimento { get; set; }
    }
}
