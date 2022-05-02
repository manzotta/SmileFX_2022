using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{
    public class InstrumentList
    {
        public List<string> InstrumentNames { get; set; }

        public InstrumentList()
        {
            InstrumentNames.Add("EUR_USD");
            InstrumentNames.Add("USD_CHF");
            InstrumentNames.Add("GBP_USD");

        }

    }
}
