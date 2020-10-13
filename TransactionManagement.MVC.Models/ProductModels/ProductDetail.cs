using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.ProductModels
{
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }

        public string Company { get; set; }

        [Display(Name = "Name of Product")]
        public string Name { get; set; }

        [Display(Name = "Product Category")]
        public string Category { get; set; }

        public double Price { get; set; }

        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }

        public string Notes { get; set; }
        public byte[] Image { get; set; }
    }
}
