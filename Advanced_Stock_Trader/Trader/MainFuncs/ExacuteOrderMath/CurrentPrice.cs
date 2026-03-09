using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs.ExacuteOrderMath
{
    public class CurrentPrice
    {
        GetStockData getsd = new GetStockData();
        public async Task<float> GetCurrentPrice(Settings s, string Symbol)
        {
            IEnumerable<IBar> Stock = (IEnumerable<IBar>)getsd.CurrentStockData(s, Symbol).Result;
            List<IBar> st = Stock.ToList<IBar>();
            return (float)st[0].Close;
        }
    }
}
