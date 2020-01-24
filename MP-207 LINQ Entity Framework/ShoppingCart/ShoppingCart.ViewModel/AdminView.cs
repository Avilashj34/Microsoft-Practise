using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModel
{
    public class AdminView
    {
        [Required(ErrorMessage ="Required"),DataType(DataType.Text)]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Required"),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
