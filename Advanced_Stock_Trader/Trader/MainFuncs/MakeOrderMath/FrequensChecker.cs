using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;



namespace Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath
{
    public class FrequensChecker
    {
        public StockAnalysis _sa = new StockAnalysis();

        public Frequency GetBestFrequency(List<int> frequensys, IEnumerable<IBar> StockData)
        {
            Dictionary<float, Frequency> fs = null;

            foreach (var f in frequensys)
            {
                var pp = _sa.ProffitProbability(f, StockData).Result;
                fs.Add((pp.Proffit / (pp.Stabillity * 100)) * 100, pp);
            }
            var bk = fs.Keys.Max();
            return(fs[bk]);
        }
    }
}
