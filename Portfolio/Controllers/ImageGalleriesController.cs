using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ImageGalleriesController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();

        // GET: ImageGalleries
        public ActionResult Index()
        {
            return View(db.ImageGallery.ToList());
        }

        // GET: ImageGalleries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // GET: ImageGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ImagePath")] ImageGallery imageGallery)
        {
            if (ModelState.IsValid)
            {
                imageGallery.ID = Guid.NewGuid();
                db.ImageGallery.Add(imageGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageGallery);
        }

        // GET: ImageGalleries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // POST: ImageGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ImagePath")] ImageGallery imageGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageGallery);
        }

        // GET: ImageGalleries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            if (imageGallery == null)
            {
                return HttpNotFound();
            }
            return View(imageGallery);
        }

        // POST: ImageGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ImageGallery imageGallery = db.ImageGallery.Find(id);
            db.ImageGallery.Remove(imageGallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
