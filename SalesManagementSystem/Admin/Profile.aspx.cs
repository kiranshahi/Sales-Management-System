using BLL;
using System;
using System.Data.SqlClient;

namespace SalesManagementSystem
{
    public partial class Profile : System.Web.UI.Page
    {
        BLLUsers usersObj = new BLLUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    int userid = Convert.ToInt32(Session["userId"]);
                    BLLUsers userDetails = usersObj.GetUseDetails(userid);
                    txtFirstName.Text = userDetails.FirstName;
                    txtLastName.Text = userDetails.LastName;
                    txtEmail.Text = userDetails.Email;
                    txtPhone.Text = userDetails.Phone;
                }
            }
            else
            {
                Response.Redirect("~/Admin");
            }
        }
        protected void BtnUpdateProfile_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["userId"]);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(phone))
            {
                lblMessage.Text = "Fields cannot be empty.";
            }
            else
            {
                int updateResult = usersObj.UpdateUserDetails(userid, firstName, lastName, email, phone, password);
                if (updateResult > 0)
                {
                    lblMessage.Text = "User updated successfully.";
                }
            }
        }

        protected void BtnDactivate_Click(object sender, EventArgs e)
        {

        }
    }
}