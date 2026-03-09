using Advanced_Stock_Trader.Trader.Data;
using Advanced_Stock_Trader.Trader.DataBase;
using Alpaca.Markets;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.Api
{
    public class GetAccountData
    {
        public async Task<IAccount> AccountData(Settings s)
        {
            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaTradingClient(new SecretKey(s.API_KEY, s.API_SECRET));

            return await client.GetAccountAsync();
        }
    }
}
