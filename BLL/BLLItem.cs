using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemSubCategoryID { get; set; }
        public string SubCatName { get; set; }
        public string CatName { get; set; }
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
        public DataTable SelectItems()
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select all ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "selectItem";
                SqlDataAdapter getItemCommand = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                getItemCommand.Fill(dt);
                return dt;
            }
        }
        
        public BLLItem GetItemById(int itemId)
        {
            /**
             * Get Item details from Item base on Id provides as argument.
             * Set the item details to properties.
             **/
            BLLItem item = new BLLItem();
            using (SqlConnection con = DatabaseConn.connection())
            {
                string queryString = "selectItemById";
                using (SqlCommand cmd = new SqlCommand(queryString, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    using (SqlDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            item.ItemID = int.Parse(myReader["ItemID"].ToString());
                            item.ItemName = myReader["ItemName"].ToString();
                            item.ItemDescription = myReader["ItemDescription"].ToString();
                            item.ItemSubCategoryID = int.Parse(myReader["ItemSubCategoryID"].ToString());
                            item.SubCatName = myReader["SubCategoryName"].ToString();
                            item.CatName = myReader["CatName"].ToString();
                        }
                    }
                    return item;
                }
            }
        }
        
        public int UpdateItem(int itemID, string itemName, string itemDescription, int itemSubCategoryID)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string updateQuery = "updateItem";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@itemDescription", itemDescription);
                    cmd.Parameters.AddWithValue("@itemSubCategoryID", itemSubCategoryID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}