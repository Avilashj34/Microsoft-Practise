using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Asp.Net_Database_Connectivity
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                {
                    con.Open();
                    string insertQuery = "insert into Registration(username,email,password,age,phone,country) values (@username,@email,@password,@age,@phone,@country)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@username", TextBoxName.Text);
                        cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                        cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text);
                        cmd.Parameters.AddWithValue("@age", TextBoxAge.Text);
                        cmd.Parameters.AddWithValue("@phone", TextBoxPhone.Text);
                        cmd.Parameters.AddWithValue("@country", DropDownListCountry.Text);
                        cmd.ExecuteNonQuery();
                        //Response.Redirect("~/Registration.aspx");
                        GridView1.DataBind();
                        Response.Write("Registration is successfull");
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error "+ex.ToString());
            }
        }

        

        protected void Button_refresh_Click(object sender, EventArgs e)
        {
            /*Response.Redirect("~/Asp.Net-Database Connectivity/Registration.aspx");
            Response.Write("count is " + 1);*/
            //SqlDataSource1.DataBind();
            //Response.Redirect(Request.RawUrl);
        }
    }
}