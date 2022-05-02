using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{

    public class Trade
    {
        public string id { get; set; }
        public string instrument { get; set; }
        public string price { get; set; }
        public string openTime { get; set; }
        public string initialUnits { get; set; }
        public string initialMarginRequired { get; set; }
        public string state { get; set; }
        public string currentUnits { get; set; }
        public string realizedPL { get; set; }
        public string financing { get; set; }
        public string dividendAdjustment { get; set; }
        public string unrealizedPL { get; set; }
        public string marginUsed { get; set; }
    }

}
