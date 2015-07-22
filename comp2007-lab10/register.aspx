<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="comp2007_lab10.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <h4>All fields are required</h4>
    <asp:Label runat="server" id="lblStatus" CssClass="label label-danger"></asp:Label>
    <fieldset>
        <label for="txtUsername" class="col-sm-2">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtConfirm" class="col-sm-2">Confirm:</label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="Equal" ControlToValidate="txtPassword" ControlToCompare="txtConfirm" CssClass="label label-danger" Display="Dynamic" ErrorMessage="Passwords Don't Match"></asp:CompareValidator>
    </fieldset>

    <div>
        <asp:Button ID="btnSave" runat="server" Text="Register" OnClick="btnSave_Click" />
    </div>
</asp:Content>
