using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Services
{
    public class InstrumentService
    {

        // Ezen property-n keresztül érjük el a Singleton InstrumentService osztály 
        // egyetlen példányát
        // A Singleton Service osztályra mindenekelőtt a különböző ViewModel-ek közötti
        // adatátadás miatt van szükség
        public static InstrumentService Instance { get; } = new InstrumentService();


        private List<string> instrumentList = new List<string>
        {
            "EUR_USD", "USD_CHF", "AUD_USD"
        };


        // Fontos a protected láthatóság, így biztosítjuk hogy
        // a kezdeti példányosítás után a továbbiakban már
        // ne lehessen példányosítani az osztályt
        protected InstrumentService() { }


        // Instrumentum felvétele a listába
        public void AddInstrument(string name)
        {
            instrumentList.Add(name);
        }


        // Az instrumentList tagváltozó Getter metódusa
        public List<string> GetAll()
        {
            return instrumentList;
        }


    }
}
