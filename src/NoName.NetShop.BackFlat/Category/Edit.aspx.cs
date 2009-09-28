﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return 0; }
            set { ViewState["CategoryID"] = value; }
        }
        private CategoryModelBll bll = new CategoryModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            CategoryModel model = bll.GetModel(CategoryID);

            txtCateName.Text = model.CateName;
            drpStatus.SelectedValue = model.Status.ToString();
            txtPriceRange.Text = model.PriceRange;
            chkIsHide.Checked = model.IsHide;
            //CategorySelect1.InitialCategory = model.CateId;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            CategoryModel model = bll.GetModel(CategoryID);

            model.CateName = txtCateName.Text;
            model.Status = int.Parse(drpStatus.SelectedValue);
            model.PriceRange = txtPriceRange.Text;
            model.IsHide = chkIsHide.Checked;

            bll.Update(model);
        }

        private void SaveData()
        { 
        }
    }
}
