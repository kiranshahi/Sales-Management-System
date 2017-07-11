using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.ItemDetails
{
    public partial class Default : System.Web.UI.Page
    {
        BLLItemDetails itemDetailsObj = new BLLItemDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    LoadItems();
                    lblName.InnerText = Session["userName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }
        }
        protected void LoadItems()
        {
            DataTable dt = itemDetailsObj.SelectItemDetails();
            grdItemDetails.DataSource = dt;
            grdItemDetails.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = itemDetailsObj.SearchItemDetails(searchTerm);
            grdItemDetails.DataSource = dt;
            grdItemDetails.DataBind();
            if (dt.Rows.Count==0)
            {
                message.InnerText = "Result not found.";
            }
        }

        protected void grdItemDetails_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grdItemDetails.PageIndex = e.NewPageIndex;
            LoadItems();
        }
    }
}