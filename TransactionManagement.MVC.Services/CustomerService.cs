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

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id);
                // && e.OwnerId == _userId);

                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        Title = entity.Title,
                        Company = entity.Company,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        UserSince = entity.UserSince,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId);
                // && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.Title = model.Title;
                entity.Company = model.Company;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.UserSince = model.UserSince;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);
                        //&& e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
