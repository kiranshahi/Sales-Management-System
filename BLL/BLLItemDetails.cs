using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLItemDetails
    {
        public DataTable LoadItemName()
        {
            string queryItem = "select * from Item";
            SqlConnection con = DatabaseConn.connection();
            SqlDataAdapter getItemCommand = new SqlDataAdapter(queryItem, con);
            DataTable dt = new DataTable();
            getItemCommand.Fill(dt);
            return dt;
        }
        public int InsertItemDetails(int selectItem, string itemColor, string itemSize, string itemWeight, double sellingPrice)
        {
            /**
             * Insert into ItemDetails table.
             * Stored Procedure insertItemDetails takes
             * @itemID int, @itemColor varchar(50), @itemSize varchar(50), @itemWeight varchar(50) and @itemSellingPrice decimal(18,2)
             **/
            string query = "insertItemDetails";
            SqlConnection con = DatabaseConn.connection();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itemID", selectItem);
                cmd.Parameters.AddWithValue("@itemColor", itemColor);
                cmd.Parameters.AddWithValue("@itemSize", itemSize);
                cmd.Parameters.AddWithValue("@itemWeight", itemWeight);
                cmd.Parameters.AddWithValue("@itemSellingPrice", sellingPrice);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
