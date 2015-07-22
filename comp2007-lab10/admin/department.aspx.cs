using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2007_lab10.Models;
using System.Web.ModelBinding;


namespace comp2007_lab10
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetDepartment();
            }

        }

        protected void GetDepartment()
        {
            try { 


            Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = (from ObjD in db.Departments where ObjD.DepartmentID == DepartmentID select ObjD).FirstOrDefault();

                if (d != null)
                {
                    txtName.Text = d.Name;
                    txtBudget.Text = d.Budget.ToString();
                    pnlCourses.Visible = true;
                }

                var objC = (from c in db.Courses
                            where c.DepartmentID == d.DepartmentID
                            select new { c.CourseID, c.Title, c.Credits });

                grdCourses.DataSource = objC.ToList();
                grdCourses.DataBind();
            }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try { 
            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = new Department();

                Int32 DepartmentID = 0;

                if (Request.QueryString["DepartmentID"] != null)
                {
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    d = (from objD in db.Departments where objD.DepartmentID == DepartmentID select objD).FirstOrDefault();
                }
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                if (DepartmentID == 0)
                {
                    db.Departments.Add(d);
                }
                db.SaveChanges();
                Response.Redirect("departments.aspx");
            }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Int32 CourseID = Convert.ToInt32(grdCourses.DataKeys[e.RowIndex].Values["CourseID"]);

                using (comp2007Entities db = new comp2007Entities())
                {
                    Course c = (from objC in db.Courses where objC.CourseID == CourseID select objC).FirstOrDefault();
                    db.Courses.Remove(c);
                    db.SaveChanges();
                }
                GetDepartment();
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }


    }
}