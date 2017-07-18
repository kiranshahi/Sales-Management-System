using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLSubCategory
    {
        public int SubCatID { get; set; }
        public string SubCatName { get; set; }
        public string SubCatDescription { get; set; }
        public string CatName { get; set; }
        public int CatID { get; set; }
        public List<BLLCategory> LoadCatName()
        {
            List<BLLCategory> categories = new List<BLLCategory>();
            string queryCat = "selectItemCategory";
            using (SqlConnection con = DatabaseConn.connection())
            {
                SqlCommand cmd = new SqlCommand(queryCat, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BLLCategory category = new BLLCategory();
                    category.CategoryID = Convert.ToInt32(reader["ItemCategoryID"]);
                    category.CatName = reader["CatName"].ToString();
                    category.CatDescription = reader["CatDescription"].ToString();
                    categories.Add(category);
                }
                return categories;
            }
        }

        public int InsertSubCategory(BLLSubCategory subCat)
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
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@itmSubCategoryName",
                        Value = subCat.SubCatName
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@itmCategoryID",
                        Value = subCat.CatID
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@SubCatDescription",
                        Value = subCat.SubCatDescription
                    });
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteSubCategory(int subCatId)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /**
                 * Insert into ItemSubCategory table.
                 * Stored Procedure insertItemSubCat takes 
                 * @itmSubCategoryName varchar(50), @itmCategoryID int and @SubCatDescription varchar(MAX)
                 **/
                string query = "deleteSubCat";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@subCatId",
                        Value = subCatId
                    });
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public List<BLLSubCategory> SelectSubCategories()
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                /***
                 * Select ItemCategoryID, catName and catDescription from ItemCategory Table.
                 ***/
                List<BLLSubCategory> subCategories = new List<BLLSubCategory>();
                string query = "selectItemSubCat";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BLLSubCategory subCat = new BLLSubCategory();
                        subCat.SubCatID = Convert.ToInt32(reader["ItemSubCategoryID"]);
                        subCat.SubCatName = reader["SubCategoryName"].ToString();
                        subCat.SubCatDescription = reader["SubCatDescription"].ToString();
                        subCat.CatID = Convert.ToInt32(reader["ItemCategoryID"]);
                        subCat.CatName = reader["CatName"].ToString();
                        subCategories.Add(subCat);
                    }
                }
                return subCategories;
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
                            subCat.SubCatID = Convert.ToInt32(myReader["ItemSubCategoryID"]);
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
        public int UpdateSubCategory(BLLSubCategory subCat)
        {
            using (SqlConnection con = DatabaseConn.connection())
            {
                string updateQuery = "updateSubCat";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() {
                        ParameterName = "@subCatId",
                        Value =subCat.SubCatID
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@subCatName",
                        Value = subCat.SubCatName
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@itemCatId",
                        Value = subCat.CatID
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@subCatDescription",
                        Value = subCat.SubCatDescription
                    });
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
        //public int ChangeToDeleted(int catID)
        //{
        //    using (SqlConnection con = DatabaseConn.connection())
        //    {
        //        string updateQuery = "UPDATE ItemCategory SET IsDeleted = 1 where ItemCategoryID = @catID";
        //        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
        //        {
        //            cmd.Parameters.AddWithValue("@catID", catID);
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
