﻿using BLL;
using System;
using System.Data;

namespace SalesManagementSystem
{
    public partial class AddItem : System.Web.UI.Page
    {
        BLLItem newItem = new BLLItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    lblName.InnerText = Session["userName"].ToString();
                    DataTable ds = newItem.LoadCat();
                    if (ds.Rows.Count > 0)
                    {
                        selectSubCat.DataSource = ds;
                        selectSubCat.DataTextField = "SubCategoryName";
                        selectSubCat.DataValueField = "ItemSubCategoryID";
                        selectSubCat.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }

        protected void BtnSaveItem_Click(object sender, EventArgs e)
        {
            int subCatId = int.Parse(selectSubCat.SelectedValue);
            if (!newItem.CheckItem(itemName.Text))
            {
                int result = newItem.InsertItem(itemName.Text, itemDescription.InnerText, subCatId);
                if (result > 0)
                {
                    lblMessage.Text = "Item added success fully.";
                    itemName.Text = String.Empty;
                    itemDescription.InnerText = String.Empty;
                }
                else
                {
                    lblMessage.Text = "Something went wrong.";
                }
            }
            else
            {
                lblMessage.Text = "This item already exist.";
            }
        }
    }
}