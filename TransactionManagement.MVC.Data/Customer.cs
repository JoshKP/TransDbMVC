using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransactionManagement.MVC.Data
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required]
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
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string Notes { get; set; }
    }
}