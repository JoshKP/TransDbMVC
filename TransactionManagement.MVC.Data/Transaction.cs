﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Transaction
    {
        [Required]
        public int TransactionId { get; set; }

        public int SupplierId { get; set; }


        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TargetedPromoId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset DatePlaced { get; set; }
        

        [Required]
        public PaymentMethod TypeOfPayment { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double TotalCost
        {
            get
            {
                double total = Product.Price * Quantity;
                return total;
            }
        }

        public string Notes { get; set; }

        public enum PaymentMethod { Cash, Check, CreditCard, PayPal, BitCoin }
    }
}