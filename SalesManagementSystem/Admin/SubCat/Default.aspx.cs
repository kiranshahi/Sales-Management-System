using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.SubCat
{
    public partial class Default : System.Web.UI.Page
    {
        BLLSubCategory subCatObj = new BLLSubCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    LoadSubCat();
                    lblName.InnerText = Session["userName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }
        }
        protected void LoadSubCat()
        {
            DataTable dt = subCatObj.SelectSubCategories();
            grdSubCategory.DataSource = dt;
            grdSubCategory.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = subCatObj.SearchSubCategories(searchTerm);
            grdSubCategory.DataSource = dt;
            grdSubCategory.DataBind();
            if (dt.Rows.Count == 0)
            {
                message.InnerText = "Result not found.";
            }
        }

        protected void grdSubCategory_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grdSubCategory.PageIndex = e.NewPageIndex;
            LoadSubCat();
        }
    }
}
