using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SecuestroBienes.Models.DataContext
{
    internal class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly string secretString;
        public DapperContext(IConfiguration config)
        {
            _config = config;
            secretString = _config["ConnectionStrings:ConnectionDatabase"];
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_config[secretString]);
        }
    }
}
