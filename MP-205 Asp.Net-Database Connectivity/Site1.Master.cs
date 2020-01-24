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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void logoutbutton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.Remove("useremail");
            Response.Redirect("Login.aspx");
        }

        protected void Showrecord_Click(object sender, EventArgs e)
        {
            if (Session["useremail"] != null)
            {
                Response.Redirect("ShowRecord.aspx");
            }
            else
            {
                Response.Write("Login again to acess");
                Response.Redirect("Login.aspx");
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            if (Session["useremail"] != null)
            {
                Response.Redirect("UserDashboard.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Showprofile_Click(object sender, EventArgs e)
        {
            if (Session["useremail"] != null)
            {
                Response.Redirect("ShowProfile.aspx");
            }
            else
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        protected void UpdateDocument_Click(object sender, EventArgs e)
        {
            if (Session["useremail"]!=null)
            {
                Response.Redirect("UpdateDocument.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}