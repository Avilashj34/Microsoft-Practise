using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.ViewModel;

namespace ShoppingCart.Business
{
    
    public class CartSingleton
    {
        private static CartSingleton obj;
        private static int key;
        Dictionary<int, CartView> CustomerProduct;

        private CartSingleton()
        {

        }

        public static CartSingleton GetInstance()
        {
            if (obj==null)
            {
                obj = new CartSingleton();
                return obj;
            }
            return obj;
        }

        public int GetKey()
        {
            if (key == 0)
            {
                return key++;
            }
            return key++;

        }

        public Dictionary<int, CartView> addToCart()
        {
            if(CustomerProduct ==null)
            {
                CustomerProduct= new Dictionary<int, CartView>();
                return CustomerProduct;
            }
            else
            {
                return CustomerProduct;
            }
        }

        public Dictionary<int, CartView> GetList()
        {
            //int count = CustomerProduct.Count();
           
            return CustomerProduct;
        }
    }
}
