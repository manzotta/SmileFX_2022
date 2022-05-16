using SmileFX_2022.Models;
using SmileFX_2022.Services;
using SmileFX_2022.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace SmileFX_2022.ViewModels
{
    public class AddInstrumentPageViewModel : ViewModelBase
    {

        // The base currency is the first currency stated in a currency pair quote.
        // For example, in USD/EUR, the U.S.dollar is the base currency.
        // The second currency is the quote currency,
        //  which states how much of the quote currency is required to buy one unit of the base currency.

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


        public DelegateCommand AddInstrumentCommand { get; }


        public AddInstrumentPageViewModel()
        {
            AddInstrumentCommand = new DelegateCommand(AddNewInstrument);
        }


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
        }


        private void AddNewInstrument()
        {
            InstrumentService.Instance.AddInstrument($"{BaseCurrency}_{QuoteCurrency}");

            // Esetleg ilyenkor vissza lehetne navigálni a főoldalra(?)
            NavigationService.Navigate(typeof(MainPage));

        }

    }

}
