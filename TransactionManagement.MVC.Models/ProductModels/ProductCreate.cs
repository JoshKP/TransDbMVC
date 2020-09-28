using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.ProductModels
{
    public class ProductCreate
    {
        [Required]
        [Display(Name = "Supplier ID")]
        public string SupplierId { get; set; }


        [Required]
        [Display(Name = "Name of Product")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }

        public string Notes { get; set; }
    }
}
