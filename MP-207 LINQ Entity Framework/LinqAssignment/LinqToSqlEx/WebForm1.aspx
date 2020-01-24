<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LinqToSqlEx.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style type="text/css">
        

        .auto-style1 {
            width: 25%;
        }
        .auto-style3 {
            width: 219px;
        }
        .auto-style4 {
            width: 206px;
        }
        .auto-style5 {
            width: 206px;
            height: 30px;
            text-align: right;
        }
        .auto-style6 {
            width: 219px;
            height: 30px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

            <br />
            <asp:Button ID="btnGetData" runat="server" OnClick="btnGetData_Click" Text="Get Data" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert Data" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Data" />
            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Data" />

            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <table class="auto-style1" id="InsertTableForm">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Idlabel" runat="server" Text="Employee Id"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBoxEmpId" runat="server" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="NameLabel" runat="server" Text="Employee Name"></asp:Label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="NameTextBox" runat="server" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="ContactLabel" runat="server" Text="Contact Information"></asp:Label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="ContactTextBox" runat="server" Width="160px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnSubmitUpdate" runat="server" OnClick="btnSubmitUpdate_Click" Text="Update" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                </table>
            <br />
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />

        </div>
    </form>
</body>

</html>

