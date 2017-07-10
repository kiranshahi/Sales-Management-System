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
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
        }
    }
}