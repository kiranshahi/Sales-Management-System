using BLL;
using System;

namespace SalesManagementSystem.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        BLLCategory catObj = new BLLCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    if (String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                    {
                        Response.Redirect("~/Admin/Category");
                    }
                    else
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        BLLCategory category = catObj.GetCatById(id);
                        catId.Value = id.ToString();
                        txtCatName.Text = category.CatName;
                        txtCatDescription.InnerText = category.CatDescription;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Admin");
            }
        }

        protected void BtnUpdateCat_Click(object sender, EventArgs e)
        {
            int id = int.Parse(catId.Value.ToString());
            if (string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                lblMessage.InnerText = "Category name cannot be empty.";
            }
            else
            {
                catObj.UpdateCategory(id, txtCatName.Text, txtCatDescription.InnerText);
                lblMessage.InnerText = "Category update successfully.";
            }
        }
    }
}