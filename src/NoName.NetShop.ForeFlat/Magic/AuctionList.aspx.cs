using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Facade;
using NoName.Utility;
using System.Data;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class AuctionList : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["c"])) CategoryID = Convert.ToInt32(Request.QueryString["c"]); else CategoryID = 0;
                if(CategoryID != -1) BindData(1);
                else Response.End();
            }
        }

        private void BindData(int PageIndex)
        {
            DataTable dt = new DataTable();
            int RecordCount = 0;
            if (CategoryID == 0)
            {
                dt = bll.GetList(PageIndex, AspNetPager.PageSize, " and starttime>getdate() and status="+(int)AuctionProductStatus.审核通过, out RecordCount);
            }
            else
            {
                MagicCategoryModel cate = new MagicCategoryBll().GetModel(CategoryID);
                if (cate != null)
                    dt = bll.GetList(PageIndex, AspNetPager.PageSize, " and starttime>getdate() and catepath+'/' like '" + cate.CategoryPath + "/%' and status=" + (int)AuctionProductStatus.审核通过, out RecordCount);
                else Response.End();
            }

            foreach (DataRow row in dt.Rows) row["mediumimage"] = MagicWorldImageRule.GetMainImageUrl(row["mediumimage"].ToString());

            Repeater_ProductList.DataSource = dt;
            Repeater_ProductList.DataBind();
            AspNetPager.RecordCount = RecordCount;
        }



        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

    }
}
