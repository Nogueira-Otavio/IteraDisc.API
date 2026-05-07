using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IteraDisc.Repositorio
{
    public class DapperRepositorio
    {
        private readonly string _connectionString;

        public DapperRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected IDbConnection CriarConexao()
        {
            return new SqlConnection(_connectionString);
        }

        protected async Task<IEnumerable<T>> ExecutarProcedure<T>(
            string procedure,
            object parametros = null)
        {
            using var conexao = CriarConexao();
            return await conexao.QueryAsync<T>(
                procedure,
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        protected async Task<IEnumerable<T>> ExecutarQuery<T>(string sql, object parametros = null)
        {
            using var conexao = CriarConexao();
            return await conexao.QueryAsync<T>(sql, parametros);
        }

        protected async Task<T> ExecutarScalar<T>(string sql, object parametros = null)
        {
            using var conexao = CriarConexao();
            return await conexao.ExecuteScalarAsync<T>(sql, parametros);
        }
    }
}