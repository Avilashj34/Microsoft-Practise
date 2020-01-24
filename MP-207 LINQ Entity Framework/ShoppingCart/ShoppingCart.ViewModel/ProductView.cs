using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModel
{
    public class ProductView
    {
        [Required(ErrorMessage = "Name is Required"),DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is Required")]        
        public int Price { get; set; }
    }
}
