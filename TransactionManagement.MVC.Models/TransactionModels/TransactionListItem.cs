using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.TransactionModels
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }

        public int CustomerId { get; set; }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }

        public int TargetedPromoId { get; set; }

        [Required]
        public DateTimeOffset DatePlaced { get; set; }

        public PaymentMethod TypeOfPayment { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double TotalCost { get; set; }

        public string Notes { get; set; }

        public enum PaymentMethod { Cash, Check, CreditCard, PayPal, BitCoin }
    }
}
