using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.BackFlat.Gift
{
    public partial class GiftProductList : System.Web.UI.Page
    {
        private NoName.NetShop.Product.BLL.GiftBll gbll = new NoName.NetShop.Product.BLL.GiftBll();
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "pdGift";
                    spage.FieldNames = "ProductId,ProductName,Stock,InsertTime,ChangeTime,Status, Score";
                    spage.PriKeyName = "ProductId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = String.Empty;
                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            gvList.DataSource = ds.Tables[0];
            gvList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex - 1;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            BindList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string where = String.Empty;

            int productId;
            if (int.TryParse(txtProductId.Text.Trim(), out productId))
            {
                where += "productId=" + productId;
            }
            if (!String.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                try
                {
                    string pname = NoName.Utility.input.Filter(txtProductName.Text);
                    where += (String.IsNullOrEmpty(where) ? "" : " and ") + pname;
                }
                catch { }
            }
            SearPageInfo.StrWhere = where;
            SearPageInfo.PageIndex = 1;
            BindList();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                gbll.Delete(productId);
                BindList();
            }
        }

    }
}
