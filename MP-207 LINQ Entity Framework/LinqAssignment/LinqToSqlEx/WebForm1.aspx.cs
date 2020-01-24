using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqToSqlEx
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            NameTextBox.Visible = false;
            ContactTextBox.Visible = false;
            NameLabel.Visible = false;
            ContactLabel.Visible = false;
            btnSubmit.Visible = false;
            SearchButton.Visible = false;
            SearchTextBox.Visible = false;
            btnSubmitUpdate.Visible = false;
            TextBoxEmpId.Visible = false;
            Idlabel.Visible = false;
        }

        private void GetData()
        {
            EmployeeInformationDataContext db = new EmployeeInformationDataContext();
            GridView1.DataSource = from emp in db.EmployeeDetails
                                   select emp;
            GridView1.DataBind();
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            InsertView();
            btnSubmit.Visible = true;
        }

        private void InsertView()
        {
            NameTextBox.Visible = true;
            ContactTextBox.Visible = true;
            NameLabel.Visible = true;
            ContactLabel.Visible = true;
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SearchButton.Visible = true;
            SearchTextBox.Visible = true;
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (EmployeeInformationDataContext db = new EmployeeInformationDataContext())
            {
                EmployeeDetail emp = db.EmployeeDetails.SingleOrDefault(em => em.EmployeeId == 2);
                db.EmployeeDetails.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
            GetData();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (EmployeeInformationDataContext db = new EmployeeInformationDataContext())
            {
                EmployeeDetail newemp = new EmployeeDetail()
                {
                    EmployeeName = NameTextBox.Text,
                    ContactInfo = ContactTextBox.Text
                };
                var contact = db.EmployeeDetails.FirstOrDefault(em => em.ContactInfo == ContactTextBox.Text);
                if (contact == null)
                {
                    db.EmployeeDetails.InsertOnSubmit(newemp);
                    db.SubmitChanges();
                }
                else
                {
                    Label1.Visible = true;
                }
            }
            GetData();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            using (EmployeeInformationDataContext db = new EmployeeInformationDataContext())
            {
                EmployeeDetail emp = db.EmployeeDetails.SingleOrDefault(em => em.EmployeeId ==Convert.ToInt32(SearchTextBox.Text));
                if (emp ==null)
                {
                    
                    Label1.Text = "Employee not exist with Id " + SearchTextBox.Text;
                    Label1.Visible = true;
                }
                else
                {
                    InsertView();
                    TextBoxEmpId.Text = emp.EmployeeId.ToString();
                    NameTextBox.Text = emp.EmployeeName;
                    ContactTextBox.Text = emp.ContactInfo;
                    btnSubmitUpdate.Visible = true;
                    TextBoxEmpId.Visible = true;
                    Idlabel.Visible = true;
                }
            }
            
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            using (EmployeeInformationDataContext db = new EmployeeInformationDataContext())
            {
                EmployeeDetail emp = db.EmployeeDetails.SingleOrDefault(em => em.EmployeeId == Convert.ToInt32(SearchTextBox.Text));
                emp.EmployeeName= NameTextBox.Text;
                emp.ContactInfo= ContactTextBox.Text;
                
                db.SubmitChanges();
            }
            GetData();
        }
    }
}