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
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
        }
    }
}
