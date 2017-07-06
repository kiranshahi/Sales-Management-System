using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesManagementSystem
{
    public partial class AddSubCat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /** Set Item Category name and Item Category ID to Select option from Itemcategory Table **/
                string queryCat = "select * from ItemCategory";
                SqlConnection con = DatabaseConnection.connection();
                SqlDataAdapter getCatCommand = new SqlDataAdapter(queryCat, con);
                DataSet ds = new DataSet();
                getCatCommand.Fill(ds, "ItemCategory");

                selectCat.DataSource = ds;
                selectCat.DataTextField = "CatName";
                selectCat.DataValueField = "ItemCategoryID";
                selectCat.DataBind();
            }
        }

        protected void btnSaveSubCat_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DatabaseConnection.connection())
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
                    cmd.Parameters.AddWithValue("@itmSubCategoryName", subCatName.Text);
                    cmd.Parameters.AddWithValue("@itmCategoryID", selectCat.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubCatDescription", subCatDescription.InnerText);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}