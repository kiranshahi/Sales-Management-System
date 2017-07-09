using BLL;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SalesManagementSystem.Category
{
    public partial class Default : System.Web.UI.Page
    {
        BLLCategory catObj = new BLLCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    LoadCat();
                    lblName.InnerText = Session["userName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }
        }

        protected void LoadCat()
        {
            DataTable dt = catObj.SelectCategories();
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
        }

        protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int row = e.Row.RowIndex;
            //e.Row.Cells.RemoveAt(0);


            //if (row >= 0)
            //{
            //    TableCell newCell = new TableCell();
            //    newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/EditBook?id="
            //                    + this.books[e.Row.RowIndex].Id
            //                    + "\">"
            //                    + "Edit </a>";
            //    int col = e.Row.Cells.Add(newCell);
            //}
        }
    }
}