using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModel
{
    

    public class CustomerOrder
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Datetime { get; set; }

        public int Ordered { get; set; }
        
    }

    public class CustomerOrderView
    {
        public string UserName { get; set; }
        public int? Count { get; set; }
        public List<CustomerOrder> CustomerOrders { get; set; }
        public int Total { get; set; }
    }
}
