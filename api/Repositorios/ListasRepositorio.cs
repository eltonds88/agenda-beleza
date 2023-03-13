using AgendaBeleza.Api.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Repositorios
{
    public class ListasRepositorio : RepositorioBase
    {
        public ListasRepositorio(MySqlConnection connection) : base(connection)
        {
        }

        public IEnumerable<Cidade> BuscarCidades(string? cidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@cidade", "%" + cidade?.ToUpper() + "%");
            return Conn
                .Query<Cidade>("select * from cidades where upper(nome) like @cidade order by nome limit 30",
                    parametros, transaction: Transaction)
                .ToList();
        }

        public IEnumerable<TipoServico> ListarTiposServicos()
        {
            return Conn
                .Query<TipoServico>("select * from tipos_servicos order by nome", transaction: Transaction)
                .ToList();
        }
    }
}
