using BLL;
using System;
using System.Data;
using System.Web.UI;

namespace SalesManagementSystem.Sales
{
    public partial class Sale : Page
    {
        BLLSales salesObj = new BLLSales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    if (!IsPostBack)
                    {

                        lblName.InnerText = Session["userName"].ToString();

                        /** Set Item name and Item ID to Select option from Item Table **/
                        DataTable dt = salesObj.LoadItem();

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

            if (selectItem.SelectedIndex > 0)
            {
                int itemId = int.Parse(selectItem.SelectedValue);
                /** Set Item name and Item ID to Select option from Item Table **/
                DataTable dt = salesObj.LoadColor(itemId);
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
                DataTable dt = salesObj.LoadSize(itemId, color);
                selectSize.DataSource = dt;
                selectSize.DataTextField = "Size";
                selectSize.DataValueField = "ItemDetailsID";
                selectSize.DataBind();
                selectSize.Items.Insert(0, "Select Size");
            }
            else
            {
                selectSize.Items.Clear();
            }
        }
        

        protected void SelectSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectSize.SelectedIndex > 0)
            {
                int itemDetailsId = int.Parse(selectSize.SelectedValue);
                DataTable dt = salesObj.SelectPrice(itemDetailsId);
                txtItemPrice.Text = dt.Rows[0]["SellingPrice"].ToString();
            }
            else
            {
                int itemDetailsid = int.Parse(selectColor.SelectedValue);
                DataTable dt = salesObj.SelectPrice(itemDetailsid);
                txtItemPrice.Text = dt.Rows[0]["SellingPrice"].ToString();
            }
        }

        protected void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            
        }
    }
}