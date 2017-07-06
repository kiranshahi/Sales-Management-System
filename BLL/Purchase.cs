using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Purchase
    {
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
        public DataTable LoadColor()
        {
            string queryItem = "select * from ItemDetails Where ItemID = @itemId";
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

        /**
         * Insert into ItemSubCategory table.
         * Stored Procedure insertItemSubCat takes
         * @itmSubCategoryName varchar(50), @itmCategoryID int and @SubCatDescription varchar(MAX)
         **/

        public int InsertItemSubCat(int itemDetailsId, string txtPurchasedFrom, int txtPurchasedQuantity, decimal txtCostPrice, DateTime purchasedDate)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string query = "insertPurchase";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemDetailsID", itemDetailsId);
                    cmd.Parameters.AddWithValue("@purchasedFrom", txtPurchasedFrom);
                    cmd.Parameters.AddWithValue("@purchasedQuantity", txtPurchasedQuantity);
                    cmd.Parameters.AddWithValue("@costPrice", txtCostPrice);
                    cmd.Parameters.AddWithValue("@purchasedOn", purchasedDate);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /**
         * Update item's quantity on ItemDetails (stock) table.
         * Stored Procedure UpdateQuantity takes
         * @itemDetailsId int and @quantity int
         **/
        public int UpdateQuantity(int itemDetailsId, int purchasedQuantity)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string queryUpdateQuantity = "UpdateQuantity";
                using (SqlCommand cmd = new SqlCommand(queryUpdateQuantity, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemDetailsId", itemDetailsId);
                    cmd.Parameters.AddWithValue("@quantity", purchasedQuantity);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}