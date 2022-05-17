using SmileFX_2022.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmileFX_2022.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstrumentsPage : Page
    {
        public InstrumentsPage()
        {
            this.InitializeComponent();
        }


        // Működik a paraméter átadás az egyes ViewModel-ek között
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Instrument inst = (Instrument)e.ClickedItem;
            InstrumentsVM.NavigateToCreateOrder(inst);
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            InstrumentsVM.NavigateToAddInstrument();
        }


        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            InstrumentsVM.Refresh();
        }
    
    }
}
