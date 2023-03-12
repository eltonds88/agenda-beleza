using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Repositorios
{
    public class UsuariosRepositorio : RepositorioBase
    {
        public UsuariosRepositorio(MySqlConnection connection) : base(connection) { }

        public Usuario? BuscarusuarioPorEmail(string? email)
        {
            var parametros = CreateParameters("@email", email?.ToUpper());

            return 
                Conn.Query<Usuario>("select * from usuarios where upper(email) = @email",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }

        public Usuario? BuscarusuarioPorEmailSenha(string? email, string? plainPassword)
        {
            var parametros = CreateParameters(
                "@email", email?.ToUpper(),
                "@senha", plainPassword
            );

            return
                Conn.Query<Usuario>("select u.*, f.id as fornecedor_id, c.id as cliente_id from usuarios u " +
                " left join fornecedores f on f.usuario_id = u.id " +
                " left join clientes c on c.usuario_id = u.id " +
                " where upper(email) = @email and senha = MD5(@senha)",
                    parametros, transaction: Transaction)
                .FirstOrDefault();
        }

    }
}
