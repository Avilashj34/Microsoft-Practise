using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ShoppingCart.ViewModel;
using ShoppingCart.Models;

namespace ShoppingCart.DataAcess
{
    public class DbConnection:IDbConnection
    {
        //data source=.; database=student; integrated security=SSPI")  
        SqlConnection sqlConnection;
        //string con= ConfigurationManager.ConnectionStrings["ShoppingConnection"].ConnectionString;
        private readonly string con= "data source =.; database= Online_Shopping; Integrated Security = True";

        public void CreateConnection(ProductView p)
        {
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ProductInsert", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name",p.Name);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public List<Product> GetProduct()
        {
            List<Product> productlist = new List<Product>();
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ShowProduct", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sdr =cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Product p = new Product();
                        p.ProductId = (int)sdr["ProductId"];
                        p.Name = sdr["ProductName"].ToString();
                        p.Price =(int)sdr["ProductPrice"];
                        p.DateTime= (DateTime)sdr["DateRecord"];
                        productlist.Add(p);
                    }
                    sqlConnection.Close();
                    return productlist;
                }
            }
        }

        public void InsertForeignValue(string UserName,int ProductId,int Quantity)
        { 
            using (sqlConnection=new SqlConnection(con))
            {
                bool choice = false;
                using (SqlCommand cmd = new SqlCommand("sp_insertForeignKey",sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerusername",UserName);
                    cmd.Parameters.AddWithValue("@productid", ProductId);
                    cmd.Parameters.AddWithValue("@quantity", Quantity);
                    cmd.Parameters.AddWithValue("@Ordered",choice);   
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public void SaveCredential(Customer cust)
        {
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Registration", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", cust.UserName);
                    cmd.Parameters.AddWithValue("@Password", cust.Password);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public int DummySaveCredential(Customer cust)
        {
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Registration", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", cust.UserName);
                    cmd.Parameters.AddWithValue("@Password", cust.Password);
                    sqlConnection.Open();
                    int result =cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return result;
                }
            }
        }

        public int VerifyCredential(Customer cust)
        {
            int i=0;            
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Login", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", cust.UserName);
                    cmd.Parameters.AddWithValue("@Password", cust.Password);
                    sqlConnection.Open();
                    if (cmd.ExecuteScalar() == null)
                    {
                        return i;
                    }
                    else
                    {
                        i = (int)cmd.ExecuteScalar();
                        sqlConnection.Close();
                        return i;
                    }                                      
                }                
            }                        
        }

        public List<CustomerOrderView> Da_ShowCustomerOrderDetail()
        {            
            List<CustomerOrderView> customerOrderViews = new List<CustomerOrderView>();
            SqlDataReader sdr;

            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_showCustomerOrderDetail", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerOrderView c = new CustomerOrderView();
                        c.UserName = sdr["Username"].ToString();
                        c.CustomerOrders = Da_GetCustomerDetailUsingUserName(sdr["Username"].ToString());                          
                        c.Count = Convert.ToInt32(sdr["OrderCount"].ToString());                        
                        customerOrderViews.Add(c);
                    }
                }                
            }
            return customerOrderViews;
        }

        public List<CustomerOrder> Da_GetCustomerDetailUsingUserName(string UserName)
        {
            List<CustomerOrder> customerOrderlist= new List<CustomerOrder>();
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_showCustomerOrderProductDetail", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName",UserName);
                    sqlConnection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerOrder c = new CustomerOrder()
                        {
                            Price = Convert.ToInt32(sdr["ProductPrice"]),
                            ProductName = sdr["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(sdr["Quantity"]),
                            Datetime = (DateTime)sdr["DateRecord"],
                            Ordered = Convert.ToInt32((sdr["Ordered"]))
                        };
                        customerOrderlist.Add(c);
                    }
                    sqlConnection.Close();                  
                }
            }
            return customerOrderlist;
        }

        public int GetProductId(string productname)
        {
            int i = 0;
            using (sqlConnection=new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("select ProductId from product where ProductName='"+productname+"'", sqlConnection))
                {
                    sqlConnection.Open();                    
                    i=Convert.ToInt32(cmd.ExecuteScalar());
                    sqlConnection.Close();
                }

            }
            return i;
        }

        public void Da_UpdateCustomer(string username, int productid)
        {
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateOrderedValue", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username",username);
                    cmd.Parameters.AddWithValue("@productid",productid);                   
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public void Da_UpdateAllCustomer(string username)
        {
            using (sqlConnection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("sp_updateAllOrderedValue", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    //cmd.Parameters.AddWithValue("@productid", productid);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }
    }
}
