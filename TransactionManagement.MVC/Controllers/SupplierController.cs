using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Models;

namespace TransactionManagement.MVC.Controllers
{
    public class SupplierController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(_db.Suppliers.ToList());
        }

        // GET: Supplier
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Suppliers.Add(supplier);
                TempData["SaveResult"] = "Your supplier was created";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET
        // Supplier/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Supplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }

        // POST: Delete
        // Supplier/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Supplier supplier = _db.Suppliers.Find(id);
            _db.Suppliers.Remove(supplier);
            TempData["SaveResult"] = "Your supplier was deleted";
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit
        // Supplier/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }

        // POST: Edit
        // Supplier/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(supplier).State = EntityState.Modified;
                TempData["SaveResult"] = "Your supplier was updated"
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Details
        // Supplier/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = _db.Suppliers.Find(id);

            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }
    }
}