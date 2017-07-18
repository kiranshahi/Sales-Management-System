using BLL;
using System;

namespace SalesManagementSystem.ItemDetails
{
    public partial class Details : System.Web.UI.Page
    {
        BLLItemDetails itemDetailsObj = new BLLItemDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    lblName.InnerText = Session["userName"].ToString();
                    if (String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                    {
                        Response.Redirect("~/Admin/Category");
                    }
                    else
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        BLLItemDetails itemDetails = itemDetailsObj.GetItemDetailsById(id);
                        itemName.InnerText = itemDetails.ItemName;
                        itemColor.InnerText = itemDetails.Color;
                        itemSize.InnerText = itemDetails.Size;
                        itemWeight.InnerText = itemDetails.Weight;
                        itemSellingPrice.InnerText = itemDetails.SellingPrice.ToString();
                        itemQuantity.InnerText = itemDetails.Quantity.ToString();
                        itemDescription.InnerText = itemDetails.ItemDescription;
                        itemSubCategoryName.InnerText = itemDetails.SubCategoryName;
                        itemCatName.InnerText = itemDetails.CatName;
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