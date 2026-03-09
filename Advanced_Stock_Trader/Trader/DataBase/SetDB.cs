
using Advanced_Stock_Trader.Trader.Data;
using Dapper;
using System.Data.SqlClient;

namespace Advanced_Stock_Trader.Trader.DataBase
{
    public class SetDB
    {
        //Settings
        public int SetSettings(SqlConnection cn, Settings s)
        {
            string sql = "UPDATE nestor.Settings SET API_KEY = @API_KEY,API_SECRET = @API_SECRET,Risk = @Risk,BuyProcent = @BuyProcent WHERE Id=1";
            return cn.Execute(sql, new { API_KEY = s.API_KEY, API_SECRET = s.API_SECRET, Risk = s.Risk, BuyProcent = s.BuyProcent });
        }

        //Orders
        public int AddOrder(SqlConnection cn, Order o)
        {
            string sql = "INSERT INTO dbo.MinLogg (StockName,Action,Value,Risk) VALUES (@StockName,@Action,@Value,@Risk)";
            return cn.Execute(sql, new { StockName = o.StockName, Action = o.Action, Value = o.Value, Risk = o.Risk });
        }
        public int SetOrder(SqlConnection cn, Order o)
        {
            string sql = "UPDATE nestor.Settings SET Action = @Action,Value = @Value,Risk = @Risk WHERE StockName = @StockName";
            return cn.Execute(sql, new { StockName = o.StockName, Action = o.Action, Value = o.Value, Risk = o.Risk });
        }

        //Stocks
        public int AddStock(SqlConnection cn, Stock s)
        {
            string sql = "INSERT INTO dbo.MinLogg (StockName,HaveOrder,CurrentPrice) VALUES (@StockName,@HaveOrder,@CurrentPrice)";
            return cn.Execute(sql, new { StockName = s.StockName, HaveOrder = s.HaveOrder, CurrentPrice = s.CurrentPrice });
        }
        public int SetStock(SqlConnection cn, Stock s)
        {
            string sql = "UPDATE nestor.Settings SET HaveOrder = @HaveOrder,CurrentPrice = @CurrentPrice WHERE StockName = @StockName";
            return cn.Execute(sql, new { StockName = s.StockName, HaveOrder = s.HaveOrder, CurrentPrice = s.CurrentPrice });
        }
    }
}
