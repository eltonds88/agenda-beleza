using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Repositorios
{
    public class ClienteRepositorio : RepositorioBase
    {
        public ClienteRepositorio(MySqlConnection connection) : base(connection) { }

        public void CriarCliente(Cliente cliente, Usuario usuario)
        {
            try
            {
                BeginTransaction();
                var query = "insert into usuarios(nome, telefone, email, senha, role, cpf_cnpj) values (@nome, @telefone, @email, MD5(@senha), @role, @cpfCnpj)";

                var id = ExecuteInsert(
                    query,
                    new Tuple<string, object?>[] {
                        new("@nome", usuario.Nome),
                        new("@telefone", usuario.Telefone),
                        new("@email", usuario.Email),
                        new("@senha", usuario.Senha),
                        new("@role", Usuario.TIPO_CLIENTE),
                        new("@cpfCnpj", usuario.CpfCnpj)
                    }
                );

                query = $"insert into clientes (usuario_id, sexo, dt_nascimento, logradouro, numero, complemento, bairro, cidade, uf, cep, latitude, longitude) " +
                    $"values (@usuarioId, @sexo, @dtNascimento, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @latitude, @longitude)";
                ExecuteInsert(query, new Tuple<string, object?>[] { 
                    new("@usuarioId", id),
                    new ("@sexo", cliente.Sexo),
                    new ("@dtNascimento", cliente.DtNascimento),
                    new ("@logradouro", cliente.Logradouro),
                    new ("@numero", cliente.Numero),
                    new ("@complemento", cliente.Complemento),
                    new ("@bairro", cliente.Bairro),
                    new ("@cidade", cliente.Cidade),
                    new ("@uf", cliente.Uf),
                    new ("@cep", cliente.Cep),
                    new ("@latitude", cliente.Latitude),
                    new ("@longitude", cliente.Longitude)
                });

                Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

    }
}
