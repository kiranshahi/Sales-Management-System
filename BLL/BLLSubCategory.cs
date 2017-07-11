using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLSubCategory
    {
        public string SubCatName { get; set; }
        public string SubCatDescription { get; set; }
        public string CatName { get; set; }
        public int CatID { get; set; }
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
        public DataTable SelectSubCategories()
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "selectItemSubCat";
                SqlDataAdapter getCatCommand = new SqlDataAdapter(query, con);

                DataTable ds = new DataTable();
                getCatCommand.Fill(ds);
                return ds;
            }
        }

        public BLLSubCategory GetSubCatById(int subCatId)
        {
            BLLSubCategory subCat = new BLLSubCategory();
            using (SqlConnection con = DatabaseConn.connection())
            {
                string queryString = "selectItemSubCatByID";
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemSubCatID", subCatId);
                    using (SqlDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            subCat.SubCatName = myReader["SubCategoryName"].ToString();
                            subCat.SubCatDescription = myReader["SubCatDescription"].ToString();
                            subCat.CatName = myReader["CatName"].ToString();
                            subCat.CatID = int.Parse(myReader["ItemCategoryID"].ToString());
                        }
                    }
                    return subCat;
                }
            }
        }
        public int UpdateSubCategory(int subCatID, string subCatName, int catID, string subCatDescription)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string updateQuery = "updateSubCat";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subCatId", subCatID);
                    cmd.Parameters.AddWithValue("@subCatName", subCatName);
                    cmd.Parameters.AddWithValue("@itemCatId", catID);
                    cmd.Parameters.AddWithValue("@subCatDescription", subCatDescription);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable SearchSubCategories(string subCatName)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select all ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "SearchSubCatName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", subCatName);
                    using (SqlDataAdapter searchCatCommand = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        searchCatCommand.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public bool CheckSubCat(string subCatName)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                bool isSubCatExist = false;
                string checkQuery = "SELECT * FROM ItemSubCategory WHERE SubCategoryName = @subCatName";
                using (SqlCommand cmd = new SqlCommand(checkQuery, con))
                {
                    cmd.Parameters.AddWithValue("@subCatName", subCatName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            isSubCatExist = true;
                            break;
                        }
                    }
                    return isSubCatExist;
                }
            }
        }
    }
}
