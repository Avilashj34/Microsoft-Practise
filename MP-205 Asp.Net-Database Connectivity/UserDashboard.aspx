<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Asp.Net_Database_Connectivity.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 136px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Home Page</h2>
<p>&nbsp;</p>
<p>
    <asp:LinkButton ID="ShowEmployee" runat="server" OnClick="ShowEmployee_Click">Show Employee</asp:LinkButton>
    <asp:LinkButton ID="AddEmployee" runat="server" OnClick="AddEmployee_Click">Add Employee</asp:LinkButton>
    <asp:LinkButton ID="SearchEmployee" runat="server" OnClick="SearchEmployee_Click">Search</asp:LinkButton>
    &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="Search_TextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Search_Button" runat="server" Text="Search" OnClick="Search_Button_Click" style="height: 26px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="label_AddEmployee" runat="server" Text="Employee Added Sucessfully. Thank you!"></asp:Label>
    <br />
    <asp:Label ID="labeledit" runat="server" Text="Edit Selected"></asp:Label>
    <br />
    <asp:Table ID="Table_Add" runat="server" Height="124px" Width="503px" >
        <asp:TableRow runat="server">
            <asp:TableCell   runat="server">Employee Id</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="employeeid" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Name</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="name" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Mobile Number</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="number" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Age</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="age" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Designation</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="designation" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Experience</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="experience" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Project Name</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="project_name" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
   &nbsp;&nbsp;
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="submit" runat="server"  Text="Submit"  OnClick="submit_Click" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false" OnRowUpdating="GridView1_RowUpdating"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
             
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("E_Id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Email">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("email") %>'></asp:Label>  
                    </ItemTemplate>  
                      
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("E_Name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("E_Name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Number">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Number" runat="server" Text='<%#Eval("E_Number") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Number" runat="server" Text='<%#Eval("E_Number") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Age">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Age" runat="server" Text='<%#Eval("E_Age") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Age" runat="server" Text='<%#Eval("E_Age") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Designation">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Designation" runat="server" Text='<%#Eval("E_Designation") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Designation" runat="server" Text='<%#Eval("E_Designation") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Experience">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Experience" runat="server" Text='<%#Eval("E_Experience") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Experience" runat="server" Text='<%#Eval("E_Experience") %>'></asp:TextBox>  
                    </EditItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Project Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_projectname" runat="server" Text='<%#Eval("E_projectname") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_projectname" runat="server" Text='<%#Eval("E_projectname") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
            <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
            <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>                       
             </asp:TemplateField> 
        </Columns>
    </asp:GridView>
    <br />
    <br />


    
</asp:Content>
