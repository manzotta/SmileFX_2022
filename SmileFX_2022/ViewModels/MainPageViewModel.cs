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

        // Ez a függvény hívódik meg amikor az oldalra navigálunk
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
        }


        // A MainPage oldalról az InstrumentsPage oldalra naviáglunk
        public void NavigateToInstruments()
        {
            NavigationService.Navigate(typeof(InstrumentsPage));
        }


        // A MainPage oldalról a TradesPage oldalra naviáglunk
        public void NavigateToTrades()
        {
            NavigationService.Navigate(typeof(TradesPage));
        }
    
    }

}
