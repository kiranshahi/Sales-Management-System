using DAL;
using System.Data.SqlClient;
using System.Data;
using System;

namespace BLL
{
    public class BLLCategory
    {
        public string CatName { get; set; }
        public string CatDescription { get; set; }

        public int AddCategory(string catName, string catDescription)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Insert catName and catDescription to ItemCategory Table.
                 * stored procedure insertItemCat takes @catName varchar(50) and @catDescription varchar(MAX)
                 ***/
                string query = "insertItemCat";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@catName", catName);
                    cmd.Parameters.AddWithValue("@catDescription", catDescription);
                   return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable SelectCategories()
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "SELECT * FROM ItemCategory WHERE IsDeleted = 'False'";
                SqlDataAdapter getCatCommand = new SqlDataAdapter(query, con);
                DataTable ds = new DataTable();
                getCatCommand.Fill(ds);
                return ds;
            }
        }

        public DataTable SearchCategories(string catName)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select all ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "SearchCatName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", catName);
                    using (SqlDataAdapter searchCatCommand = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        searchCatCommand.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public BLLCategory GetCatById(int catId)
        {
            BLLCategory cat = new BLLCategory();
            using (SqlConnection con = DatabaseConn.connection())
            {
                string queryString = "SELECT * FROM ItemCategory where ItemCategoryID = @catId";
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.Parameters.AddWithValue("@catId", catId);
                    using (SqlDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            cat.CatName = (myReader["CatName"].ToString());
                            cat.CatDescription = (myReader["CatDescription"].ToString());
                        }
                    }
                    return cat;
                }
            }
        }

        public int UpdateCategory(int catID, string catName, string catDescription)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string updateQuery = "updateCategory";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@catID", catID);
                    cmd.Parameters.AddWithValue("@catName", catName);
                    cmd.Parameters.AddWithValue("@catDescription", catDescription);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int ChangeToDeleted(int catID)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string updateQuery = "UPDATE ItemCategory SET IsDeleted = 1 where ItemCategoryID = @catID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@catID", catID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}