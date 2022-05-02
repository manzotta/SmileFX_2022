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
    public class MainPageViewModel : ViewModelBase
    {

        // Ez a kezdeti instrumentumok listája, ehhez lehet majd hozzáadni
        // public List<string> Names { get; set; } = new List<string>{ "EUR_USD", "USD_CHF", "AUD_USD" };

        // TODO get data from webservice
        public ObservableCollection<Instrument> Instruments { get; set; }
            = new ObservableCollection<Instrument>();


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


        //public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        //{
        //    var service = new NetworkService();
        //    var recipeGroups = await service.GetRecipeGroupsAsync();

        //    foreach (var item in recipeGroups)
        //    {
        //        Instruments.Add(item);
        //    }
        //    await base.OnNavigatedToAsync(parameter, mode, state);
        //}


        //public MainPageViewModel(INavigationService navigationService)
        //{
        //    _navigationService = navigationService;

        //    // AddInstrumentCommand = new RelayCommand()
        //}


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

    }

}
