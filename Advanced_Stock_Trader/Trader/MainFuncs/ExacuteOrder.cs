using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ast = Advanced_Stock_Trader.Trader.DataBase;
using om = Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;
using eo = Advanced_Stock_Trader.Trader.MainFuncs.ExacuteOrderMath;

namespace Advanced_Stock_Trader.Trader.MainFuncs
{
    public class ExacuteOrder
    {
        GetStockData getsd = new GetStockData();
        ast.GetDB getdb = new ast.GetDB();
        ast.SetDB setdb = new ast.SetDB();
        om.HighLow _hl = new om.HighLow();
        om.StockAnalysis _sa = new om.StockAnalysis();
        om.FrequensChecker _fc = new om.FrequensChecker();
        om.BuyPrice _bp = new om.BuyPrice();
        eo.CurrentDirection _cd = new eo.CurrentDirection();
        eo.CurrentVolume _cv = new eo.CurrentVolume();
        eo.CurrentPrice _cp = new eo.CurrentPrice();
        eo.CalculatBuyAmount _cba = new eo.CalculatBuyAmount();
        MakeTransaction _mt = new MakeTransaction();
        public async void ExacuteOrders(Settings s, System.Data.SqlClient.SqlConnection cn)
        {
            List<Order> Orders = (List<Order>)getdb.ListOrders(cn).Result;
            foreach (var x in Orders)
            {
                if(x.Action == "Buy")
                {
                    float cp = _cp.GetCurrentPrice(s, x.StockName).Result;
                    if (cp < x.Value)
                    {
                        if (_cd.GetCurrentDirection(s, x.StockName).Result > 0.9f)
                        {
                            //titta även volymen (kanske)
                            await _mt.Buy(s, x.StockName, await _cba.GetBuyAmount(s, cp, x.Risk, Orders.Count));

                            //gör om den till en sälj order
                            //value ska då va vad man köpte för instället var vad man skulle köpa för
                        }
                    }
                }
                else if (x.Action == "Sell")
                {

                }
            }
        }
    }
}
