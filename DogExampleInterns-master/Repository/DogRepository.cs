using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DogAPI.Repository
{
    public class DogResponse
    {
        public string Status { get; set; }
        public List<string> Message { get; set; }
    }
    public class DogRepository
    {
        private string _dogBaseUrl;
        public DogRepository()
        {
            _dogBaseUrl = "https://dog.ceo/api/";
        }

        public async Task<List<string>> GetBreedList()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_dogBaseUrl + "breeds/list");

            //some logic
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<DogResponse>(content);

            return list.Message;
        }
    }
}