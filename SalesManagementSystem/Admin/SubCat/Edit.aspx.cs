using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.SubCat
{
    public partial class Edit : System.Web.UI.Page
    {
        BLLSubCategory subCatObj = new BLLSubCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    lblName.InnerText = Session["userName"].ToString();
                    int id = int.Parse(Request.QueryString["id"]);
                    BLLSubCategory subCatDetails = subCatObj.GetSubCatById(id);
                    /** Set Item Category name and Item Category ID to Select option from Itemcategory Table **/
                    //DataTable dt = subCatObj.LoadCatName();
                    //selectCat.DataSource = dt;
                    //selectCat.DataTextField = "CatName";
                    //selectCat.DataValueField = "ItemCategoryID";
                    //selectCat.DataBind();
                    //selectCat.SelectedValue = subCatDetails.CatID.ToString();
                    //subCatName.Text = subCatDetails.SubCatName;
                    //subCatDescription.InnerText = subCatDetails.SubCatDescription;
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }

        protected void BtnUpdateSubCat_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrWhiteSpace(subCatName.Text))
            //{
            //    int id = int.Parse(Request.QueryString["id"]);
            //    int subCatId = int.Parse(selectCat.SelectedValue);
            //    string subCat = subCatName.Text;
            //    string description = subCatDescription.InnerText;
            //    int updateResult = subCatObj.UpdateSubCategory(id, subCat, subCatId, description);
            //    if (updateResult>0)
            //    {
            //        lblMessage.Text = "Sub category updated successfully.";
            //    }
            //    else
            //    {
            //        lblMessage.Text = "Some thing went wrong.";
            //    }
            //}
            //else
            //{
            //    lblMessage.Text = "Categry Name cannot be empty.";
            //}
        }
    }
}