using Advanced_Stock_Trader.Trader.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ast = Advanced_Stock_Trader.Trader.DataBase;
using ta = Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs
{
    public class UpdateStockPrice
    {
        public ast.GetDB getdb = new ast.GetDB();
        public ast.SetDB setdb = new ast.SetDB();
        public ta.GetStockData getsd = new ta.GetStockData();

        public async Task UpdateStocks(Settings s, System.Data.SqlClient.SqlConnection cn)
        {
            IEnumerable<Stock> Stocks = await getdb.ListStocks(cn);
            List<Stock> ss = Stocks.ToList<Stock>();
            foreach (var x in ss)
            {
                var Value = getsd.CurrentStockDataf(s, x.StockName);
                Stock NewStock = null;
                NewStock.CurrentPrice = (float)Value.Result;
                NewStock.HaveOrder = x.HaveOrder;
                NewStock.StockName = x.StockName;
                setdb.SetStock(cn, NewStock);
            }
        }
    }
}
