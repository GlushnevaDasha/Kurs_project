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
    public class SaleController : Controller
    {
        private AgencyEntities db = new AgencyEntities();

        //
        // GET: /Sale/

        public ActionResult Index()
        {
            var sale = db.Sale.Include(s => s.Product);
            return View(sale.ToList());
        }

        //
        // GET: /Sale/Details/5

        public ActionResult Details(int id = 0)
        {
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        //
        // GET: /Sale/Create

        public ActionResult Create()
        {
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Description");
            return View();
        }

        //
        // POST: /Sale/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sale.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductName = new SelectList(db.Product, "Name", "Description", sale.ProductName);
            return View(sale);
        }

        //
        // GET: /Sale/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Description", sale.ProductName);
            return View(sale);
        }

        //
        // POST: /Sale/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductName = new SelectList(db.Product, "Name", "Description", sale.ProductName);
            return View(sale);
        }

        //
        // GET: /Sale/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        //
        // POST: /Sale/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sale.Find(id);
            db.Sale.Remove(sale);
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