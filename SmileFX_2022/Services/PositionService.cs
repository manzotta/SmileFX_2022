using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Services
{
    public class PositionService
    {
        public static PositionService Instance { get; } = new PositionService();

        private List<string> instrumentList = new List<string>
        {
            "EUR_USD", "USD_CHF", "AUD_USD"
        };

        protected PositionService() { }


        public void AddInstrument(string name)
        {
            instrumentList.Add(name);
        }

        //public TodoItem GetItem(int id)
        //{
        //    return items[id];
        //}

        public List<string> GetAll()
        {
            return instrumentList;
        }
    }
}
