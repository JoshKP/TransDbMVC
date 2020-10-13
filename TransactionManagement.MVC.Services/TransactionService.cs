using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManagement.MVC.Data;
using TransactionManagement.MVC.Models.TransactionModels;

namespace TransactionManagement.MVC.Controllers
{
    public class TransactionService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //public class TransactionService
        //{
        //    private readonly Guid _userId;

        //    public TransactionService(Guid userId)
        //    {
        //        _userId = userId;
        //    }
        //}

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        // .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId = e.TransactionId,
                                    CustomerId = e.CustomerId,
                                    SupplierId = e.SupplierId,
                                    ProductId = e.ProductId,
                                    Quantity = e.Quantity,
                                    Notes = e.Notes
                                }
                        );

                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == id);
                // && e.OwnerId == _userId);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        CustomerId = entity.CustomerId,
                        SupplierId = entity.SupplierId,
                        ProductId = entity.ProductId,
                        DatePlaced = entity.DatePlaced,
                        Quantity = entity.Quantity,
                        TotalCost = entity.TotalCost,
                        Notes = entity.Notes
                    };
            }
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    CustomerId = model.CustomerId,
                    SupplierId = model.SupplierId,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == model.TransactionId);
                // && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.SupplierId = model.SupplierId;
                entity.ProductId = model.ProductId;
                entity.Quantity = model.Quantity;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId);
                // && e.OwnerId == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
