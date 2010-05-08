using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.ForeFlat.gift
{
    public partial class GiftList : System.Web.UI.Page
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "pdGift";
                    spage.FieldNames = "ProductId,ProductName,Stock,SmallImage,Score";
                    spage.PriKeyName = "ProductId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "status=1";
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
            DataSet ds = CommDataHelper.GetDataFromSingleTableByPage(SearPageInfo);
            rpProducts.DataSource = ds.Tables[0];
            rpProducts.DataBind();
            //panNoResult.Visible = ds.Tables[0].Rows.Count == 0;
            
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex ;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;

        }

        protected void pageNav_ChangePageIndex(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            BindList();

        }
    }
}
