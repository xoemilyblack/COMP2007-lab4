﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="comp2007_lab10.departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>
    <a href="department.aspx" class="btn btn-primary">Add Department</a>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        <asp:ListItem Value="3" Text="3" />
        <asp:ListItem Value="5" Text="5" />
        <asp:ListItem Value="10" Text="10" />
    </asp:DropDownList>
    <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdDepartments_RowDeleting" 
        DataKeyNames="DepartmentID" OnPageIndexChanging="grdDepartments_PageIndexChanging" AllowPaging="true" PageSize="3" AllowSorting="true" OnSorting="grdDepartments_Sorting"
        onRowDataBound="grdDepartments_RowDataBound">
        <Columns>
            <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" SortExpression="DepartmentID" />
            <asp:BoundField DataField="Name" HeaderText="Department Name" SortExpression="Name" />
            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:C2}" SortExpression="Budget" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="department.aspx" DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="department.aspx?DepartmentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
  
</asp:Content>
