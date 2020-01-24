using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.ViewModel;
using ShoppingCart.Models;

namespace ShoppingCart.Business
{
    public interface IProductBll
    {
        void AddProduct(ProductView p);
        IEnumerable<Product> ShowProduct();
        List<CustomerOrderView> Bl_ShowCustomerOrderList();
    }
}
