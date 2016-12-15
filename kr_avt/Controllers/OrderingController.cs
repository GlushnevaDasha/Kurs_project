using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kr_avt.Models;

namespace kr_avt.Controllers
{
    public class OrderingController : Controller
    {
        private AgencyEntities db = new AgencyEntities();

        //
        // GET: /Ordering/

        public ActionResult Index()
        {
            var ordering = db.Ordering.Include(o => o.Sale).Include(o => o.User).Include(o => o.Product);
            return View(ordering.ToList());
        }

        //
        // GET: /Ordering/Details/5

        public ActionResult Details(int id = 0)
        {
            Ordering ordering = db.Ordering.Find(id);
            if (ordering == null)
            {
                return HttpNotFound();
            }
            return View(ordering);
        }

        //
        // GET: /Ordering/Create

        public ActionResult Create()
        {
            ViewBag.ActionId = new SelectList(db.Sale, "Id", "Name");
            ViewBag.Client = new SelectList(db.User, "Surnamee", "Surname");
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Name");
            return View();
        }

        //
        // POST: /Ordering/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ordering ordering)
        {
            if (ModelState.IsValid)
            {
                db.Ordering.Add(ordering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActionId = new SelectList(db.Sale, "Id", "Name", ordering.ActionId);
            ViewBag.Client = new SelectList(db.User, "Surname", "Surname", ordering.Client);
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Name", ordering.ProductName);
            return View(ordering);
        }

        //
        // GET: /Ordering/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ordering ordering = db.Ordering.Find(id);
            if (ordering == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActionId = new SelectList(db.Sale, "Id", "Name", ordering.ActionId);
            ViewBag.Client = new SelectList(db.User, "Surname", "Surname", ordering.Client);
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Name", ordering.ProductName);
            return View(ordering);
        }

        //
        // POST: /Ordering/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ordering ordering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActionId = new SelectList(db.Sale, "Id", "Name", ordering.ActionId);
            ViewBag.Client = new SelectList(db.User, "Surname", "Surname", ordering.Client);
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Name", ordering.ProductName);
            return View(ordering);
        }

        //
        // GET: /Ordering/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ordering ordering = db.Ordering.Find(id);
            if (ordering == null)
            {
                return HttpNotFound();
            }
            return View(ordering);
        }

        //
        // POST: /Ordering/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordering ordering = db.Ordering.Find(id);
            db.Ordering.Remove(ordering);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

     }
}