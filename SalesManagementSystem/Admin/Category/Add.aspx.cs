using BLL;
using System;

namespace SalesManagementSystem
{
    public partial class AddCategories : System.Web.UI.Page
    {
        BLLCategory bllCat = new BLLCategory();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertCat(object sender, EventArgs e)
        {
            int i = bllCat.AddCategory(catName.Text, catDescription.InnerText);
            if (i>0)
            {
                // Some message here
            }
        }
    }
}