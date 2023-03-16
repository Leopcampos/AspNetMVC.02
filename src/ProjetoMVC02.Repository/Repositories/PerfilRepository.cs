using Dapper;
using ProjetoMVC02.Repository.Contracts;
using ProjetoMVC02.Repository.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoMVC02.Repository.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly string connectionString;

        public PerfilRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Perfil> GetAll()
        {
            var query = @"SELECT * FROM TBL_PERFIL ORDER BY NOME ASC";

            using var connection = new SqlConnection(connectionString);
            return connection.Query<Perfil>(query).ToList();
        }
    }
}