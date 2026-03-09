using Alpaca.Markets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gsd = Advanced_Stock_Trader.Trader.Api;
using Advanced_Stock_Trader.Trader.Data;

namespace Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath
{
    public class StockDirection
    {
        public async Task<decimal> Direction(Settings s, string Symbol)
        {
            gsd.GetStockData getStockData = new gsd.GetStockData();

            IEnumerable<IBar> stockdata = (IEnumerable<IBar>)getStockData.StockData(s, Symbol);

            List<IBar> sd = stockdata.ToList<IBar>();

            IBar First = sd.First<IBar>();
            IBar Last = sd.Last<IBar>();
            decimal change = Last.High / First.High;
            return(change);
        }
    }
}
