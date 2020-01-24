using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.ViewModel;

namespace ShoppingCart.Business
{
    public interface ICustomerBll
    {
        
        void SaveCustomerCredential(Customer cust);
        int VerifyCredential(Customer cust);
        IEnumerable<Product> ShowProduct();
        void InsertForeignValue(string UserName, int ProductId, int Quantity);

        IEnumerable<CustomerOrder> Bl_GetCustomerDetailUsingUserName(string UserName, int choice);
        void Bl_UpdateForeignKey(string username, string productname);
        void Bl_UpdateAllForeignKey(string username);
    }
}
