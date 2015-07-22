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
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (comp2007Entities db = new comp2007Entities())
                    {
                        foreach (Department d in db.Departments)
                        {
                            ddlCourses.Items.Add(new ListItem(d.Name, d.DepartmentID.ToString()));

                        }
                        // foreach (Student s in db.Students)
                        //   {
                        //       ddlAddStudents.Items.Add(new ListItem(s.FirstMidName, s.StudentID.ToString()));
                        //  }

                    }
                    if (Request.QueryString.Count > 0)
                    {
                        GetCourse();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }
        protected void GetCourse()
        {
            try
            {
                Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                using (comp2007Entities db = new comp2007Entities())
                {
                    Course c = (from ObjD in db.Courses where ObjD.CourseID == CourseID select ObjD).FirstOrDefault();

                    if (c != null)
                    {
                        txtTitle.Text = c.Title;
                        txtCredits.Text = c.Credits.ToString();
                        ddlCourses.SelectedValue = c.DepartmentID.ToString();
                        pnlStudents.Visible = true;
                    }
                    var objE = (from en in db.Enrollments
                                join s in db.Students on en.StudentID equals s.StudentID
                                where c.CourseID == en.CourseID
                                select new { s.StudentID, s.FirstMidName, s.LastName });

                    grdStudents.DataSource = objE.ToList();
                    grdStudents.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (comp2007Entities db = new comp2007Entities())
                {

                    Course c = new Course();

                    Int32 CourseID = 0;

                    if (Request.QueryString["CourseID"] != null)
                    {
                        CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                        c = (from objD in db.Courses where objD.CourseID == CourseID select objD).FirstOrDefault();
                    }
                    c.Title = txtTitle.Text;
                    c.Credits = Convert.ToInt32(txtCredits.Text);
                    c.DepartmentID = Convert.ToInt32(ddlCourses.SelectedValue);

                    if (CourseID == 0)
                    {
                        db.Courses.Add(c);
                    }
                    db.SaveChanges();
                    Response.Redirect("courses.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }
        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = (from objS in db.Students where objS.StudentID == StudentID select objS).FirstOrDefault();
                db.Students.Remove(s);
                db.SaveChanges();
            }
            GetCourse();
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            //add student to enrollment table
        }
    }
}