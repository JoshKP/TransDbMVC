using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string SupplierId { get; set; }
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
    }
}