using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Productos_wpf.ViewModel.Services
{
    public class RestService
    {
        HttpClient _client;
        Uri _urlBase;
        public RestService()
        {
            _urlBase = new Uri("http://gdlsoft.ddns.net:99/");
            _client = new HttpClient();
            _client.BaseAddress = _urlBase;
        }
        public List<T> GetData<T>(string url) 
        {
            List<T> TData = null;
            try
            {
                var response = _client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    TData = JsonSerializer.Deserialize<List<T>>(content)!;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return TData;       
        }

        public void Post<T>(T data, string url) 
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(url, content).Result; 
        }



    }
}
