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
    public partial class ShowProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["useremail"].ToString();
            if (Session["useremail"] == null)
            {
                Response.Write("Login again");
                Response.Redirect("Login.aspx");
                
            }
            else
            {
                try
                {
                    Response.Write("The Fired Query is :-\t  select * from Registration where email =" + "'" + Session["useremail"] + "'");
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from Registration where email =" + "'"+Session["useremail"]+"'", con))
                        {
                            con.Open();
                            SqlDataReader sqd = cmd.ExecuteReader();
                            while (sqd.Read())
                            {
                                NameLabel.Text = StringConversionMethod(sqd["username"].ToString().ToUpper());
                                LabelName.Text = sqd["username"].ToString();
                                LabelEmail.Text = sqd["email"].ToString();
                                LabelCountry.Text = sqd["country"].ToString();
                                LabelAge.Text = sqd["age"].ToString();
                                LabelMobileNumber.Text = sqd["phone"].ToString();
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error Occured " + ex.ToString());
                }
            }
        }

        protected string StringConversionMethod(string lowername)
        {
            string firstchar = lowername.Substring(0, 1);
            string remainingchar = lowername.Substring(1);
            string Name = firstchar.ToUpper() + remainingchar.ToLower();
            return Name;
        }
    }
}