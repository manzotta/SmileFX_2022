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
    // Elég alaposan át kell írni és ki kell bővíteni...
    public class NetworkService
    {

        // private readonly Uri serverUrl = new Uri("https://api-fxtrade.oanda.com/v3/instruments/");

        private readonly Uri serverUrl = new Uri("https://api-fxpractice.oanda.com/v3/accounts/101-004-17118873-001/instruments/");


        private readonly string token = "aa8a0d297459c8aa6ad774f10e2a0f5e-b7e114be1f65321b394a4ecf4f9255aa";


        /*
        public async Task<List<RecipeGroup>> GetRecipeGroupsAsync()
        {
            return await GetAsync<List<RecipeGroup>>(new Uri(serverUrl, "api/Recipes/Groups"));
        }
        */


        public async Task<Instrument> GetInstrumentAsync(string instrumentName, string granularity)
        {
            return await GetAsync<Instrument>(new Uri(serverUrl, $"{instrumentName}/candles?" +
                $"granularity={granularity}&count=1"));
        }


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


        private async void PostAsync<T>(Uri uri, HttpContent content)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.PostAsync(uri, content);

            }
        }

    }
}
