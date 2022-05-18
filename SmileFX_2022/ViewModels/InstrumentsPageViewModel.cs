using SmileFX_2022.Models;
using SmileFX_2022.Services;
using SmileFX_2022.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Controls;

namespace SmileFX_2022.ViewModels 
{
    public class InstrumentsPageViewModel : ViewModelBase, INavigable
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


        public DelegateCommand SaveCommand { get; }
        
        public DelegateCommand RefreshCommand { get; }


        // Konstruktor, ahol a RefreshCommand metódusreferenciát a Refresh függvénnyel hozzuk létre,
        // a SaveCommand metódusreferenciát pedig a Save függvénnyel hozzuk létre
        public InstrumentsPageViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            RefreshCommand = new DelegateCommand(Refresh);
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


        // Instrumentumok adatainak fájlba írása
        public async void Save()
        {
            var savedContent = JsonConvert.SerializeObject(Instruments);

            Windows.Storage.StorageFolder storageFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
            
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("myInstruments.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);


            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, savedContent);


            //string path = @"c:\work\MyTest.txt";
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello");
            //        sw.WriteLine("And");
            //        sw.WriteLine("Welcome");
            //    }
            //}

            //string fileName = @"C:\work\myfile.txt";
            //FileStream fs = FileStream. File.Create(fileName);

            //StreamWriter File = new StreamWriter("Test_File.txt");
            //File.Write(savedContent);
            // System.IO.File.WriteAllText(@"C:\work\myfile.txt", savedContent);

        }

   
    }
}
