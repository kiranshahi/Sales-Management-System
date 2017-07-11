using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddPurchase : System.Web.UI.Page
    {
        BLLPurchase newPurchase = new BLLPurchase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    if (!IsPostBack)
                    {

                        //lblName.InnerText = Session["userName"].ToString();

                        /** Set Item name and Item ID to Select option from Item Table **/
                        DataTable dt = newPurchase.LoadItem();

                        selectItem.DataSource = dt;
                        selectItem.DataTextField = "ItemName";
                        selectItem.DataValueField = "ItemID";
                        selectItem.DataBind();
                        selectItem.Items.Insert(0, "Select Item");
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
                
            }
        }

        protected void SelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectItem.SelectedIndex>0)
            {
                int itemId = int.Parse(selectItem.SelectedValue);
                /** Set Item name and Item ID to Select option from Item Table **/
                DataTable dt = newPurchase.LoadColor(itemId);
                selectColor.DataSource = dt;
                selectColor.DataTextField = "Color";
                selectColor.DataValueField = "ItemDetailsID";
                selectColor.DataBind();
                selectColor.Items.Insert(0, "Select Color");
            }
            else
            {
                selectColor.Items.Clear();
                selectSize.Items.Clear();
            }
        }

        protected void SelectColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectColor.SelectedIndex > 0)
            {
                /** Set Item name and Item ID to Select option from Item Table **/


                int itemId = int.Parse(selectItem.SelectedValue);
                string color = selectColor.SelectedItem.Text;
                DataTable dt = newPurchase.LoadSize(itemId, color);
                selectSize.DataSource = dt;
                selectSize.DataTextField = "Size";
                selectSize.DataValueField = "ItemDetailsID";
                selectSize.DataBind();
            }
            else
            {
                selectSize.Items.Clear();
            }
        }

        protected void BtnSavePurchase_Click(object sender, EventArgs e)
        {
            int itemDetailsId = String.IsNullOrEmpty(selectSize.SelectedValue) ? Convert.ToInt32(selectColor.SelectedValue) : Convert.ToInt32(selectSize.SelectedValue);
            DateTime purchasedDate = DateTime.Parse(txtPurchasedDate.Text);
            int purchasedQuantity = Convert.ToInt32(txtPurchasedQuantity.Text);
            decimal costPrice = Convert.ToDecimal(txtCostPrice.Text);
            int insertResult =  newPurchase.InsertItemSubCat(itemDetailsId, txtPurchasedFrom.Text, purchasedQuantity, costPrice, purchasedDate);
            int updateResult = newPurchase.UpdateQuantity(itemDetailsId, purchasedQuantity);
        }
    }
}