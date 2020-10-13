using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Controllers;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.TransactionModels;
using TransactionManagement.MVC.Services;

namespace Joshify.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService();
            var model = service.GetTransactions();

            return View(model);
        }

        public ActionResult Create()
        {
            var customerService = new CustomerService();
            var customers = customerService.GetCustomers();
            var grape = new SelectList(customers, "CustomerId", "FullName");
            ViewBag.Customers = grape;

            var supplierService = new SupplierService();
            var suppliers = supplierService.GetSuppliers();
            var banana = new SelectList(suppliers, "SupplierId", "Company");
            ViewBag.Suppliers = banana;

            var productService = new ProductService();
            var products = productService.GetProducts();
            var orange = new SelectList(products, "ProductId", "Name");
            ViewBag.Products = orange;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be created.");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);
            var model =
                new TransactionEdit
                {
                    CustomerId = detail.CustomerId,
                    SupplierId = detail.SupplierId,
                    ProductId = detail.ProductId,
                    DatePlaced = detail.DatePlaced,
                    Quantity = detail.Quantity,
                    Notes = detail.Notes
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransactionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your transaction could not be updated.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "Your transaction was deleted";

            return RedirectToAction("Index");
        }

        private TransactionService CreateTransactionService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService();
            return service;
        }
    }
}
