using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.CustomerModels;

namespace TransactionManagement.MVC.Controllers
{
    public class CustomerService
    {
        //private readonly Guid _userId;

        //public CustomerService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    // OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Title = model.Title,
                    Company = model.Company,
                    UserSince = model.UserSince,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        // .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    Title = e.Title,
                                    Company = e.Company,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    UserSince = e.UserSince,
                                    PhoneNumber = e.PhoneNumber,
                                    Address = e.Address,
                                    Notes = e.Notes
                                }
                        );

                return query.ToArray();
            }
        }
}
}
