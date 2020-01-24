using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;

namespace Asp.Net_Database_Connectivity
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["useremail"] != null)
            {
                Table_Add.Visible = false;
                submit.Visible = false;
                label_AddEmployee.Visible = false;
                Search_Button.Visible = false;
                Search_TextBox.Visible = false;
                labeledit.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            Table_Add.Visible = true;
            submit.Visible = true;

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                {
                    string employeequery = "insert into Employee values('" + Session["useremail"] + "'," + employeeid.Text + ",'" + name.Text + "'," + number.Text + "," + age.Text + ")";
                    Response.Write(employeequery);
                    int i;
                    using (SqlCommand cmd = new SqlCommand(employeequery, con))
                    {
                        con.Open();
                        i = cmd.ExecuteNonQuery();
                        Response.Write("After Inserting " + i);
                        con.Close();
                    }
                    string designationquery = "insert into Employee_Designation values ((select Max(Id) from Employee), '" + designation.Text + "'," + experience.Text + ")";
                    if (i > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(designationquery, con))
                        {
                            con.Open();
                            int j = cmd.ExecuteNonQuery();
                            Response.Write("After Second  Inserting " + j);
                            if (j > 0)
                            {
                                string projectquery = "insert into Employee_Project values ('" + project_name.Text + "',(select Max(Designation_ID) from Employee_Designation))";
                                using (SqlCommand cmd1 = new SqlCommand(projectquery, con))
                                {
                                    
                                    cmd1.ExecuteNonQuery();
                                    
                                }
                            }
                            con.Close();
                        }
                    }
                    else
                    {
                        Response.Write("Error Occured while adding designation ");
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Error Occured" + ex);
            }
            finally
            {

                Table_Add.Visible = false;
                label_AddEmployee.Visible = true;
            }
        }

        protected void ShowEmployee_Click(object sender, EventArgs e)
        {
            ShowEmployeeData();
        }



        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowEmployeeData();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Label EmployeeId = GridView1.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
            TextBox Name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            TextBox Number = GridView1.Rows[e.RowIndex].FindControl("txt_Number") as TextBox;
            TextBox Age = GridView1.Rows[e.RowIndex].FindControl("txt_Age") as TextBox;
            TextBox Designation = GridView1.Rows[e.RowIndex].FindControl("txt_Designation") as TextBox;
            TextBox Experience = GridView1.Rows[e.RowIndex].FindControl("txt_Experience") as TextBox;
            TextBox ProjectName = GridView1.Rows[e.RowIndex].FindControl("txt_projectname") as TextBox;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                int Id =FindDesignationId(Convert.ToInt32(EmployeeId.Text));
                int Desgination_Id = FindProjectId(Id);
                Response.Write(Convert.ToInt32(EmployeeId.Text)+" Id"+Id+Desgination_Id);
                string query = "update Employee set E_Name='"+ Name.Text + "',E_Number=" + Convert.ToInt32(Number.Text) + ",E_Age=" + Convert.ToInt32(Age.Text) + " where E_Id=" + Convert.ToInt32(EmployeeId.Text);
                string query1 = "update Employee_Designation set E_Designation='" + Designation.Text + "',E_Experience=" + Convert.ToInt32(Experience.Text) + " where Id="+Id;
                string query2 = "update Employee_Project set E_projectname='"+ProjectName.Text+"' where Designation_ID="+Desgination_Id;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        using (SqlCommand cmd1 = new SqlCommand(query1,con))
                        {
                            int j = cmd.ExecuteNonQuery();
                            using (SqlCommand cmd2 = new SqlCommand(query2,con))
                            {
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    con.Close();
                    GridView1.EditIndex = -1;
                    ShowEmployeeData();
                }
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowEmployeeData();
        }

        public void ShowEmployeeData()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                string query = "select email,E_Id,E_Name,E_Number,E_Age,E_Designation,E_Experience,E_projectname from Employee as e join Employee_Designation as d on e.Id=d.Id join Employee_Project as p on d.Designation_ID=p.Designation_ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    GridView1.DataSource = sdr;
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }

        public int FindDesignationId(int EmpId)
        {
            int id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                string query = "select Id from Employee where E_Id="+EmpId;
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    con.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                Response.Write(id);
            }
            return id;
        }

        public int FindProjectId(int Id)
        {
            int Designation_Id;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                string query = "select Designation_ID from Employee_Designation where Id=" + Id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    Designation_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                Response.Write(Designation_Id);
            }
            return Designation_Id;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label EmployeeId = GridView1.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
            int Id = FindDesignationId(Convert.ToInt32(EmployeeId.Text));
            int Desgination_Id = FindProjectId(Id);
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                string query = "Delete from Employee_Project where Designation_ID=" + Desgination_Id;
                string query1 = "Delete from Employee_Designation where Id=" + Id;
                string query2 = "Delete from Employee where E_Id="+EmployeeId.Text;
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(query1, con))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    cmd.ExecuteNonQuery();
                }
                ShowEmployeeData();
            }
        }

        protected void SearchEmployee_Click(object sender, EventArgs e)
        {
            Search_TextBox.Visible = true;
            Search_Button.Visible = true;
            //ShowEmployeeDataWithId(Convert.ToInt32(Search_TextBox.Text));

        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            ShowEmployeeDataWithId(Convert.ToInt32(Search_TextBox.Text));
        }

        public void ShowEmployeeDataWithId(int EmployeeId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                string query = "select email,E_Id,E_Name,E_Number,E_Age,E_Designation,E_Experience,E_projectname from Employee as e join Employee_Designation as d on e.Id=d.Id join Employee_Project as p on d.Designation_ID=p.Designation_ID where e.Id="+EmployeeId;
                using (SqlDataAdapter cmd = new SqlDataAdapter(query,con))
                {
                    DataSet dataSet = new DataSet();
                    cmd.Fill(dataSet);
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();
                    foreach(DataRow dr in dataSet.Tables[0].Rows)
                    {
                        Response.Write(dr["E_Name"].ToString());
                        label1.Text = "Record Found. The Employee Name is "+dr["E_Name"].ToString();       
                    }

                    if(dataSet.Tables[0].Rows.Count == 0)
                    {
                        label1.Text = "No Record Found";
                    }
                }
            }
        }

        
    }
}