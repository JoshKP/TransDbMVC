using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.CustomerModels
{
    public class CustomerDetail
    {

        [Key]
        public int CustomerId { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Display(Name = "User Since")]
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

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string Notes { get; set; }
    }

}
