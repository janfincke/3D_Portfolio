using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnectionContext db = new DbConnectionContext();
        public ActionResult Index()
        {
            var imageModel = new ImageGallery();
            var imageFiles = Directory.GetFiles(Server.MapPath("~/Content/Media/"));

            foreach (var item in imageFiles)
            {
                imageModel.ImageList.Add(Path.GetFileName(item));
            }

            return View();
        }
    }
}