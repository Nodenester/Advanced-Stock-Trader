using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.Data
{
    public class Settings
    {
        public string API_KEY { get; set; }
        public string API_SECRET { get; set; }
        public float Risk { get; set; }
        public float BuyProcent { get; set; }
        public int Mins { get; set; }
    }
}
