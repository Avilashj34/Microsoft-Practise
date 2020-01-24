using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment6_ASP.Net_MVC.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment6_ASP.Net_MVC.DataAccess
{
    public class DataAccessLayer
    {
        readonly string connection = ConfigurationManager.ConnectionStrings["CustomerEntities"].ToString();
        SqlConnection con = null;
        public string InsertData(Customer objcust)
        {      
            string result = "";
            try
            {
                
                con = new SqlConnection(connection);
                using (SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", 0);
                    cmd.Parameters.AddWithValue("@Name", objcust.Name);
                    cmd.Parameters.AddWithValue("@Address", objcust.Address);
                    cmd.Parameters.AddWithValue("@Mobileno", objcust.MobileNo);
                    cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                    cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                    cmd.Parameters.AddWithValue("@Query", 1);
                    con.Open();
                    result = cmd.ExecuteScalar().ToString();
                    //cmd.ExecuteNonQuery();
                    
                    result = "Inserted";
                    con.Close();
                }
                return result;
            }
            catch (Exception e)
            {
                
                return "Error occured " + e;
            }
            
        }

        public string UpdateData(Customer objcust)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                cmd.Parameters.AddWithValue("@Name", objcust.Name);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Mobileno", objcust.MobileNo);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthdate);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception e)
            {
                return result = "Error occured " + e;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeleteData(Customer obj)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception e)
            {
                return result = "Error occured " + e;
            }
            finally
            {
                con.Close();
            }
        }


        public List<Customer> SelectAllData()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Customer> custlist = null;
            string result = "";
            try
            {
                con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", null);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                custlist = new List<Customer>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Customer obj = new Customer();
                    obj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"].ToString());
                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();

                    obj.Birthdate = (DateTime)ds.Tables[0].Rows[i]["Birthdate"];
                    obj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    custlist.Add(obj);
                }
                return custlist;
            }
            catch (Exception e)
            {
                result = "Error Occured " + e;
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public Customer SelectAllDataById(string CustomerId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Customer obj = null;
            string result = "";
            try
            {
                con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", CustomerId);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Mobileno", null);
                cmd.Parameters.AddWithValue("@Birthdate", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Customer();
                    obj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"].ToString());
                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                    obj.Birthdate = (DateTime)ds.Tables[0].Rows[i]["Birthdate"];
                    obj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    
                }
                return obj;
            }
            catch (Exception e)
            {
                result = "Error Occured " + e;
                return obj;
            }
            finally
            {
                con.Close();
            }
        }
    }

}