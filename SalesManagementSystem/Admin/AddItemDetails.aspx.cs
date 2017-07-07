using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddItemDetails : System.Web.UI.Page
    {
        ItemDetails newItemDetails = new ItemDetails(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /** Set Item name and Item ID to Select option from Item Table **/
                DataTable dt = newItemDetails.LoadItemName();

                selectItem.DataSource = dt;
                selectItem.DataTextField = "ItemName";
                selectItem.DataValueField = "ItemID";
                selectItem.DataBind();
            }
        }

        protected void btnSaveDetails_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(selectItem.SelectedValue);
            double salesPrice = Convert.ToDouble(sellingPrice.Text);
            newItemDetails.InsertItemDetails(itemId, itemColor.Text, itemSize.Text, itemWeight.Text, salesPrice);
        }
    }
}