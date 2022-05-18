using Newtonsoft.Json;
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


        public DelegateCommand SaveCommand { get; }

        public DelegateCommand RefreshCommand { get; }


        // Konstruktor, ahol a RefreshCommand metódusreferenciát a Refresh függvénnyel hozzuk létre,
        // a SaveCommand metódusreferenciát pedig a Save függvénnyel hozzuk létre
        public TradesPageViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            RefreshCommand = new DelegateCommand(Refresh);
        }


        // A TradesPage oldalról a CreateOrderPage-re navigálunk
        public void NavigateToCreateOrder()
        {
            NavigationService.Navigate(typeof(CreateOrderPage));
        }


        // Frissítjük az oldal tartalmát
        // Ilyenkor a NetworkService-en keresztül frissítjük a Trades elemeinek,
        // vagyis a nyitott ügyleteknek az értékét
        public async void Refresh()
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


        // Ügyletek adatainak fájlba írása
        public async void Save()
        {
            var savedContent = JsonConvert.SerializeObject(Trades);

            Windows.Storage.StorageFolder storageFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("myTrades.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);


            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, savedContent);


        }
 
    
    }
}
