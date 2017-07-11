using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.Item
{
    public partial class Default : System.Web.UI.Page
    {
        BLLItem itemObj = new BLLItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    LoadProduct();
                    lblName.InnerText = Session["userName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }
        }
        protected void LoadProduct()
        {
            DataTable dt = itemObj.SelectItems();
            grdItem.DataSource = dt;
            grdItem.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = itemObj.SearchItem(searchTerm);
            grdItem.DataSource = dt;
            grdItem.DataBind();
            if (dt.Rows.Count == 0)
            {
                message.InnerText = "Result Not found";
            }
        }

        protected void grdItem_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grdItem.PageIndex = e.NewPageIndex;
            LoadProduct();
        }
    }
}