using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DogAPI.Repository
{
    public class DogImageResponse
    {
        public string ImageUrl { get; set; }
    }
    public class DogImageRepository
    {
        private string _dogBaseUrl;
        public DogImageRepository()
        {
            _dogBaseUrl = "https://dog.ceo/api/";
        }

        public async Task<string> GetImageList(String name)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_dogBaseUrl +"breed/"+name+"/images/random");

            //some logic
            var content = await response.Content.ReadAsStringAsync();
            var url = JsonConvert.DeserializeObject<DogImageResponse>(content);
            
            return url.ImageUrl;
        }
    }
}