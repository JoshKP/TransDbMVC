using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.TransactionModels
{
    public class TransactionCreate
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int ProductId { get; set; }

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
