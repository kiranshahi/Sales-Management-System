using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.Item
{
    public partial class Edit : System.Web.UI.Page
    {
        BLLItem itemObj = new BLLItem();
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
                        DataTable dt = itemObj.LoadCat();
                        if (dt.Rows.Count > 0)
                        {
                            selectSubCat.DataSource = dt;
                            selectSubCat.DataTextField = "SubCategoryName";
                            selectSubCat.DataValueField = "ItemSubCategoryID";
                            selectSubCat.DataBind();
                        }
                        int id = int.Parse(Request.QueryString["id"]);
                        BLLItem item = itemObj.GetItemById(id);
                        selectSubCat.SelectedValue = item.ItemSubCategoryID.ToString();
                        itemName.Text = item.ItemName;
                        itemDescription.InnerText = item.ItemDescription;
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }

        protected void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            string name = itemName.Text;
            string description = itemDescription.InnerText;
            int subCatId = int.Parse(selectSubCat.SelectedValue.ToString());
            int updateResult = itemObj.UpdateItem(id, name, description, subCatId);
            if (updateResult>0)
            {
                // Some success message
            }
        }
    }
}