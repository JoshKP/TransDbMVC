using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.CustomerModels
{
    public class SupplierListItem
    {
        public string Company { get; set; }

        [Display(Name = "Name of Sales Rep/Contact")]
        public string SalesRep { get; set; }

        [Display(Name = "User since")]
        public DateTimeOffset UserSince { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public string Notes { get; set; }
    }
}
