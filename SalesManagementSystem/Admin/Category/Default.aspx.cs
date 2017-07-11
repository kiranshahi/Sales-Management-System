using BLL;
using System;
using System.Data;
using System.Web.UI;
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = catObj.SearchCategories(searchTerm);
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
            if (dt.Rows.Count == 0)
            {
                message.InnerText = "Result Not found";
            }
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            LoadCat();
        }
    }
}