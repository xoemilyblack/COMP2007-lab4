<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="comp2007_lab10.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Course Details
    </h1>
    <h5>
        All fields are required.
    </h5>
    <fieldset>
        <label for="txtTitle" class="col-sm-2">Title:</label>
        <asp:TextBox ID="txtTitle" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtCredits" class="col-sm-2">Credits:</label>
        <asp:TextBox ID="txtCredits" runat="server" required MaxLength="50" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCredits" ErrorMessage="Must be Between 0 - 100" MinimumValue="0" MaximumValue="100" Display="Dynamic" CssClass="label label-danger" Type="Integer"></asp:RangeValidator>
    </fieldset>
    <fieldset>
    <label for="ddlDepartment" class="col-sm-2">Department:</label>
    <asp:DropDownList ID="ddlCourses" runat="server">
        
    </asp:DropDownList>
    </fieldset>

    <div  class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlStudents" runat="server" Visible="false">
    <h1>Students</h1>
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
        DataKeyNames="StudentID" OnRowDeleting="grdStudents_RowDeleting">
        <Columns>
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" SortExpression="FirstMidName"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />  
        </Columns>
    </asp:GridView>
<!--
    <fieldset>
        <label for="ddlAddStudent" class="col-sm-2">Students:</label>
        <asp:DropDownList ID="ddlAddStudents" runat="server">
        
        </asp:DropDownList>
    </fieldset>
    <div  class="col-sm-offset-2">
        <asp:Button ID="btnSave2" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave2_Click"/>
    </div>-->
    </asp:Panel>
</asp:Content>
