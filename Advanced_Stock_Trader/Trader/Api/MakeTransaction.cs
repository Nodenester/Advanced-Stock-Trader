using Alpaca.Markets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advanced_Stock_Trader.Trader.Data;

namespace Advanced_Stock_Trader.Trader.Api
{
    public class MakeTransaction
    {
        public async Task Buy(Settings s, string Symbol, int Amount)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaTradingClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var order = await client.PostOrderAsync(MarketOrder.Buy(Symbol, (Alpaca.Markets.OrderQuantity)Amount));
        }

        public async Task Sell(Settings s, string Symbol)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaTradingClient(new SecretKey(s.API_KEY, s.API_SECRET));

            var cryptoPosition = await client.GetPositionAsync(Symbol);

            OrderQuantity oq = OrderQuantity.Fractional(cryptoPosition.Quantity);

            await client.PostOrderAsync(MarketOrder.Sell(Symbol, oq).WithDuration(TimeInForce.Day));
        }
    }
}
