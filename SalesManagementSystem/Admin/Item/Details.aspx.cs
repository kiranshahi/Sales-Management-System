using BLL;
using System;

namespace SalesManagementSystem.Item
{
    public partial class Details : System.Web.UI.Page
    {
        BLLItem itemObj = new BLLItem();
        protected void Page_Load(object sender, EventArgs e)
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
                        itemName.InnerText = item.ItemName;
                        subCat.InnerText = item.SubCatName;
                        category.InnerText = item.CatName;
                        itemDesc.InnerText = item.ItemDescription;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Admin");
            }
        }
    }
}