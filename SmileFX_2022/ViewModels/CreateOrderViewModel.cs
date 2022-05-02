using SmileFX_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace SmileFX_2022.ViewModels
{
    public class CreateOrderViewModel : ViewModelBase
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



        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var underlyingInst = (Instrument)parameter;

            this.BaseCurrency = underlyingInst.instrument.Substring(0, 3);
            this.QuoteCurrency = underlyingInst.instrument.Substring(4, 3);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

    }

}
