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
    public class UserController : Controller
    {
        private AgencyEntities db = new AgencyEntities();

        //
        // GET: /User/

        public ActionResult Index()
        {
            var user = db.User.Include(u => u.Role);
            return View(user.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(string id = null)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            ViewBag.RoleName = new SelectList(db.Role, "Name", "Name");
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }

            ViewBag.RoleName = new SelectList(db.Role, "Name", "Name", user.RoleName);
            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id = null)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleName = new SelectList(db.Role, "Name", "Name", user.RoleName);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleName = new SelectList(db.Role, "Name", "Name", user.RoleName);
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(string id = null)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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