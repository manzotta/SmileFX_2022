using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{
    public class CandleChartModel
    {
        public DateTime Date { get; set; }
        
        public double High { get; set; }
        
        public double Low { get; set; }
        
        public double Open { get; set; }
        
        public double Close { get; set; }
    }
}
