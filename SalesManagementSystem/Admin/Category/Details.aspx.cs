using BLL;
using System;

namespace SalesManagementSystem.Category
{
    public partial class Details : System.Web.UI.Page
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
                        catName.InnerText = category.CatName;
                        catDescription.InnerText = category.CatDescription;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Admin");
            }
        }
    }
}