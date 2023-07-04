using Microsoft.Data.SqlClient;
using Securities.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Securities.API.Services
{
    public class ConnectionConfig : IConnectionConfig
    {
        private readonly ApplicationDBContext _context;
        public ConnectionConfig(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<SqlConnection> GetConnection()
        {
            string connString =  _context.Database.GetDbConnection().ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            await conn.OpenAsync();
            return conn;

        }
    }
}
