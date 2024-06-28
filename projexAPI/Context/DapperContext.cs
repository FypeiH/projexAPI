using System.Data.SqlClient;
using System.Data;

namespace projexAPI.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration?.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

    }
}