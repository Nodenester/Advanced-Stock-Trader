using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.Data
{
    public class Stock
    {
        public string StockName { get; set; }
        public bool HaveOrder { get; set; }
        public float CurrentPrice { get; set; }
    }
}
