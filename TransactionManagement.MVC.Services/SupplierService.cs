using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.SupplierModels;

namespace TransactionManagement.MVC.Controllers
{
    public class SupplierService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //public class SupplierService
        //{
        //    private readonly Guid _userId;

        //    public SupplierService(Guid userId)
        //    {
        //        _userId = userId;
        //    }
        //}

        public IEnumerable<SupplierListItem> GetSuppliers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Suppliers
                        // .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SupplierListItem
                                {
                                    SupplierId = e.SupplierId,
                                    Company = e.Company,
                                    Category = e.Category,
                                    Phone = e.Phone,
                                    Notes = e.Notes,
                                    Image = e.Image
                                }
                        );

                return query.ToArray();
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

        public bool CreateSupplier(HttpPostedFileBase file, SupplierCreate model)
        {

            model.Image = ConvertToBytes(file);

            var entity =
                new Supplier()
                {
                    Company = model.Company,
                    SalesRep = model.SalesRep,
                    UserSince = model.UserSince,
                    Phone = model.Phone,
                    Address = model.Address,
                    Category = model.Category,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Suppliers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public byte[] GetImageFromDB(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var q = from temp in ctx.Suppliers where temp.SupplierId == id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }

        public bool UpdateSupplier(HttpPostedFileBase file, SupplierEdit model)
        {
            model.Image = ConvertToBytes(file);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == model.SupplierId);
                // && e.OwnerId == _userId);

                entity.Company = model.Company;
                entity.SalesRep = model.SalesRep;
                entity.UserSince = model.UserSince;
                entity.Phone = model.Phone;
                entity.Address = model.Address;
                entity.Category = model.Category;
                entity.Notes = model.Notes;
                entity.Image = model.Image;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSupplier(int supplierId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == supplierId);
                        // && e.OwnerId == _userId);

                ctx.Suppliers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

