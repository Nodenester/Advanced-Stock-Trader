using Advanced_Stock_Trader.Trader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using Advanced_Stock_Trader.Trader.Api;

namespace Advanced_Stock_Trader.Trader.MainFuncs.ExacuteOrderMath
{
    public class CalculatBuyAmount
    {
        GetAccountData gad = new GetAccountData();
        public async Task<int> GetBuyAmount(Settings s, float cp, float Risk, int sa)
        {
            IAccount ad = await gad.AccountData(s);
            float cash = (float)ad.DayTradingBuyingPower;
            return (int)(((cash / sa) / Risk) / cp);
        }
    }
}
