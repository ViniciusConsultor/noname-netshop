using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class OrderList : System.Web.UI.Page
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

        }
    }
}
