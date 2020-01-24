using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Asp.Net_Database_Connectivity
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                
                using (SqlCommand cmd = new SqlCommand("select * from Registration where email=@email and password= @password", con))
                {
                    cmd.Parameters.AddWithValue("@email", TextBoxLoginEmail.Text);
                    cmd.Parameters.AddWithValue("@password", TextBoxLoginPassword.Text);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if(dataTable.Rows.Count > 0)
                    {
                        Session["useremail"] =TextBoxLoginEmail.Text;
                        Response.Redirect("UserDashboard.aspx");
                        Session.RemoveAll();
                    }
                    else
                    {
                        
                        Label1.Text = "Your email and password is incorrect";
                        Label1.Visible = true;
                    }
                }
            }
        }
    }
}