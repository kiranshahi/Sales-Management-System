﻿using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class BLLCategory
    {
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
                 * Insert catName and catDescription to ItemCategory Table.
                 * stored procedure insertItemCat takes @catName varchar(50) and @catDescription varchar(MAX)
                 ***/
                string query = "SELECT * FROM ItemCategory";
                SqlDataAdapter getCatCommand = new SqlDataAdapter(query, con);
                DataTable ds = new DataTable();
                getCatCommand.Fill(ds);
                return ds;
            }
        }
    }
}