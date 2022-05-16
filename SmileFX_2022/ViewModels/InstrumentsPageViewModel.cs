using SmileFX_2022.Models;
using SmileFX_2022.Services;
using SmileFX_2022.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace SmileFX_2022.ViewModels 
{
    public class InstrumentsPageViewModel : ViewModelBase
    {
        // Ez a kezdeti instrumentumok listája, ehhez lehet majd hozzáadni
        // public List<string> Names { get; set; } = new List<string>{ "EUR_USD", "USD_CHF", "AUD_USD" };

        // TODO get data from webservice
        public ObservableCollection<Instrument> Instruments { get; set; }
            = new ObservableCollection<Instrument>();

        // A charthoz
        public ObservableCollection<CandleChartModel> StockPriceDetails = new ObservableCollection<CandleChartModel>();


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new NetworkService();

            foreach (var instName in InstrumentService.Instance.GetAll())
            {
                var instItem = await service.GetInstrumentAsync(instName, "S5");
                Instruments.Add(instItem);
            }

            int siz = Instruments[0].Candles.Count;

            for (int i = 0; i < siz; i++)
            {
                this.StockPriceDetails.Add(new CandleChartModel()
                {
                    Date = DateTime.Parse(Instruments[0].Candles[0].time),
                    Open = Double.Parse(Instruments[0].Candles[0].mid.Open),
                    High = Double.Parse(Instruments[0].Candles[0].mid.High),
                    Low = Double.Parse(Instruments[0].Candles[0].mid.Low),
                    Close = Double.Parse(Instruments[0].Candles[0].mid.Close)
                });
            }

            await base.OnNavigatedToAsync(parameter, mode, state);

        }


        // A MainPage oldalról navigálhatunk egyrészt az AddPosition, másrészt az AddInstrument oldalakra
        // És... valószínűleg jó lenne közvetlenül elérni a PositionsPage-et is 
        public void NavigateToAddInstrument()
        {
            NavigationService.Navigate(typeof(AddInstrumentPage));
        }


        public void NavigateToAddPosition(Instrument inst)
        {
            NavigationService.Navigate(typeof(CreateOrderPage), inst);
        }


        public void NavigateToTrades()
        {
            NavigationService.Navigate(typeof(TradesPage));
        }


        public async void Refresh()
        {
            var service = new NetworkService();

            ObservableCollection<Instrument> NewInstruments = new ObservableCollection<Instrument>();

            //Instruments.Clear();

            foreach (var instName in InstrumentService.Instance.GetAll())
            {
                var instItem = await service.GetInstrumentAsync(instName, "S5");
                NewInstruments.Add(instItem);
            }           
            
            Instruments.Clear();

            foreach (var item in NewInstruments)
            {
                Instruments.Add(item);
                
                // Instruments
                // aaahttps://stackoverflow.com/questions/49226894/writing-observablecollection-to-json-file
                // File.WriteAllText(@"./MainDataContext" + ".json", JsonConvert.SerializeObject(DataContext));


            }

        }
    }
}
