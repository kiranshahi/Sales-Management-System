using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLSales
    {
        //public int MyProperty { get; set; }
        /**
         * Load Item Name to Select option dropdown list
         **/
        public DataTable LoadItem()
        {
            string queryItem = "select * from Item";
            using (SqlConnection con = DatabaseConn.connection())
            {
                using (SqlDataAdapter getItemCommand = new SqlDataAdapter(queryItem, con))
                {
                    DataTable dt = new DataTable();
                    getItemCommand.Fill(dt);
                    return dt;
                }
            }
        }
        /**
         * Load Item Color to Select option dropdown list
         **/
        public DataTable LoadColor(int itemId)
        {
            string queryItem = "select * from ItemDetails Where ItemID = @itemId";
            using (SqlConnection con = DatabaseConn.connection())
            {
                using (SqlDataAdapter getColorCommand = new SqlDataAdapter(queryItem, con))
                {
                    getColorCommand.SelectCommand.Parameters.AddWithValue("@itemId", itemId);
                    DataTable dt = new DataTable();
                    getColorCommand.Fill(dt);
                    return dt;
                }
            }
        }
        /**
         * Load Item size to Select option dropdown list
         **/
        public DataTable LoadSize(int itemId, string color)
        {
            string queryItem = "select * from ItemDetails Where ItemID = @itemId AND Color = @color";
            SqlConnection con = DatabaseConn.connection();
            using (SqlDataAdapter getSizeCommand = new SqlDataAdapter(queryItem, con))
            {
                getSizeCommand.SelectCommand.Parameters.AddWithValue("@itemId", itemId);
                getSizeCommand.SelectCommand.Parameters.AddWithValue("@color", color);
                DataTable dt = new DataTable();
                getSizeCommand.Fill(dt);
                return dt;
            }
        }

        public DataTable SelectPrice(int itemDetailsId)
        {
            string queryItem = "select * from ItemDetails WHERE ItemDetailsID = @itemDetailsId";
            SqlConnection con = DatabaseConn.connection();
            using (SqlDataAdapter getItemSPCommand = new SqlDataAdapter(queryItem, con))
            {
                getItemSPCommand.SelectCommand.Parameters.AddWithValue("@itemDetailsId", itemDetailsId);
                DataTable dt = new DataTable();
                getItemSPCommand.Fill(dt);
                return dt;
            }
        }
    }
}
