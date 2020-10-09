using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name="# In Stock")]
        public int InventoryCount { get; set; }
        public string Notes { get; set; }
        public byte[] Image { get; set; }

        
    }
}