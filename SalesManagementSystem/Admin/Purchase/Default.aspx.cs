﻿using BLL;
using System;
using System.Data;

namespace SalesManagementSystem.Purchase
{
    public partial class Default : System.Web.UI.Page
    {
        BLLPurchase purchaseObj = new BLLPurchase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    LoadPurchase();
                    lblName.InnerText = Session["userName"].ToString();
                }
                else
                {
                    Response.Redirect("~/Admin/Default");
                }
            }
        }

        protected void LoadPurchase()
        {
            DataTable dt = purchaseObj.SelectPurchase();
            grdPurchase.DataSource = dt;
            grdPurchase.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchInput.Value;
            DataTable dt = purchaseObj.SearchPurchase(searchTerm);
            grdPurchase.DataSource = dt;
            grdPurchase.DataBind();
            if (dt.Rows.Count==0)
            {
                message.InnerText = "Result Not found"; 
            }
        }

        protected void grdPurchase_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grdPurchase.PageIndex = e.NewPageIndex;
            LoadPurchase();
        }
    }
}