using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath
{
    public class BuyPrice
    {
        public async Task<float> NextLowPrice(Frequency data)
        {
            List<float> hs = data.Highs.ToList();
            List<float> ls = data.Lows.ToList();
            List<float> hg = data.HighLow.ToList();
            float dir = data.Proffit;
            List<float> ll = ls;

            ll.RemoveRange(0, ll.Count - 4);
            float lldir = (ll[1] / ll[0] + ll[2] / ll[1]) / 2;
            float aldir = 0;
            float pldir = 0;

            int count = 0;
            foreach(var x in ls)
            {
                if(1 <= count && count <= (ls.Count - 1))
                {
                    aldir = aldir + ls[count] / ls[count - 1];
                }
                count++;
            }
            aldir = aldir / count - 1;
            pldir = (aldir + lldir) / 2;

            return (ls[ls.Count - 1] * pldir);
        }
    }
}
