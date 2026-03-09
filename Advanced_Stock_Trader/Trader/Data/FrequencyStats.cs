using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced_Stock_Trader.Trader.Data
{
    public class Frequency
    {
        public float Proffit { get; set; }
        public int Frequensy { get; set; }
        public float Stabillity { get; set; }
        public List<float> HighLow { get; set; }
        public List<float> Highs { get; set; }
        public List<float> Lows { get; set; }
        public float Diffrens { get; set; }
    }
}
