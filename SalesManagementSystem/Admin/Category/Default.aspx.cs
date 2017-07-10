﻿using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.Category
{
    public partial class Default : System.Web.UI.Page
    {
        BLLCategory catObj = new BLLCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                if (!IsPostBack)
                {
                    LoadCat();
                    lblName.InnerText = Session["userName"].ToString();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Default");
            }
        }

        protected void LoadCat()
        {
            DataTable dt = catObj.SelectCategories();
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = catObj.SearchCategories(searchTerm);
            grdCategory.DataSource = dt;
            grdCategory.DataBind();
        }
    }
}