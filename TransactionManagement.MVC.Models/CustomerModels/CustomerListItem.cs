using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.CustomerModels
{
    public class CustomerListItem
    {
        public int CustomerID { get; set; }

        public string FullName { get; }

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

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

    }
}
