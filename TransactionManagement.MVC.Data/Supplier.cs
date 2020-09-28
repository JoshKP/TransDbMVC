using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [Display(Name ="Name of Sales Rep/Contact")]
        public string SalesRep { get; set; }

        [Required]
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

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Category { get; set; }

        public string Notes { get; set; }
    }
}