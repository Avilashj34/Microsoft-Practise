<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateDocument.aspx.cs" Inherits="Asp.Net_Database_Connectivity.UpdateDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
            width: 238px;
            text-align: right;
        }
        .auto-style4 {
            width: 238px;
            text-align: right;
        }
        .auto-style6 {
            margin-left: 41px;
        }
        .auto-style7 {
            width: 238px;
            text-align: right;
            height: 45px;
        }
        .auto-style8 {
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <br />
    <h1>Please provide the following details</h1>
    <br />
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style7">Upload</td>
            <td class="auto-style8">
                <asp:FileUpload ID="FileUpload" runat="server" CssClass="auto-style6" Width="168px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload" ErrorMessage="Upload any file" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="LabelWarning" runat="server"></asp:Label>
            </td>
            <td>
                <br />
                <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonReset" runat="server" Text="Reset" />
            </td>
        </tr>
    </table>
      
    <br />
    <br />
    <br />
      
<br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table" >  
            <Columns>  
                <asp:BoundField DataField="DocumentId" HeaderText="File Id" />
                <asp:BoundField DataField="documentname" HeaderText="File Name" />
                <asp:BoundField DataField="DocumentType" HeaderText="File Type" />
                <asp:BoundField DataField="DocumentSize" HeaderText="File Size" />                
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">  
                    <ItemTemplate>  
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"  
                            CommandArgument='<%# Eval("DocumentId") %>'></asp:LinkButton>  
                    </ItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
        </asp:GridView>  
<br />

    
      
</asp:Content>
