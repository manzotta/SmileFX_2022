using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{
    public class Instrument
    {
        public List<Candle> Candles { get; set; }
        public string Granularity { get; set; }
        public string instrument { get; set; } // Ezt nagy betűvel kellene... és akkor a modell osztályt is átneveztni
    }

    public class Candle
    {
        public bool complete { get; set; }
        public Mid mid { get; set; }
        public string time { get; set; }
        public int volume { get; set; }
    }

    public class Mid
    {
        [JsonProperty("c")]
        public string Close { get; set; }

        [JsonProperty("h")]
        public string High { get; set; }

        [JsonProperty("l")]
        public string Low { get; set; }

        [JsonProperty("o")]
        public string Open { get; set; }

    }
}
