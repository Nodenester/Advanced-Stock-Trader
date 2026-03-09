using Advanced_Stock_Trader.Trader.Data;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.DataBase
{
    public class GetDB
    {
        //Settings
        public async Task<Settings> GetSettings(SqlConnection cn)
        {
            string sql = "SELECT * FROM nestor.Settings";
            return await cn.QuerySingleAsync<Settings>(sql, new { });
        }

        //Stocks
        public async Task<IEnumerable<Stock>> ListStocks(SqlConnection cn)
        {
            string sql = "SELECT * FROM nestor.Stocks";
            return await cn.QueryAsync<Stock>(sql, new { });
        }

        //Orders
        public async Task<IEnumerable<Order>> ListOrders(SqlConnection cn)
        {
            string sql = "SELECT * FROM nestor.Orders";
            return await cn.QueryAsync<Order>(sql, new { });
        }
    }
}
