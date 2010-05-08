using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Comment;

namespace NoName.NetShop.BackFlat.qa
{
    public partial class TopicList : System.Web.UI.Page
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "qaTopic";
                    spage.FieldNames = "TopicId,UserId,ContentType,ContentId,Title,InsertTime,LastReplyTime,LastReplyId,ReplyNum,Status";
                    spage.PriKeyName = "TopicId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "";
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
            string where = "";

            string userId = NoName.Utility.input.Filter(txtUserId.Text.Trim());
            if (!String.IsNullOrEmpty(userId))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "userId='" + userId + "'";
            }
            int topicId;
            if (!int.TryParse(txtTopicId.Text, out topicId))
            {
                topicId = 0;
            }
            if (topicId != 0)
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "topicId=" + topicId;
            }
            SearPageInfo.StrWhere = where;
            SearPageInfo.PageIndex = 1;
            BindList();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int topicId = Convert.ToInt32(e.CommandArgument);
            TopicBll tbll = new TopicBll();
            if (e.CommandName == "del")
            {
                tbll.Delete(topicId);
                this.BindList();
            }
            else if (e.CommandName == "toggle")
            {
                tbll.ToggleStatus(topicId);
                this.BindList();
            }
        }

    }
}
