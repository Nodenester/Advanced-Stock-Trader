using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ast = Advanced_Stock_Trader.Trader.DataBase;
using om = Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs
{
    public class MakeOrder
    {
        GetStockData gtd = new GetStockData();
        GetStockData getsd = new GetStockData();
        ast.GetDB getdb = new ast.GetDB();
        ast.SetDB setdb = new ast.SetDB();
        om.HighLow _hl = new om.HighLow();
        om.StockAnalysis _sa = new om.StockAnalysis();
        om.FrequensChecker _fc = new om.FrequensChecker();
        om.BuyPrice _bp = new om.BuyPrice();

        public async void OrderCreator(Settings s, System.Data.SqlClient.SqlConnection cn, List<int> frequensys)
        {
            IEnumerable<Stock> Stocks = await getdb.ListStocks(cn);
            List<Stock> ss = Stocks.ToList();

            foreach(var x in ss)
            {
                if (x.HaveOrder == false)
                {
                    IEnumerable<IBar> StockData = (IEnumerable<IBar>)gtd.StockData(s, x.StockName);
                    Frequency bf = _fc.GetBestFrequency(frequensys, StockData);
                    if((bf.Proffit / bf.Stabillity) > s.Risk)
                    {
                        float BuyPrice = _bp.NextLowPrice(bf).Result;
                        Order order = null;
                        order.StockName = x.StockName;
                        order.Action = "Buy";
                        order.Value = BuyPrice;
                        order.Risk = bf.Proffit / bf.Stabillity;
                        setdb.AddOrder(cn, order);
                    }
                }
                //else
                //{


                //}
            }
        }
    }
}
