using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            BLLLogin loginObj = new BLLLogin();
            if (String.IsNullOrWhiteSpace(email.Value) && String.IsNullOrWhiteSpace(password.Value))
            {
                lblErrorMessage.InnerText = "Fields cannot be emplty.";
            }
            else
            {
                DataTable dt = loginObj.checkUser(email.Value, password.Value);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("userName", dt.Rows[0]["FirstName"].ToString() + dt.Rows[0]["LastName"].ToString());
                    Response.Redirect("~/Admin/Category");
                }
            }
        }
    }
}