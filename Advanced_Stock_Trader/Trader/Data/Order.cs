using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.Data
{
    public class Order
    {
        public string StockName { get; set; }
        public string Action { get; set; }
        public float Value { get; set; }
        public float Risk { get; set; }
    }
}
