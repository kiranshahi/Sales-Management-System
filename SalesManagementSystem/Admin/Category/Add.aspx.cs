using BLL;
using System;

namespace SalesManagementSystem
{
    public partial class AddCategories : System.Web.UI.Page
    {
        BLLCategory bllCat = new BLLCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }

        }

        protected void InsertCat(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCatName.Text))
            {
                lblMessage.InnerText = "Category Name cannot be empty";
            }
            else
            {
                if (!bllCat.CheckCat(txtCatName.Text))
                {
                    int i = bllCat.AddCategory(txtCatName.Text, txtCatDescription.InnerText);
                    if (i > 0)
                    {
                        lblMessage.InnerText = "Category added successfully.";
                        txtCatName.Text = String.Empty;
                        txtCatDescription.InnerText = String.Empty;

                    }
                    else
                    {
                        lblMessage.InnerText = "Something went wrong";
                    }
                }
                else
                {
                    lblMessage.InnerText = "Category with Name " + txtCatName.Text + ", already exist.";
                }
            }
        }
    }
}