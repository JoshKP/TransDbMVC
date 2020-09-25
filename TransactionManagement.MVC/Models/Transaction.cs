using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int TargetedPromoId { get; set; }
        public DateTimeOffset DatePlaced { get; set; }
        public PaymentMethod TypeOfPayment { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
        public string Notes { get; set; }

        public enum PaymentMethod { Cash, Check, CreditCard, PayPal, BitCoin}
    }
}