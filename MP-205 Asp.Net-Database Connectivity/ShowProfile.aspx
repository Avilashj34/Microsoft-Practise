<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowProfile.aspx.cs" Inherits="Asp.Net_Database_Connectivity.ShowProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1><asp:Label ID="NameLabel" runat="server"></asp:Label>&nbsp;Profile</h1>
    <p>&nbsp;</p>
    <b>Name</b> :
    <asp:Label ID="LabelName" runat="server"></asp:Label>
&nbsp;&nbsp;
    <p><b>Email</b> :
        <asp:Label ID="LabelEmail" runat="server"></asp:Label>
    </p>
    <p><b>Age </b>:
        <asp:Label ID="LabelAge" runat="server"></asp:Label>
    </p>
<p><b>Mobile Number </b>:
        <asp:Label ID="LabelMobileNumber" runat="server"></asp:Label>
    </p>
    <p><b>Country</b> :
        <asp:Label ID="LabelCountry" runat="server"></asp:Label>
    </p>
    
</asp:Content>
