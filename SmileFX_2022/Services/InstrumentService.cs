using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Services
{
    public class InstrumentService
    {

        public static InstrumentService Instance { get; } = new InstrumentService();


        private List<string> instrumentList = new List<string>
        {
            "EUR_USD", "USD_CHF", "AUD_USD"
        };


        protected InstrumentService() { }


        public void AddInstrument(string name)
        {
            instrumentList.Add(name);
        }


        public List<string> GetAll()
        {
            return instrumentList;
        }


    }
}
