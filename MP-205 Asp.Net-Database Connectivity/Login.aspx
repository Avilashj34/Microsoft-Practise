<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Asp.Net_Database_Connectivity.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 228px;
        }
        .auto-style3 {
            width: 907px;
        }
        .auto-style4 {
            width: 228px;
            height: 23px;
            text-align: right;
        }
        .auto-style5 {
            width: 907px;
            height: 23px;
        }
        .auto-style6 {
            width: 228px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Login Page</h3>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">Email-Id</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBoxLoginEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxLoginEmail" ErrorMessage="Enter Email-Id" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxLoginEmail" ErrorMessage="Enter Valid Email-Id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Password</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxLoginPassword" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="ButtonLogin" runat="server" ForeColor="#003300" Text="Login" Width="79px" OnClick="ButtonLogin_Click" />
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h2><a href="Registration.aspx">New User? Click Here</a></h2>
        </div>
    </form>
</body>
</html>
