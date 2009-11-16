using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class MyOrders : AuthBasePage
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "sporder";
                    spage.FieldNames = "orderid,paymethod,shipmethod,orderstatus,paystatus,paysum,createtime,paytime";
                    spage.PriKeyName = "orderid";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "userid=" + CurrentUser.UserId;
                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        private void BindOrders()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            rpOrders.DataSource = ds.Tables[0];
            rpOrders.DataBind();
            panNoResult.Visible = ds.Tables[0].Rows.Count == 0;

            pageNav.CurrentPageIndex = SearPageInfo.PageIndex - 1;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;

        }


        protected void rpOrders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = e.Item.DataItem as DataRowView;
                int orderId = Convert.ToInt32(row["orderId"]);
                int paymethod = Convert.ToInt32(row["paymethod"]);
                int orderstatus = Convert.ToInt32(row["orderstatus"]);
                int paystatus = Convert.ToInt32(row["paystatus"]);
                DateTime createTime = Convert.ToDateTime(row["createtime"]);

                Repeater rpPrdoucts = e.Item.FindControl("rpProducts") as Repeater;
                Literal litPayMethod =e.Item.FindControl("litPayMethod") as Literal;
                Literal litCreateTime = e.Item.FindControl("litCreateTime") as Literal;
                Literal litStatus = e.Item.FindControl("litStatus") as Literal;

                rpPrdoucts.DataSource = OrderInfo.GetOrderItem(orderId);
                rpPrdoucts.DataBind();

                litCreateTime.Text = createTime.ToString("yyyy-MM-dd HH:mm");
                litPayMethod.Text = GetPayMethodName(paymethod);
                litStatus.Text = GetOrderStatus(orderstatus);

            }
        }

        private string GetOrderStatus(int orderstatus)
        {
            string result = String.Empty;
            switch (orderstatus)
            {
                case 0:
                    result = "等待商家确认";
                    break;
                case 1:
                    result = "备货中";
                    break;
                case 2:
                    result = "已发货";
                    break;
                case 3:
                    result = "已完成";
                    break;
                case 9:
                    result = "已关闭";
                    break;
            }
            return result;
        }

        private string GetPayMethodName(int paymethod)
        {
            string result = String.Empty;
            switch (paymethod)
            {
                case 1:
                    result="在线支付";
                    break;
                case 2:
                    result="银行转账";
                    break;
                case 3:
                    result="邮局汇款";
                    break;
                case 4:
                    result="货到付款";
                    break;

           }
            return result;
        }

         protected void lbtnSearAll_Click(object sender, EventArgs e)
        {
            SearPageInfo.StrWhere = "userId=" + CurrentUser.UserId;
            SearPageInfo.PageIndex = 1;
            BindOrders();
        }

        protected void lbtnSearRecent_Click(object sender, EventArgs e)
        {
            SearPageInfo.StrWhere = String.Format("userId={0} and createtime>='{1}'", CurrentUser.UserId,
                DateTime.Now.AddMonths(-1).ToShortDateString());
            SearPageInfo.PageIndex = 1;
            BindOrders();
        }

        protected void lbtnSearCancel_Click(object sender, EventArgs e)
        {
            SearPageInfo.StrWhere = "userId=" + CurrentUser.UserId + " and orderstatus=9";
            SearPageInfo.PageIndex = 1;
            BindOrders();
        }

        protected void pageNav_ChangePageIndex(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex + 1;
            BindOrders();
        }


    }
}
