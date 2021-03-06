﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionManagement.MVC.Models.CustomerModels
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "User Since")]
        public DateTimeOffset UserSince { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string Notes { get; set; }
    }
}
