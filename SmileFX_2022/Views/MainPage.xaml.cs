using SmileFX_2022.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
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
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
            //MainPage.Navigate(typeof(MainPage));
            //TradesPage.Navigate(typeof(TradesPage));
            
        }


        private void nvSample_Loaded(object sender, RoutedEventArgs e)
        {
            // ContentFrame.Navigate(typeof(InstrumentsPage));
            // MainVM.NavigateToInstruments();
            // ContentFrame.NavigateToType(typeof(InstrumentsPage),sender.ToString,Async);
            
        }


        private void nvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            switch (item.Tag.ToString())
            {
                case "page1":
                    MainVM.NavigateToInstruments();
                    ContentFrame.Navigate(typeof(InstrumentsPage));
                    break;
                case "page2":
                    MainVM.NavigateToTrades();
                    ContentFrame.Navigate(typeof(TradesPage));
                    break;
            }
        }
    
    }

}
