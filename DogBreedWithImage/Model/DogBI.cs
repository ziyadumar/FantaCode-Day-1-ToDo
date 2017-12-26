using System.ComponentModel.DataAnnotations;
using System;

namespace DogBreedWithImage
{
    public class DogBI
    {
        [Key]
        public String Name { get; set; }
        public string Image { get; set; }
    }
}
