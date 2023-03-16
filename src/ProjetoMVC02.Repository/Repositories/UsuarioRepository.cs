using Dapper;
using ProjetoMVC02.Repository.Contracts;
using ProjetoMVC02.Repository.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoMVC02.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString;

        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Usuario Get(string email, string senha)
        {
            var query = @"SELECT * FROM TBL_USUARIO
                            WHERE EMAIL = @email AND SENHA = @senha";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>
                    (query, new { email, senha })
                    .FirstOrDefault();
            }
        }

        public void Create(Usuario usuario)
        {
            var query = @"INSERT INTO TBL_USUARIO (ID, NOME, EMAIL, SENHA, DATACRIACAO, PERFILID)
                        VALUES(@Id, @Nome, @Email, @Senha, @DataCriacao, @PerfilID)";

            using var connection = new SqlConnection(connectionString);
            connection.Execute(query, usuario);
        }

        public void Update(Usuario usuario)
        {
            var query = @"UPDATE TBL_USUARIO
                            SET NOME = @NOME, SENHA = @SENHA, PERFILID = @PERFILID
                            WHERE ID = @ID";
            
            using var connection = new SqlConnection(connectionString);
            
            connection.Execute(query, usuario);
        }

        public void Delete(Usuario usuario)
        {
            var query = @"DELETE FROM TBL_USUARIO WHERE ID = @ID";
            
            using var connection = new SqlConnection(connectionString);
            
            connection.Execute(query, usuario);
        }

        public List<Usuario> GetAll()
        {
            var query = "SELECT * FROM TBL_USUARIO ORDER BY NOME";

            using var connession = new SqlConnection(connectionString);

            return connession.Query<Usuario>(query).ToList();
        }

        public Usuario Get(string email)
        {
            var query = @"SELECT * FROM TBL_USUARIO
                            WHERE EMAIL = @email";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>
                    (query, new { email }).FirstOrDefault();
            }
        }

        public List<Usuario> GetAll(string nome)
        {
            var query = @"SELECT * FROM TBL_USUARIO
                            WHERE NOME LIKE @param
                            ORDER BY NOME";
            using var connection = new SqlConnection(connectionString);

            return connection.Query<Usuario>(query, new { param = "%" + nome + "%" })
                .ToList();
        }
    }
}