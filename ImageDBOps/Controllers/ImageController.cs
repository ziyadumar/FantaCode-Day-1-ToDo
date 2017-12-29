using System.Collections.Generic;
using ImageDBops;
using ImageDBops.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ImageDBops
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        private readonly ImageRepository imageRepository;

        public ImageController()
        {
            imageRepository = new ImageRepository();
        }


        //Display all
        [HttpGet]
        public IEnumerable<ImageModel> Get() => imageRepository.GetAll();


        [HttpGet("{id}")]
        public ImageModel ViewbyID(int id)
        {
            if (ModelState.IsValid)
            {
                return imageRepository.View(id);
            }
            else return null;
        }

        // POST api/todo
        //Insert
        [HttpPost]
        public void Post([FromBody]ImageModel imgmdl)
        {
            if (ModelState.IsValid)
                imageRepository.Add(imgmdl);
        }

        // PUT api/todo/5
        //Update tasks and descrip
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ImageModel imgmdl)
        {
            imgmdl.ImageId = id;
            if (ModelState.IsValid)
                imageRepository.Update(imgmdl);
        }

        [HttpPut("done/{id}")]
        public void DoneOnly(int id, [FromBody]ImageModel imgmdl)
        {
            imgmdl.ImageId = id;
            if (ModelState.IsValid)
                imageRepository.Done(imgmdl);
        }

        //Delete
        [HttpDelete("{id}")]
        public ImageModel Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return imageRepository.Delete(id);
            }
            else return null;
        }
    }
}