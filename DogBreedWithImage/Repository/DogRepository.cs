using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DogBreedWithImage;
using Newtonsoft.Json;

namespace DogAPI.Repository
{


    public class DogResponse
    {
        public string Status { get; set; }
        public List<string> Message { get; set; }
    }

    public class ImageResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
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
            var responseObject = JsonConvert.DeserializeObject<DogResponse>(content);

            return responseObject.Message;
        }


        public async Task<string> GetImageList(String name)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_dogBaseUrl + "breed/" + name + "/images/random");

            //some logic
            var content = await response.Content.ReadAsStringAsync();
            var url = JsonConvert.DeserializeObject<ImageResponse>(content);

            return url.Message;
        }

        public async Task<List<DogBI>> loadBothAsync()
        {

            List<String> _alist = new List<string>();
            _alist = await GetBreedList();
            List<DogBI> doglist = new List<DogBI>();
            
            for (int i = 0; i < 10; i++)
            {
                doglist.Add(
                            new DogBI(){
                                        Name = _alist[i], 
                                        Image = await GetImageList(_alist[i])
                                        }
                            );
                
            }
            return doglist;




        }
    }
}