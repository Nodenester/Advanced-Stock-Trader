using Advanced_Stock_Trader.Trader.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ast = Advanced_Stock_Trader.Trader.DataBase;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs.MakeOrderMath
{
    public class HighLow
    {
        public async Task<List<float>> GetHighLow(int frequency, IEnumerable<IBar> Stocks)
        {
            List<IBar> Stks = Stocks.ToList<IBar>();
            int frqs = 1;
            float chunk = 0;
            List<float> HighLow = null;
            List<float> ChunkList = null;
            foreach(var i in Stks)
            {
                frqs++;
                chunk = chunk + (float)i.High;
                if(frqs == frequency)
                {
                    chunk = chunk / frequency;
                    ChunkList.Add(chunk);
                    chunk = 0;
                    frqs = 1;
                }
            }
            int index = 0;
            foreach(var x in ChunkList)
            {
                index++;
                if(x > (ChunkList[index - 1]) & x > (ChunkList[index + 1]))
                {
                    HighLow.Add(x);
                }
                if (x < (ChunkList[index - 1]) & x < (ChunkList[index + 1]))
                {
                    HighLow.Add(x);
                }
            }
            return (HighLow);
        }   
    }
}
