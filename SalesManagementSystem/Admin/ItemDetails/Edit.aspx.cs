using BLL;
using System;
using System.Linq;

namespace SalesManagementSystem.ItemDetails
{
    public partial class Edit : System.Web.UI.Page
    {
        BLLItemDetails itemDetailsObj = new BLLItemDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    if (String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                    {
                        Response.Redirect("~/Admin/Category");
                    }
                    else
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        BLLItemDetails itemDetails = itemDetailsObj.GetItemDetailsById(id);
                        itemName.Text = itemDetails.ItemName;
                        itemColor.Text = itemDetails.Color;
                        itemSize.Text = itemDetails.Size;
                        itemWeight.Text = itemDetails.Weight;
                        sellingPrice.Text = itemDetails.SellingPrice.ToString();
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }
    }
}