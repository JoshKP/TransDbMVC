using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
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

        public ActionResult RetrieveImage(int id)
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SupplierService();
            byte[] cover = service.GetImageFromDB(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public SupplierDetail GetSupplierById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == id);
                // && e.OwnerId == _userId);
                return
                    new SupplierDetail
                    {
                        SupplierId = entity.SupplierId,
                        Company = entity.Company,
                        SalesRep = entity.SalesRep,
                        UserSince = entity.UserSince,
                        Phone = entity.Phone,
                        Address = entity.Address,
                        Category = entity.Category,
                        Notes = entity.Notes,
                        Image = entity.Image
                    };
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierCreate model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];


            if (!ModelState.IsValid) return View(model);

            var service = CreateSupplierService();

            if (service.CreateSupplier(file, model))
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
                    SupplierId = detail.SupplierId,
                    Company = detail.Company,
                    SalesRep = detail.SalesRep,
                    UserSince = detail.UserSince,
                    Phone = detail.Phone,
                    Address = detail.Address,
                    Category = detail.Category,
                    Notes = detail.Notes,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupplierEdit model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            if (!ModelState.IsValid) return View(model);

            if (model.SupplierId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSupplierService();

            if (service.UpdateSupplier(file, model))
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
