using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Models;

namespace TransactionManagement.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> transactionList = _db.Transactions.ToList();
            List<Transaction> orderedList = transactionList.OrderBy(t => t.DatePlaced).ToList();
            return View(orderedList);
        }

        // GET: Transaction
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _db.Customers.Find(transaction.CustomerId);
                if (customer == null)
                    return HttpNotFound("Customer not found");

                Product product = _db.Products.Find(transaction.ProductId);
                if (product == null)
                    return HttpNotFound("Product not found");

                if (transaction.Quantity > product.InventoryCount)
                    return HttpNotFound("There is not enough inventory for this transaction");

                _db.Transactions.Add(transaction);
                product.InventoryCount -= transaction.Quantity;
                _db.SaveChanges();
                TempData["SaveResult"] = "Your transaction was created";
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Edit
        // Transaction/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }
        
        // POST: Edit
        // Transaction/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                TempData["SaveResult"] = "Your transaction was updated";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }
        // GET: Delete
        // Transaction/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

        // POST: Delete
        // Transaction/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Transaction transaction = _db.Transactions.Find(id);
            Product product = _db.Products.Find(transaction.ProductId);
            product.InventoryCount += transaction.Quantity;
            _db.Transactions.Remove(transaction);
            TempData["SaveResult"] = "Your transaction was deleted";

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: Details
        // Transaction/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

    }
}