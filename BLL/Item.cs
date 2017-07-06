using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class Item
    {
        public DataTable LoadCat()
        {
            /** Set Item Category name and Item Category ID to Select option from Itemcategory Table **/
            string querySubCat = "select * from ItemSubCategory";
            SqlConnection con = DatabaseConn.connection();
            SqlDataAdapter getSubCatCommand = new SqlDataAdapter(querySubCat, con);
            DataTable ds = new DataTable();
            getSubCatCommand.Fill(ds);
            return ds;
           
        }

        public int InsertItem(string itemName, string itemDescription, int selectSubCat)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /**
                 * Insert into ItemSubCategory table.
                 * Stored Procedure insertItemSubCat takes 
                 * itemName varchar(50), @itemDescription varchar(MAX) and @itemSubCatID int
                 **/
                string query = "insertITem";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@itemDescription", itemDescription);
                    cmd.Parameters.AddWithValue("@itemSubCatID", selectSubCat);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}