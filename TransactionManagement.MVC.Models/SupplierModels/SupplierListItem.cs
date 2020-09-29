using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.SupplierModels
{
    public class SupplierListItem
    {
        public int SupplierId { get; set; }

        public string Company { get; set; }

        [Display(Name = "Name of Sales Rep/Contact")]
        public string SalesRep { get; set; }

        [Display(Name = "User since")]
        public DateTimeOffset UserSince { get; set; }

        public double AccountAge
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - UserSince;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOfAge;
            }
        }

        public int Phone { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public string Notes { get; set; }
    }
}
