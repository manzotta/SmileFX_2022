using SmileFX_2022.Models;
using SmileFX_2022.Services;
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
        public ObservableCollection<Trade> Trades { get; set; }
            = new ObservableCollection<Trade>();

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


    }
}
