using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                login_error.Visible = false;
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            BLLLogin loginObj = new BLLLogin();
            if (String.IsNullOrWhiteSpace(email.Value))
            {
                login_error.Visible = true;
                lblErrorMessage.InnerText = "E-mail cannot be empty.";
            }
            else if (String.IsNullOrWhiteSpace(password.Value))
            {
                login_error.Visible = true;
                lblErrorMessage.InnerText = "Password cannot be empty.";
            }
            else
            {
                DataTable dt = loginObj.checkUser(email.Value, password.Value);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("userName", dt.Rows[0]["FirstName"].ToString() + " " +dt.Rows[0]["LastName"].ToString());
                    Session.Add("userId", dt.Rows[0]["UserID"].ToString());
                    Response.Redirect("~/Admin/Category");
                }
                else
                {
                    login_error.Visible = true;
                    lblErrorMessage.InnerText = "Invalid Email or Password.";
                }
            }
        }
    }
}