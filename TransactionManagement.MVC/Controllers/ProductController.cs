using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.ProductModels;
using TransactionManagement.MVC.Services;

namespace TransactionManagement.MVC.Controllers
{
    
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService();
            var model = service.GetProducts();

            return View(model);
        }
        public ActionResult Create()
        {
            var supplierService = new SupplierService();
            var suppliers = supplierService.GetSuppliers();
            var banana = new SelectList(suppliers, "SupplierId", "Company");
            ViewBag.Suppliers = banana;

            return View();
        }

        public ActionResult RetrieveImage(int id)
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService();
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

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == id);
                        // && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        //SupplierId = entity.SupplierId,
                        Name = entity.Name,
                        Category = entity.Category,
                        Price = entity.Price,
                        InventoryCount = entity.InventoryCount,
                        Notes = entity.Notes,
                        Image = entity.Image
                    };
            }
        }

        // POST: Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(file, model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }

        // GET: Edit
        // Product/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    SupplierId = detail.SupplierId,
                    Name = detail.Name,
                    Category = detail.Category,
                    Price = detail.Price,
                    InventoryCount = detail.InventoryCount,
                    Notes = detail.Notes,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(file, model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        // GET: Delete
        // Product/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your product was deleted";

            return RedirectToAction("Index");
        }

        // GET: Details
        // Product/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        private ProductService CreateProductService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService();
            return service;
        }


        

    }
}
