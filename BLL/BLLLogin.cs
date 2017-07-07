using DAL;
using System.Data;
using System.Data.SqlClient;

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
    }
}
