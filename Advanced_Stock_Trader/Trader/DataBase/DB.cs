using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Advanced_Stock_Trader.Trader.DataBase
{
    public class DB
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "WebDB";
        public DB(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Conn
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConnectionStringName));
            }
        }
    }
}
