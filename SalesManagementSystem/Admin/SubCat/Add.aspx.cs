using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddSubCat : System.Web.UI.Page
    {
        BLLSubCategory newSubCategory = new BLLSubCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    lblName.InnerText = Session["userName"].ToString();
                    /** Set Item Category name and Item Category ID to Select option from Itemcategory Table **/
                    DataTable dt = newSubCategory.LoadCatName();
                    selectCat.DataSource = dt;
                    selectCat.DataTextField = "CatName";
                    selectCat.DataValueField = "ItemCategoryID";
                    selectCat.DataBind();
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
                
            }
        }

        protected void btnSaveSubCat_Click(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(selectCat.SelectedValue);
            int insertResult  = newSubCategory.InsertSubCategory(subCatName.Text, catId, subCatDescription.InnerText);
        }
    }
}