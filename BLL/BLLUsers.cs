using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLUsers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public BLLUsers GetUseDetails(int userid)
        {
            BLLUsers user = new BLLUsers();
            using (SqlConnection con = DatabaseConn.connection())
            {
                string queryString = "SELECT * FROM Users where UserID = @userid";
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@userid", userid);
                using (SqlDataReader myReader = cmd.ExecuteReader()) {
                    while (myReader.Read())
                    {
                        user.FirstName = (myReader["FirstName"].ToString());
                        user.LastName = (myReader["LastName"].ToString());
                        user.Email = (myReader["Email"].ToString());
                        user.Phone = (myReader["ContactNO"].ToString());
                    }
                }
                return user;
            }
        }

        public int UpdateUserDetails(int userid, string firstName, string lastName, string email, string phone, string password)
        {
            string updateQuery = null;
            if (String.IsNullOrWhiteSpace(password))
            {
                 updateQuery = "UPDATE Users SET FirstName=@firstName, LastName=@lastName, Email=@email, ContactNO=@phone WHERE UserID=@userid;";
            }
            else
            {
                updateQuery = "UPDATE Users SET FirstName=@firstName, LastName=@lastName, Email=@email, ContactNO=@phone, Password=@password WHERE UserID=@userid;";   
            }
            using (SqlConnection con = DatabaseConn.connection())
            {
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                if (!String.IsNullOrWhiteSpace(password))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                }
                    return cmd.ExecuteNonQuery();
            }
        }
    }
}
