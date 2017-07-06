using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddSubCat : System.Web.UI.Page
    {
        SubCategory newSubCategory = new SubCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /** Set Item Category name and Item Category ID to Select option from Itemcategory Table **/
                DataTable dt = newSubCategory.LoadCatName();
                selectCat.DataSource = dt;
                selectCat.DataTextField = "CatName";
                selectCat.DataValueField = "ItemCategoryID";
                selectCat.DataBind();
            }
        }

        protected void btnSaveSubCat_Click(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(selectCat.SelectedValue);
            int insertResult  = newSubCategory.InsertSubCategory(subCatName.Text, catId, subCatDescription.InnerText);
        }
    }
}