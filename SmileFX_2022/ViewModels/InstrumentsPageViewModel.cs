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
        // Instrumentumokat tároló ObservableCollection
        public ObservableCollection<Instrument> Instruments { get; set; }
            = new ObservableCollection<Instrument>();


        // Ez a függvény hívódik meg ha az InstrumentsPage-re navigálunk
        // Ekkor töltjük fel instrumentumokkal az Instruments propertyt
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new NetworkService();

            foreach (var instName in InstrumentService.Instance.GetAll())
            {
                var instItem = await service.GetInstrumentAsync(instName, "S5");
                Instruments.Add(instItem);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);

        }


        // Az InstrumentsPage-ről az AddInstrumentPage-re navigálunk        
        public void NavigateToAddInstrument()
        {
            NavigationService.Navigate(typeof(AddInstrumentPage));
        }


        // Egy listaelemre kattintva a CreateOrderPage-re tudunk navigálni,
        // paraméterben átadva a listában kiválasztott instrumentumot
        public void NavigateToCreateOrder(Instrument inst)
        {
            NavigationService.Navigate(typeof(CreateOrderPage), inst);
        }


        // Frissítjük az oldal tartalmát
        // Ilyenkor a NetworkService-en keresztül frissítjük az Instrumentumok értékét
        public async void Refresh()
        {
            var service = new NetworkService();

            ObservableCollection<Instrument> NewInstruments = new ObservableCollection<Instrument>();

            foreach (var instName in InstrumentService.Instance.GetAll())
            {
                var instItem = await service.GetInstrumentAsync(instName, "S5");
                NewInstruments.Add(instItem);
            }           
            
            Instruments.Clear();

            foreach (var item in NewInstruments)
            {
                Instruments.Add(item);               
            }

        }

        // Mentéshez
        // Instruments
        // aaahttps://stackoverflow.com/questions/49226894/writing-observablecollection-to-json-file
        // File.WriteAllText(@"./MainDataContext" + ".json", JsonConvert.SerializeObject(DataContext));


    }
}
