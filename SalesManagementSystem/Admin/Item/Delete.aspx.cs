using BLL;
using System;

namespace SalesManagementSystem.Item
{
    public partial class Delete : System.Web.UI.Page
    {
        BLLItem itemObj = new BLLItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    if (!IsPostBack)
                    {
                        if (String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                        {
                            Response.Redirect("~/Admin/Category");
                        }
                        else
                        {
                            int id = int.Parse(Request.QueryString["id"]);
                            BLLItem item = itemObj.GetItemById(id);
                            lblItemName.Text = item.ItemName;
                            success.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Admin");
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            int updateResult = itemObj.ChangeToDeleted(id);
            if (updateResult > 0)
            {
                success.Visible = true;
                warning.Visible = false;
            }
        }
    }
}