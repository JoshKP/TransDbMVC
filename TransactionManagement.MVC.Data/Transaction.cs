using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Transaction
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int TargetedPromoId { get; set; }

        [Required]
        public DateTimeOffset DatePlaced { get; set; }

        [Required]
        public PaymentMethod TypeOfPayment { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double TotalCost { get; set; }

        public string Notes { get; set; }

        public enum PaymentMethod { Cash, Check, CreditCard, PayPal, BitCoin}
    }
}