using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class MyScore : AuthBasePage
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "umscorelog";
                    spage.FieldNames = "score,scoretype,appid,inserttime,remark";
                    spage.PriKeyName = "inserttime";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "userid='" + CurrentUser.UserId + "'";
                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();

                MemberInfo member = MemberInfo.GetBaseInfo(CurrentUser.UserId);
                litCurScore.Text = member.CurScore.ToString();
            }
        }

        private void BindList()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            rpLogs.DataSource = ds.Tables[0];
            rpLogs.DataBind();
            panNoResult.Visible = ds.Tables[0].Rows.Count == 0;

            pageNav.CurrentPageIndex = SearPageInfo.PageIndex;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;

        }


        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex + 1;
            BindList();
        }
    }
}
