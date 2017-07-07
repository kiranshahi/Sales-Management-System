using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLSubCategory
    {
        public DataTable LoadCatName()
        {
            string queryCat = "select * from ItemCategory";
            using (SqlConnection con = DatabaseConn.connection())
            {
                SqlDataAdapter getCatCommand = new SqlDataAdapter(queryCat, con);
                DataTable dt = new DataTable();
                getCatCommand.Fill(dt);
                return dt;
            }
        }

        public int InsertSubCategory(string subCatName, int catId, string subCatDescription)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /**
                 * Insert into ItemSubCategory table.
                 * Stored Procedure insertItemSubCat takes 
                 * @itmSubCategoryName varchar(50), @itmCategoryID int and @SubCatDescription varchar(MAX)
                 **/
                string query = "insertItemSubCat";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itmSubCategoryName", subCatName);
                    cmd.Parameters.AddWithValue("@itmCategoryID", catId);
                    cmd.Parameters.AddWithValue("@SubCatDescription", subCatDescription);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
