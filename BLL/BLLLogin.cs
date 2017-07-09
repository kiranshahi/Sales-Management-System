using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Security;

namespace BLL
{
    public class BLLLogin
    {
        public DataTable checkUser(string email, string password)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string checkUserQuery = "Select * FROM users WHERE Email = @email AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(checkUserQuery, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool checkEmail(string email)
        {
            bool isEmailExisted = false;
            using (SqlConnection con = DatabaseConn.connection())
            {
                string sql = "SELECT * FROM Users WHERE email=@email";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        isEmailExisted = true;
                        break;
                    }
                }
                return isEmailExisted;
            }
        }

        public void sendEmail(string userEmail)
        {
            string strpassword = Membership.GeneratePassword(12, 6);
            using (MailMessage mm = new MailMessage("mail@kirans.com.np", userEmail))
            {
                mm.Subject = "Sales Management System";
                mm.Body = "Hi, somebody requested to change your password.\n";
                mm.Body += "Here is your new password. Password: " + strpassword + "\n";
                mm.Body += "Your account password has been changed. \n";
                mm.Body += "Please update your password immediately.";

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.kirans.com.np";
                smtp.EnableSsl = true;
                NetworkCredential networkCred = new NetworkCredential("mail@kirans.com.np", "hell0@Nep@1");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}
