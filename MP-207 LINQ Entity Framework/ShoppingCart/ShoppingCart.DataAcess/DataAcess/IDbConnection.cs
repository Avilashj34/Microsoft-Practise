using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.ViewModel;
using ShoppingCart.Models;
using System.Data.SqlClient;

namespace ShoppingCart.DataAcess
{
    public interface IDbConnection
    {

        void CreateConnection(ProductView p);
        List<Product> GetProduct();
        void SaveCredential(Customer cust);
        int DummySaveCredential(Customer cust);
        int VerifyCredential(Customer cust);

        void InsertForeignValue(string UserName, int ProductId, int Quantity);

        List<CustomerOrderView> Da_ShowCustomerOrderDetail();

        List<CustomerOrder> Da_GetCustomerDetailUsingUserName(string UserName);
        int GetProductId(string productname);
        void Da_UpdateCustomer(string username, int productid);
        void Da_UpdateAllCustomer(string username);
    }
}
