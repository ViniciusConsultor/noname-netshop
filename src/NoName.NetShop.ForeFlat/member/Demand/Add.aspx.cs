using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.ForeFlat.member.Demand
{
    public partial class Add : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);
                BindData();
            }
        }

        private void BindData()
        {
            if (CategoryID != -1)
            {
                MagicCategoryBll CategoryBll = new MagicCategoryBll();
                MagicCategoryModel Category = CategoryBll.GetModel(CategoryID);

                TextBox_Category.Text = Category.CategoryName;
            }
            else
            {
                throw new Exception("未选择分类");
            }
        }


    }
}
