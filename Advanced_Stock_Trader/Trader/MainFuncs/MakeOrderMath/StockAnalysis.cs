using Alpaca.Markets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advanced_Stock_Trader.Trader.Data;
using fs = Advanced_Stock_Trader.Trader.Data;

namespace Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath
{
    public class StockAnalysis
    {
        public async Task<Frequency> ProffitProbability(int frequency, IEnumerable<IBar> StockData)
        {
            HighLow hl = new HighLow();
            bool even;
            bool ud;
            float cud = 0;
            float changeup = 1;
            float changedown = 1;
            float total = 0;
            List<float> Lows = null;
            List<float> Highs = null;
            fs.Frequency retur = null;

            List<float> hg = hl.GetHighLow(frequency, StockData).Result;

            if (hg[0] < hg[1])
            {
                ud = false;
            }
            else
            {
                ud = true;
            }

            if (hg.Count % 2 == 0)
            {
                even = true;
            }
            else
            {
                even = false;
            }

            int index = 0;
            foreach (var x in hg)
            {
                if (ud == true)
                {
                    changedown = changedown * (x / hg[index + 1]);
                    cud = cud + (x - hg[index + 2]);
                    Lows.Add(x);
                }
                else
                {
                    changeup = changeup * (hg[index + 1] / x);
                    cud = cud + (x - hg[index + 2]);
                    Highs.Add(x);
                }

                total = total + x;

                ud = !ud;
                index++;
                if (even == false & index == hg.Count - 1)
                {
                    index = index - 1;
                    break;
                }
            }
            changedown = changedown / (index / 2);
            changeup = changeup / (index / 2);
            cud = cud / index;
            total = total / index;

            retur.Stabillity = cud / total;
            retur.Proffit = changeup / changedown;
            retur.Frequensy = frequency;
            retur.HighLow = hg;
            retur.Highs = Highs;
            retur.Lows = Lows;
            retur.Diffrens = changeup - changedown;

            return (retur);
        }
    }
}
