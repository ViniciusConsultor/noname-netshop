using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.ShopFlow;
using NoName.NetShop.Member;

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
                    spage.TableName = "spOrder";
                    spage.FieldNames = "sporder.UserId,ummember.usertype,ummember.userlevel,OrderId,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,DerateFee,userid,RecieverName,ChangeTime,PayTime,CreateTime,OrderType";
                    spage.PriKeyName = "OrderId";
                    spage.StrJoin = "join ummember on sporder.userid=ummember.userid";
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
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex;
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

            string orderId = NoName.Utility.input.Filter(txtOrderId.Text.Trim());
            if (!String.IsNullOrEmpty(orderId))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "orderId='" + orderId + "'";
            }
            string userId = NoName.Utility.input.Filter(txtUserId.Text.Trim());
            if (!String.IsNullOrEmpty(userId))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "userId='" + userId + "'";
            }
            string recievername = NoName.Utility.input.Filter(txtReceiver.Text.Trim());
            if (!String.IsNullOrEmpty(recievername))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "recievername='" + recievername + "'";
            }
            DateTime sdate;
            if (DateTime.TryParse(txtStartDate.Text, out sdate))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "createtime>='" + sdate.ToShortDateString() + "'";
            }
            DateTime edate;
            if (DateTime.TryParse(txtEndDate.Text, out edate))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "createtime<='" + edate.ToShortDateString() + "'";
            }

            if (ddlOrderStatus.SelectedValue != "")
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "orderstatus=" + ddlOrderStatus.SelectedValue;
            }
            if (ddlPayStatus.SelectedValue != "")
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "paystatus=" + ddlPayStatus.SelectedValue;
            }
            SearPageInfo.StrWhere = where;
            SearPageInfo.PageIndex = 1;
            BindList();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUserType = e.Row.FindControl("lblUserType") as Label;
                DataRowView row = e.Row.DataItem as DataRowView;
                MemberType userType = (MemberType)(row["usertype"] == DBNull.Value ? 0 : Convert.ToInt32(row["usertype"]));
                UserLevel userLevel = (UserLevel)(row["UserLevel"] == DBNull.Value ? 0 : Convert.ToInt32(row["userlevel"]));
                switch (userType)
                {
                    case MemberType.Personal:
                        lblUserType.Text = userLevel.ToString();
                        break;
                    case MemberType.Company:
                        lblUserType.Text = "鼎企会员";
                        break;
                    case MemberType.Famly:
                        lblUserType.Text = "鼎宅会员";
                        break;
                    case MemberType.School:
                        lblUserType.Text = "鼎校会员";
                        break;
                    default:
                        lblUserType.Text = userLevel.ToString(); 
                        break;
                }

            }
        }

    }
}
