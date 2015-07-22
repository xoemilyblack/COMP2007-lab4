using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;

//reference Entity
using System.Web.ModelBinding;
using comp2007_lab10.Models;

namespace comp2007_lab10
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "StudentID";
                Session["SortDirection"] = "ASC";
                GetStudents();
            }
        }
        protected void GetStudents()
        {
            try { 
            String SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();
            using (comp2007Entities db = new comp2007Entities())
            {
                var Students = from s in db.Students
                               select s;

                grdStudents.DataSource = Students.AsQueryable().OrderBy(SortString).ToList();
                grdStudents.DataBind();
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
            Int32 selectedRow = e.RowIndex;

            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = (from objS in db.Students where objS.StudentID == StudentID select objS).FirstOrDefault();
                db.Students.Remove(s);
                //db.SaveChanges();
            }
            GetStudents();
            }
            catch (Exception ex)
            {
                Response.Redirect("/error.aspx");
            }
        }
        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudents.PageIndex = e.NewPageIndex;
            GetStudents();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdStudents.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetStudents();
        }

        protected void grdStudents_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;
            GetStudents();
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdStudents.Columns.Count - 1; i++)
                    {
                        if (grdStudents.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }
            }
        }
    }
}