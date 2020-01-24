using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    class Product
    {
        static Product product = null;
        public string Name { get; set; }
        public int Price { get; set; }
        private Product() { }
        /*public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }*/
        public static Product GetInstance()
        {
            if (product == null)
            {
                product = new Product();
            }
            return product;
        }

        private static IList<Product> productlist = new List<Product>();
        public void AddProduct(string name, int price)
        {
            productlist.Add(new Product() { Name = name, Price = price });
        }
        public IList<Product> Showproductlist()
        {
            return productlist;
        }
    }

}
