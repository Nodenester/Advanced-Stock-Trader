using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs.ExacuteOrderMath
{
    public class CurrentDirection
    {
        GetStockData getsd = new GetStockData();
        public async Task<float> GetCurrentDirection(Settings s, string Symbol)
        {
            List<IBar> StockData = (List<IBar>)getsd.SpecialStockData(s, Symbol, 3).Result;
            return (float)(StockData[2].Close / StockData[0].Close);
        }
    }
}
