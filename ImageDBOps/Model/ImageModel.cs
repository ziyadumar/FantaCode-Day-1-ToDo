using System.ComponentModel.DataAnnotations;
using System;

namespace ImageDBops
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageData { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
    }
}
