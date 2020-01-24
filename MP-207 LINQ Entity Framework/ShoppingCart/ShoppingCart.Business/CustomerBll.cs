using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DataAcess;
using ShoppingCart.Models;
using ShoppingCart.ViewModel;

namespace ShoppingCart.Business
{
    public class CustomerBll: ICustomerBll
    {
        private readonly IDbConnection db;
        public CustomerBll(IDbConnection db)
        {
            this.db = db;
        }

        public void SaveCustomerCredential(Customer cust)
        {
            db.SaveCredential(cust);
        }

        public int VerifyCredential(Customer cust)
        {
            int i =db.VerifyCredential(cust);
            return i;
        }

        public IEnumerable<Product> ShowProduct()
        {
            List<Product> productlist = db.GetProduct();
            return productlist;
        }

        public void InsertForeignValue(string UserName, int ProductId, int Quantity)
        {
            db.InsertForeignValue(UserName, ProductId,Quantity);
        }

        public IEnumerable<CustomerOrder> Bl_GetCustomerDetailUsingUserName(string UserName,int choice)
        {
            List<CustomerOrder> customerOrders=  db.Da_GetCustomerDetailUsingUserName(UserName);
            if (choice == 0)
            {
                var cartlist = customerOrders.Where(c => c.Ordered == choice).Select(c=> c);
                return cartlist;
            }
            else
            {
                var orderlist = customerOrders.Where(c => c.Ordered == choice).Select(c => c);
                return orderlist;
            }                       
        }

        public void Bl_UpdateForeignKey(string username, string productname)
        {
            int productid=db.GetProductId(productname);
            
            db.Da_UpdateCustomer(username,productid);
        }

        public void Bl_UpdateAllForeignKey(string username)
        {
            //int productid = db.GetProductId(productname);
            db.Da_UpdateAllCustomer(username);
        }
    }
}
