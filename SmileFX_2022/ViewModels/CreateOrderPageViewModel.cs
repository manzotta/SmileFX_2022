using Newtonsoft.Json;
using SmileFX_2022.Models;
using SmileFX_2022.Services;
using SmileFX_2022.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace SmileFX_2022.ViewModels
{
    public class CreateOrderPageViewModel : ViewModelBase
    {
        // The base currency is the first currency stated in a currency pair quote.
        // For example, in USD/EUR, the U.S.dollar is the base currency.  
        private string baseCurrency;

        public string BaseCurrency
        {
            get { return baseCurrency; }
            set { Set(ref baseCurrency, value); }     // Property changed
        }

        // The second currency is the quote currency,
        //  which states how much of the quote currency is required to buy one unit of the base currency.  
        private string quoteCurrency;

        public string QuoteCurrency
        {
            get { return quoteCurrency; }
            set { Set(ref quoteCurrency, value); }
        }

        // A vételi és eladási pozíció megkülönböztetésére használandó property
        // Lehetne enum(?)
        private string posType;

        public string PosType
        {
            get { return posType; }
            set { Set(ref posType, value); }
        }


        public DelegateCommand CreateOrderCommand { get; }


        // Konstruktor, ahol a CreateOrderCommand metódusreferenciát a CreatreOrder függvénnyel hozzuk létre
        public CreateOrderPageViewModel()
        {
            CreateOrderCommand = new DelegateCommand(CreateOrder);
        }


        // Ez a függvény hívódik meg, ha a CreateOrderPage-re navigálunk
        // Amennyiben az InstrumentsPage-ről érkezünk, tehát ott egy listaelemre kattintottunk, 
        // akkor a paraméterben kapott instrumentum alapján feltöltjük a BaseCurrency és a QuoteCurrency propertyk értékét
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var underlyingInst = (Instrument)parameter;

            if (underlyingInst != null)
            {
                this.BaseCurrency = underlyingInst.instrument.Substring(0, 3);            
                this.QuoteCurrency = underlyingInst.instrument.Substring(4, 3);
            }           
            
            await base.OnNavigatedToAsync(parameter, mode, state);        
        
        }


        // Piaci megbízás rögzítése
        // Itt hozzuk létre azt az OrderContent típusú objektumot,
        // amit aztán sorosítva átadunk a NetworkService PostOrder függvényének
        private async void CreateOrder()
        {
            string orderUnits;

            if (this.PosType == "Long")
                orderUnits = "1";
            else if (this.PosType == "Short")
                orderUnits = "-1";
            else return;

            OrderContent myOrder = new OrderContent { order = new Order {
                instrument = $"{BaseCurrency}_{QuoteCurrency}",
                units = "1",
                timeInForce = "FOK",
                type = "MARKET",
                positionFill = "DEFAULT"
            }};

            var myContent = JsonConvert.SerializeObject(myOrder);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
         
            var service = new NetworkService();
            HttpResponseMessage message = await service.PostOrder(stringContent);

            // Ilyenkor a TradesPage-re navigálunk
            NavigationService.Navigate(typeof(TradesPage));

        }


    }

}
