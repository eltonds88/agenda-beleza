using AgendaBeleza.Api.Models;
using AgendaBeleza.Api.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;

namespace AgendaBeleza.Api.Repositorios
{
    public class FornecedorRepositorio : RepositorioBase
    {
        public FornecedorRepositorio(MySqlConnection connection) : base(connection) { }

        public void CriarFornecedor(Fornecedor fornecedor, Usuario usuario)
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
                        new("@role", Usuario.TIPO_FORNECEDOR),
                        new("@cpfCnpj", usuario.CpfCnpj)
                    }
                );

                query = $"insert into fornecedores (usuario_id, descricao, instagram, facebook, twitter, whatsapp, qtd_avaliacoes, " +
                    $" logradouro, numero, complemento, bairro, cidade, uf, cep, latitude, longitude) " +
                    $"values (@usuarioId, @descricao, @instagram, @facebook, @twitter, @whatsapp, @qtdAvaliacoes, " +
                    $" @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @latitude, @longitude)";
                var fornecedorId = ExecuteInsert(query, new Tuple<string, object?>[] { 
                    new("@usuarioId", id),
                    new ("@descricao", fornecedor.Descricao),
                    new ("@instagram", fornecedor.Instagram),
                    new ("@facebook", fornecedor.Facebook),
                    new ("@twitter", fornecedor.Twitter),
                    new ("@whatsapp", fornecedor.Whatsapp),
                    new ("@qtdAvaliacoes", fornecedor.QtdAvaliacoes),
                    new ("@logradouro", fornecedor.Logradouro),
                    new ("@numero", fornecedor.Numero),
                    new ("@complemento", fornecedor.Complemento),
                    new ("@bairro", fornecedor.Bairro),
                    new ("@cidade", fornecedor.Cidade),
                    new ("@uf", fornecedor.Uf),
                    new ("@cep", fornecedor.Cep),
                    new ("@latitude", fornecedor.Latitude),
                    new ("@longitude", fornecedor.Longitude)
                });

                foreach (var item in fornecedor.Servicos)
                {
                    ExecuteInsert(
                        "insert into fornecedor_servico (fornecedor_id, tipo_servico_id, tempo_medio, tempo_medio_text) " +
                        "values (@fornecedorId, @tipoServicoId, @tempoMedio, @tempoMedioText)",
                        new Tuple<string, object?>[] {
                            new("@fornecedorId", fornecedorId),
                            new("@tipoServicoId", item.TipoServicoId),
                            new("@tempoMedio", item.TempoMedio),
                            new("@tempoMedioText", item.TempoMedioText)
                        }
                    );
                }

                foreach (var item in fornecedor.Horarios)
                {
                    ExecuteInsert(
                        "insert into fornecedor_horario (fornecedor_id, dia_semana, fechado, expediente_inicio, intervalo_inicio, intervalo_fim, expediente_fim) " +
                        "values (@fornecedorId, @diaSemana, @fechado, @expedienteInicio, @intervaloInicio, @intervaloFim, @expedienteFim)",
                        new Tuple<string, object?>[] {
                            new("@fornecedorId", fornecedorId),
                            new("@diaSemana", item.DiaSemana),
                            new("@fechado", item.Fechado),
                            new("@expedienteInicio", item.ExpedienteInicio),
                            new("@intervaloInicio", item.IntervaloInicio),
                            new("@intervaloFim", item.IntervaloFim),
                            new("@expedienteFim", item.ExpedienteFim)
                        }
                    );
                }

                Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        public ICollection<FornecedorUsuario> BuscarFornecedores(IEnumerable<int>? tiposServicos, string? texto, 
            int raioBuscaEmKm, decimal? latitude, decimal? longitude, 
            int pagina, out int totalItens)
        {
            var parametros = CreateParameters(
                "@raio", raioBuscaEmKm,
                "@latitude", latitude,
                "@longitude", longitude,
                "@pagina", pagina
            );

            var query = "(select distinct f.*, u.nome, u.telefone, ST_Distance_Sphere(point(f.latitude, f.longitude),point(@latitude,@longitude)) / 1000.0 as distancia" +
                " from fornecedores f " +
                " join usuarios u on u.id = f.usuario_id " +
                " join fornecedor_servico fs on fs.fornecedor_id = f.id " +
                " where ST_Distance_Sphere(point(f.latitude, f.longitude),point(@latitude,@longitude))/1000.0 < @raio ";
            if (tiposServicos != null && tiposServicos.Count() > 0) 
            {
                query += $" and fs.tipo_servico_id in ( {string.Join(",", tiposServicos)} )";
            }
            if (!string.IsNullOrEmpty(texto)) 
            {
                query += " and ( u.nome like @texto or f.descricao like @texto )";
                parametros.Add("@texto", $"%{texto}%");
            }
            query += $" ) as result ";

            totalItens = Conn.ExecuteScalar<int>($"select count(1) from {query}", parametros, transaction: Transaction);
            return
                Conn.Query<FornecedorUsuario>(
                    $"select * from {query} order by distancia asc limit {(pagina < 2 ? 0 : (pagina - 1) * 20)}, 20", 
                    parametros, transaction: Transaction).ToList();
        }
    }
}
