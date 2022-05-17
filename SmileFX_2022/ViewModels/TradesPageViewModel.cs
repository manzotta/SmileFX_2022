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
    public class TradesPageViewModel : ViewModelBase
    {
        
        // Az ügyleteket tartalmazó ObservableCollection
        public ObservableCollection<Trade> Trades { get; set; }
            = new ObservableCollection<Trade>();


        // Ez a függvény hívódik meg, ha az alkalmazásban a TradesPage-re navigálunk
        // Ilyenkor a NetworkSerive GetTradesAsync() metódusát meghívva feltöltjük elemekkel a Trades propertyt
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new NetworkService();

            var tradeList = await service.GetTradesAsync();

            foreach (var tradeItem in tradeList.Trades.OrderBy(x => x.id))
            {
                Trades.Add(tradeItem);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);

        }


        // A TradesPage oldalról a CreateOrderPage-re navigálunk
        public void NavigateToCreateOrder()
        {
            NavigationService.Navigate(typeof(CreateOrderPage));
        }


        // Frissítjük az oldal tartalmát
        // Ilyenkor a NetworkService-en keresztül frissítjük a Trades elemeinek,
        // vagyis a nyitott ügyleteknek az értékét
        public async Task Refresh()
        {
            var service = new NetworkService();
            var tradeList = await service.GetTradesAsync();

            ObservableCollection<Trade> NewTrades = new ObservableCollection<Trade>();

            foreach (var tradeItem in tradeList.Trades.OrderBy(x => x.id))
            {
                NewTrades.Add(tradeItem);
            }

            Trades.Clear();

            foreach (var item in NewTrades)
            {
                Trades.Add(item);
            }
        }
 
    
    }
}
