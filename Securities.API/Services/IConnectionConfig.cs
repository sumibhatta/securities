using Microsoft.Data.SqlClient;
namespace Securities.API.Services
{
    public interface IConnectionConfig
    {
        Task<SqlConnection> GetConnection();
    }
}
