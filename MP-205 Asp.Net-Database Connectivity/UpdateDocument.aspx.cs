using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace Asp.Net_Database_Connectivity
{
    public partial class UpdateDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWarning.Visible = false;
            if (Session["useremail"] == null)
            {
                Response.Redirect("UpdateDocument.aspx");
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
            
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DocumentId, documentname,DocumentSize,DocumentType from UserDocument";
                    cmd.Connection = con;
                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }
        /*protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {//https://www.codeproject.com/Articles/308552/Upload-and-Download-Files-to-SQL-Servers-in-ASP-Ne
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                {

                    string name = FileUpload.FileName.ToString();
                    int filelength = FileUpload.PostedFile.ContentLength;
                    string filetype = FileUpload.PostedFile.ContentType;
                    int position = name.LastIndexOf("\\");
                    name = name.Substring(position + 1);
                    Response.Write(position+" Name" + name + filetype + "  " + filelength+" "+FileUpload.PostedFile.InputStream) ;
                    if (FileUpload.HasFile)
                    {
                        string filename = FileUpload.FileName.ToString();
                        //FileUpload.PostedFile.SaveAs(Server.MapPath("~/Document/")+filename);//Save file in project directory using .saveas 
                        
                        byte[] filedata = new byte[filelength];
                        FileUpload.PostedFile.InputStream.Read(filedata,0,filelength);
                        Response.Write(filedata.Length);
                        using (SqlCommand cmd = new SqlCommand("insert into UserDocument(email,documentname,document,DocumentSize,DocumentType)" +
                            " values('avi@gmail.com',@docname,@doc,@doclength,@doctype)", con))
                        {
                            con.Open();
                            Response.Write("\n The fired query is "+cmd.CommandText);
                            cmd.Parameters.Add("@docname", SqlDbType.NVarChar, 50);
                            cmd.Parameters.Add("@doc", SqlDbType.VarBinary);
                            cmd.Parameters.Add("@doclength", SqlDbType.Int);
                            cmd.Parameters.Add("@doctype", SqlDbType.VarChar, 50);

                            cmd.Parameters["@docname"].Value = TextBoxDocumentName.Text;
                            cmd.Parameters["@doc"].Value = filedata;
                            cmd.Parameters["@doclength"].Value = filelength;
                            cmd.Parameters["@doctype"].Value = filetype;

                            cmd.ExecuteNonQuery();
                            
                            LabelWarning.Visible = true;
                            LabelWarning.Text = "File Uploaded Sucessfully";
                            TextBoxDocumentName.Text = "";
                            //"+Session["useremail"]+"
                        }

                    }
                    else
                    {
                        LabelWarning.Visible = true;
                        LabelWarning.Text = "OOPs!!..Please Upload File";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("OOPs! Something went wrong "+ex);
            }

            

        }*/

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
            string contenttype = FileUpload.PostedFile.ContentType;
            using (Stream fs =FileUpload.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                    {
                        string query = "insert into UserDocument values('"+Session["useremail"]+"',@docname,@doc,@doclength,'"+contenttype+"')";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@docname",filename);
                            cmd.Parameters.AddWithValue("@doc",bytes);
                            cmd.Parameters.AddWithValue("@doclength",FileUpload.PostedFile.ContentLength);
                            
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            LabelWarning.Visible = true;
                            LabelWarning.Text = "File Uploaded Sucessfully";
                            
                        }
                    }
                }
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select document,DocumentType,documentname from UserDocument where DocumentId=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["document"];
                        contentType = sdr["DocumentType"].ToString();
                        fileName = sdr["documentname"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        
    }
}