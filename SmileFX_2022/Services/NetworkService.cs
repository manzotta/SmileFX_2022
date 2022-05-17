using Newtonsoft.Json;
using SmileFX_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Services
{   
    
    public class NetworkService
    {

     
        private readonly Uri serverUrl = new Uri("https://api-fxpractice.oanda.com/v3/accounts/");

        private readonly string account = "101-004-17118873-001";

        private readonly string token = "aa8a0d297459c8aa6ad774f10e2a0f5e-b7e114be1f65321b394a4ecf4f9255aa";


        // A paraméterben megadott nevű instrumentum (devizapár) adatainak letöltése a szerverről
        // A granularity paraméter az instrumentumhoz tartozó tőzsedi gyertya időtartamára utal
        // Azért két gyertyát töltünk le, hogy mindig rendelkezésre álljon az utolsó lezárt gyertya adata
        public async Task<Instrument> GetInstrumentAsync(string instrumentName, string granularity)
        {
            return await GetAsync<Instrument>(new Uri(serverUrl, $"{this.account}/instruments/{instrumentName}/candles?" +
                $"granularity={granularity}&count=2"));
        }

        
        // A demo számlához tartozó nyitott ügyletek (pozíciók) letöltése
        public async Task<TradesResponse> GetTradesAsync()
        {
            return await GetAsync<TradesResponse>(new Uri(serverUrl, $"{this.account}/trades"));
        }


        // Piaci megbízás a paraméterben megadott HttpContent alapján
        // A POST típusú HTTP request Body-ját adjuk meg 
        public async Task<HttpResponseMessage> PostOrder(HttpContent content)
        {

            return await PostAsync<OrderContent>(new Uri("https://api-fxpractice.oanda.com/v3/accounts/101-004-17118873-001/orders"), content);
        }


        // Generikus metódus GET típusú REST API hívásokhoz
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        
        // Generikus metódus POST típusú REST API hívásokhoz
        private async Task<HttpResponseMessage> PostAsync<T>(Uri uri, HttpContent content)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PostAsync(uri, content);
                return response;
                
            }
        }

    }
}
