<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2007_lab10.Student1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Student Details
    </h1>
    <h5>
        All fields are required.
    </h5>
    <fieldset>
        <label for="txtLastName" class="col-sm-2">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtFirstName" class="col-sm-2">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtEnrollmentDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" required MaxLength="50" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a Date" ControlToValidate="txtEnrollmentDate" CssClass="alert alert-danger" Type="Date" MinimumValue="01-01-2000" MaximumValue="01-01-2999"></asp:RangeValidator>
    </fieldset>
   <fieldset>
        <label for="ddlCourse" class="col-sm-2">Course:</label>
        <asp:DropDownList ID="ddlCourses" runat="server">
        
        </asp:DropDownList>
    </fieldset>

    <div  class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
    <asp:Panel ID="pnlStudents" runat="server" Visible="false">
    <h1>Courses</h1>
    <asp:GridView ID="grdEnrollment" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
        DataKeyNames="EnrollmentID" OnRowDeleting="grdEnrollment_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Department" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
            <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />  
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />  
        </Columns>
    </asp:GridView>
</asp:Panel>
</asp:Content>
