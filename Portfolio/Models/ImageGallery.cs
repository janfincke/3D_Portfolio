using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class ImageGallery
    {
        public ImageGallery()
        {
            ImageList = new List<string>();
        }

        public List<string> ImageList { get; private set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        
    }
}