using Newtonsoft.Json;
using SmileFX_2022.Models;
using SmileFX_2022.Services;
using SmileFX_2022.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace SmileFX_2022.ViewModels
{
    public class CreateOrderPageViewModel : ViewModelBase
    {
        private string baseCurrency;

        public string BaseCurrency
        {
            get { return baseCurrency; }
            set { Set(ref baseCurrency, value); }     // Property changed
        }


        private string quoteCurrency;

        public string QuoteCurrency
        {
            get { return quoteCurrency; }
            set { Set(ref quoteCurrency, value); }
        }


        public DelegateCommand CreateOrderCommand { get; }


        public CreateOrderPageViewModel()
        {
            CreateOrderCommand = new DelegateCommand(CreateOrder);
        }


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var underlyingInst = (Instrument)parameter;

            this.BaseCurrency = underlyingInst.instrument.Substring(0, 3);
            this.QuoteCurrency = underlyingInst.instrument.Substring(4, 3);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }


        private async void CreateOrder()
        {
            Order myOrder = new Order
            {
                instrument = "USD_JPY",
                units = "1",
                timeInForce = "FOK",
                type = "MARKET",
                positionFill = "DEFAULT"
            };

            // JsonContent myContent = JsonContent.Create(myOrder);

            var myContent = JsonConvert.SerializeObject(myOrder);

            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            // var service = new NetworkService();
            // var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            // var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage message = await service.PostOrder(stringContent);

            // InstrumentService.Instance.AddInstrument($"{BaseCurrency}_{QuoteCurrency}");

            // Ilyenkor a TradesPage-re navigálunk
            NavigationService.Navigate(typeof(TradesPage));

        }


    }

}
