using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Models.CustomerModels;

namespace TransactionManagement.MVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService();
            var model = service.GetCustomers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your customer was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService();
            return service;
        }

    }
}
