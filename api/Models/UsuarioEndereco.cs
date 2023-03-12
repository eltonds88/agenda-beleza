using System.Globalization;

namespace AgendaBeleza.Api.Models
{
    public class UsuarioEndereco
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public string GetEndereco() 
        {
            if (string.IsNullOrEmpty(Complemento))
            {
                return string.Format("{0}, {1}. {2} - {3}/{4}", Logradouro, Numero, Bairro, Cidade, Uf);
            } 
            else
            {
                return string.Format("{0}, {1} {2}. {3} - {4}/{5}", Logradouro, Numero, Complemento, Bairro, Cidade, Uf);
            }
        }
    }
}
