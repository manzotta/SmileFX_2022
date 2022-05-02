using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{


    public class Position
    {
        public string instrument { get; set; }
        public Long _long { get; set; }
        public Short _short { get; set; }
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public string financing { get; set; }
        public string commission { get; set; }
        public string dividendAdjustment { get; set; }
        public string guaranteedExecutionFees { get; set; }
        public string unrealizedPL { get; set; }
        public string marginUsed { get; set; }
    }

    public class Long
    {
        public string units { get; set; }
        public string averagePrice { get; set; }
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public string financing { get; set; }
        public string dividendAdjustment { get; set; }
        public string guaranteedExecutionFees { get; set; }
        public string[] tradeIDs { get; set; }
        public string unrealizedPL { get; set; }
    }

    public class Short
    {
        public string units { get; set; }
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public string financing { get; set; }
        public string dividendAdjustment { get; set; }
        public string guaranteedExecutionFees { get; set; }
        public string unrealizedPL { get; set; }
    }


}
