using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.ViewModel;
using ShoppingCart.DataAcess;
using ShoppingCart.Models;
using System.Data.SqlClient;

namespace ShoppingCart.Business
{
    public class ProductBll: IProductBll
    {
        private readonly IDbConnection db;
        public ProductBll(IDbConnection db)
        {
            this.db = db;
        }

        public void AddProduct(ProductView p)
        {
            db.CreateConnection(p);
        }

        public IEnumerable<Product> ShowProduct()
        {
            List<Product> productlist = db.GetProduct();
            return productlist;
        }

        public List<CustomerOrderView> Bl_ShowCustomerOrderList()
        {
            return db.Da_ShowCustomerOrderDetail();
        }
    }
}
