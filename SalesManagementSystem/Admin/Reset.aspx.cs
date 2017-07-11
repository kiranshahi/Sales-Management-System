using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesManagementSystem
{
    public partial class Reset : System.Web.UI.Page
    {
        BLLLogin loginObj = new BLLLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                login_error.Visible = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Value;
            if (String.IsNullOrWhiteSpace(email))
            {
                login_error.Visible = true;
                lblErrorMessage.InnerText = "Email cannot be empty.";
            }
            else
            {
                bool isEmailExisted = loginObj.checkEmail(email);
                if (isEmailExisted)
                {
                    loginObj.sendEmail(email);
                    login_error.Visible = true;
                    lblErrorMessage.InnerText = "Password sent successfully.";
                }
                else
                {
                    login_error.Visible = true;
                    lblErrorMessage.InnerText = "Invalid email address.";
                }
            }
        }
    }
}