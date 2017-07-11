using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLItemDetails
    {
        public string ItemName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemDescription { get; set; }
        public string SubCategoryName { get; set; }
        public string CatName { get; set; }
        public DataTable LoadItemName()
        {
            string queryItem = "select * from Item";
            SqlConnection con = DatabaseConn.connection();
            SqlDataAdapter getItemCommand = new SqlDataAdapter(queryItem, con);
            DataTable dt = new DataTable();
            getItemCommand.Fill(dt);
            return dt;
        }
        public int InsertItemDetails(int selectItem, string itemColor, string itemSize, string itemWeight, double sellingPrice, string fileName)
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
                cmd.Parameters.AddWithValue("@imageFile", fileName);
                return cmd.ExecuteNonQuery();
            }
        }
        public DataTable SelectItemDetails()
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "selectItemDetails";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter getItemDetailsCommand = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        getItemDetailsCommand.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public BLLItemDetails GetItemDetailsById(int itemDetailsId)
        {
            BLLItemDetails itemDetails = new BLLItemDetails();
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "selectItemDetailsById";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemDetailsId", itemDetailsId);
                    using (SqlDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            itemDetails.ItemName = myReader["ItemName"].ToString();
                            itemDetails.Color = myReader["Color"].ToString();
                            itemDetails.Size = myReader["Size"].ToString();
                            itemDetails.Weight = myReader["ItmWeight"].ToString();
                            itemDetails.SellingPrice = double.Parse(myReader["SellingPrice"].ToString());
                            itemDetails.Quantity = int.Parse(myReader["Quantity"].ToString());
                            itemDetails.ItemDescription = myReader["ItemDescription"].ToString();
                            itemDetails.SubCategoryName = myReader["SubCategoryName"].ToString();
                            itemDetails.CatName = myReader["CatName"].ToString();
                        }
                        return itemDetails;
                    }
                }
            }
        }
        public DataTable SearchItemDetails(string subCatName)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select all ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                string query = "SearchItemDetails";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", subCatName);
                    using (SqlDataAdapter searchItemDetailsCommand = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        searchItemDetailsCommand.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
