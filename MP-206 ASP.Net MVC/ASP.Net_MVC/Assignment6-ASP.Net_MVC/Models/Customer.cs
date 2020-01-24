using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment6_ASP.Net_MVC.Models
{
    public class Customer
    {
        [Key]   
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        public string MobileNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Enter Email-Id")]
        public string EmailID { get; set; }
        public List<Customer> ShowallCustomer { get; set; }
    }
}