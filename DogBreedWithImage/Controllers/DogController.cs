using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace DogBreedWithImage.Controllers
{
    [Route("api/[controller]")]
    public class DogController : Controller
    {

        private readonly DogRepository _anInstance;

        public DogController()
        {
            _anInstance = new DogRepository();
        }


        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<DogBI>> Get() => await _anInstance.loadBothAsync();

    }
}
