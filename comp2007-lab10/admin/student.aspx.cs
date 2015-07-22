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
    public partial class Student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (comp2007Entities db = new comp2007Entities())
                    {
                        foreach (Course c in db.Courses)
                        {
                            ddlCourses.Items.Add(new ListItem(c.Title, c.CourseID.ToString()));
                        }
                    }
                    if (Request.QueryString.Count > 0)
                    {
                        GetStudent();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void GetStudent()
        {
            try
            {
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                using (comp2007Entities db = new comp2007Entities())
                {
                    Student s = (from ObjS in db.Students where ObjS.StudentID == StudentID select ObjS).FirstOrDefault();

                    if (s != null)
                    {
                        txtLastName.Text = s.LastName;
                        txtFirstName.Text = s.FirstMidName;
                        txtEnrollmentDate.Text = s.EnrollmentDate.ToString("yyyy-MM-dd");
                        pnlStudents.Visible = true;
                    }

                    var objE = (from en in db.Enrollments
                                join c in db.Courses on en.CourseID equals c.CourseID
                                join d in db.Departments on c.DepartmentID equals d.DepartmentID
                                where en.StudentID == s.StudentID
                                select new { en.EnrollmentID, en.Grade, c.Title, d.Name });

                    grdEnrollment.DataSource = objE.ToList();
                    grdEnrollment.DataBind();
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
                    Student s = new Student();
                    Int32 StudentID = 0;

                    if (Request.QueryString["StudentID"] != null)
                    {
                        StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                        s = (from objS in db.Students where objS.StudentID == StudentID select objS).FirstOrDefault();
                    }

                    s.LastName = txtLastName.Text;
                    s.FirstMidName = txtFirstName.Text;
                    s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                    Enrollment en = new Enrollment();
                    en.CourseID = Convert.ToInt32(ddlCourses.SelectedValue);
                    en.StudentID = s.StudentID;

                    if (StudentID == 0)
                    {
                        db.Students.Add(s);
                        db.Enrollments.Add(en);
                    }
                    db.SaveChanges();
                    Response.Redirect("students.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void grdEnrollment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Int32 EnrollmentID = Convert.ToInt32(grdEnrollment.DataKeys[e.RowIndex].Values["EnrollmentID"]);

                using (comp2007Entities db = new comp2007Entities())
                {
                    Enrollment en = (from objE in db.Enrollments where objE.EnrollmentID == EnrollmentID select objE).FirstOrDefault();
                    db.Enrollments.Remove(en);
                    db.SaveChanges();
                }
                GetStudent();

            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}