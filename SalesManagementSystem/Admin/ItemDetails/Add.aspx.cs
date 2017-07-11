using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddItemDetails : System.Web.UI.Page
    {
        BLLItemDetails newItemDetails = new BLLItemDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    lblName.InnerText = Session["userName"].ToString();
                    /** Set Item name and Item ID to Select option from Item Table **/
                    DataTable dt = newItemDetails.LoadItemName();

                    selectItem.DataSource = dt;
                    selectItem.DataTextField = "ItemName";
                    selectItem.DataValueField = "ItemID";
                    selectItem.DataBind();
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }

        protected void BtnSaveDetails_Click(object sender, EventArgs e)
        {
            string fileName = "default.jpg.";
            if (uploadImage.HasFile)
            {
                fileName = uploadImage.FileName.ToString();
                uploadImage.PostedFile.SaveAs(Server.MapPath("~/images/") + fileName);
            }
            int itemId = Convert.ToInt32(selectItem.SelectedValue);
            double salesPrice = Convert.ToDouble(sellingPrice.Text);
            int insertResult = newItemDetails.InsertItemDetails(itemId, itemColor.Text, itemSize.Text, itemWeight.Text, salesPrice, fileName);
            if (insertResult > 0)
            {
                lblMessage.Text = "Item added successfull.";
            }
        }
    }
}