using Alpaca.Markets;
using System;
using System.Linq;
using System.Threading.Tasks;
using Advanced_Stock_Trader.Trader.Data;

namespace Advanced_Stock_Trader.Trader.Api
{
    public class GetStockData
    {
        public async Task<IPage<IBar>> SpecialStockData(Settings s, string Symbol, float Mins)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaDataClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var into = DateTime.Now;
            var from = into.AddMinutes(-Mins);
            return await client.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(Symbol, from, into, BarTimeFrame.Minute));
        }

        public async Task<IPage<IBar>> StockData(Settings s, string Symbol)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaDataClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var into = DateTime.Now;
            var from = into.AddMinutes(-s.Mins);
            return await client.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(Symbol, from, into, BarTimeFrame.Minute));
        }
        public async Task<IPage<IBar>> CurrentStockData(Settings s, string Symbol)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaDataClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var into = DateTime.Now;
            var from = into.AddMinutes(-1);
            return await client.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(Symbol, from, into, BarTimeFrame.Minute));
        }
        public async Task<float> CurrentStockDataf(Settings s, string Symbol)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaDataClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var into = DateTime.Now;
            var from = into.AddMinutes(-1);
            IPage<IBar> rqa = await client.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(Symbol, from, into, BarTimeFrame.Minute));
            return (float)rqa.Items[0].High;
        }
    }
}

