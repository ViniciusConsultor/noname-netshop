using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class CategorySelect : System.Web.UI.Page
    {
        public int IntialisedCategoryID
        {
            get { if (ViewState["IntialisedCategoryID"] != null) return Convert.ToInt32(ViewState["IntialisedCategoryID"]); else return -1; }
            set { ViewState["IntialisedCategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) IntialisedCategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                if (IntialisedCategoryID != -1) CategoryListBox1.InitialCategoryID = IntialisedCategoryID;
            }
        }

        protected void Button_OK_Click(object sender, EventArgs e)
        {
            int TheSelectedCategoryID = Convert.ToInt32(CategoryListBox1.SelectedCategoryID);

            BrandCategoryRelationBll relationBll = new BrandCategoryRelationBll();

            DataTable dt = relationBll.GetCategoryBrandList(TheSelectedCategoryID);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show(this,"当前分类下尚无品牌，请先添加品牌！");
                return;
            }

            if (!String.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Response.Redirect(String.Format("edit.aspx?ProductID={0}&CategoryID={1}", Request.QueryString["pid"], CategoryListBox1.SelectedCategoryID));
            }
            else
            {
                Response.Redirect(String.Format("add.aspx?CategoryID={0}",CategoryListBox1.SelectedCategoryID));
            }
        }
    }
}
