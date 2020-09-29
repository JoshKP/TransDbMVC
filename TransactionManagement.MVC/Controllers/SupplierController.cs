﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Models.SupplierModels;

namespace TransactionManagement.MVC.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SupplierService();
            var model = service.GetSuppliers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSupplierService();

            if (service.CreateSupplier(model))
            {
                TempData["SaveResult"] = "Your supplier was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Supplier could not be created.");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSupplierService();
            var detail = service.GetSupplierById(id);
            var model =
                new SupplierEdit
                {
                    Company = detail.Company,
                    SalesRep = detail.SalesRep,
                    UserSince = detail.UserSince,
                    Phone = detail.Phone,
                    Address = detail.Address,
                    Category = detail.Category,
                    Notes = detail.Notes
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupplierEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SupplierId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSupplierService();

            if (service.UpdateSupplier(model))
            {
                TempData["SaveResult"] = "Your supplier was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your supplier could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSupplierService();
            var model = svc.GetSupplierById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSupplierService();

            service.DeleteSupplier(id);

            TempData["SaveResult"] = "Your supplier was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSupplierService();
            var model = svc.GetSupplierById(id);

            return View(model);
        }

        private SupplierService CreateSupplierService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SupplierService();
            return service;
        }

    }
}
