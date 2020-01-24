using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="UserName is required")]       
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required"),DataType(DataType.Password)]
        public string Password { get; set; }

    }
}