using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XConcept.Models;

namespace XConcept.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

          public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
         public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

         public ActionResult Create()
        {
            return View();
        }




        [HttpPost] 
        public ActionResult Create( Product product)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    message = "Successfully Saved";
                }
                catch (Exception)
                {
                    message = " Error please try again";
                }
                return RedirectToAction("Index");
            }
            else
            {
                message = "Please provide requerido fileds value ";
            }

            if (Request.IsAjaxRequest())
            {
                return  new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
            else
            {
                ViewBag.Message = message;
                return View(product);
            }
           
        }





         public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
          public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
          [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
