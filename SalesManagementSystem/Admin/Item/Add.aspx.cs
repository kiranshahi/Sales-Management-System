﻿using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddItem : System.Web.UI.Page
    {
        Item newItem = new Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable ds = newItem.LoadCat();
                if (ds.Rows.Count>0)
                {
                    selectSubCat.DataSource = ds;
                    selectSubCat.DataTextField = "SubCategoryName";
                    selectSubCat.DataValueField = "ItemSubCategoryID";
                    selectSubCat.DataBind();
                }
            }
        }

        protected void btnSaveCat_Click(object sender, EventArgs e)
        {
            int subCatId = int.Parse(selectSubCat.SelectedValue);
            int result = newItem.InsertItem(itemName.Text, itemDescription.InnerText, subCatId);
            if (result >0)
            {
                // Some message
            }
        }
    }
}