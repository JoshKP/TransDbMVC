using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.CustomerModels;
using TransactionManagement.MVC.Models.ProductModels;

namespace TransactionManagement.MVC.Services
{
    public class ProductService
    {
        //private readonly Guid _userId;

        //public ProductService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var productQuery =
                    ctx
                        .Products
                        // .Where(e => e.OwnerId == _userId)
                        .Select(
                            e => new ProductListItem
                            {
                                ProductId = e.ProductId,
                                SupplierId = e.SupplierId,
                                Name = e.Name,
                                //IsStarred = e.IsStarred,
                                Category = e.Category,
                                Price = e.Price,
                                InventoryCount = e.InventoryCount
                            });

                return productQuery.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == id); //&& e.OwnerId == _userId);

                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        SupplierId = entity.SupplierId,
                        Name = entity.Name,
                        // IsStarred = entity.IsStarred,
                        Category = entity.Category,
                        Price = entity.Price,
                        InventoryCount = entity.InventoryCount,
                        Notes = entity.Notes,
                    };
            }
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product
                {
                    // OwnerId = _userId,
                    SupplierId = model.SupplierId,
                    Name = model.Name,
                    Category = model.Category,
                    Price = model.Price,
                    InventoryCount = model.InventoryCount,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == model.ProductId);  // && e.OwnerId == _userId);

                entity.SupplierId = model.SupplierId;
                entity.Name = model.Name;
                entity.IsStarred = model.IsStarred;
                entity.Category = model.Category;
                entity.Price = model.Price;
                entity.InventoryCount = model.InventoryCount;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == productId); 
                                        // && e.OwnerId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}