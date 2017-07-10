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
    }
}