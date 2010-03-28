using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.Utility;
using NoName.NetShop.IMMessage;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class MyMessages : AuthBasePage
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "imMessage";
                    spage.FieldNames = "UserId,MsgId,MsgType,Subject,Content,SenderId,InsertTime,ReadTime,Status,usertype";
                    spage.PriKeyName = "MsgId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "usertype=0 and (msgtype=2 or (msgtype=0 and userid='" + CurrentUser.UserId + "'))";

                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNotice();
                BindList();
            }
        }

        private void BindList()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            rpList.DataSource = ds.Tables[0];
            rpList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex - 1;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;

        }

        private void BindNotice()
        {
            MessageBll mbll = new MessageBll();
            List<MessageModel> list = mbll.GetNoticeList(0, true);
            if (list.Count > 0)
            {
                panNotice.Visible = true;
                rpNotice.DataSource = list;
                rpNotice.DataBind();
            }
            else
            {
                panNotice.Visible = false;

            }
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            BindList();
        }


        protected void rpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int msgId = Convert.ToInt32(e.CommandArgument);
                MessageBll bll = new MessageBll();
                bll.Delete(this.CurrentUser.UserId,0, msgId);
                SearPageInfo.PageIndex = 1;
                BindList();
            }
        }

        protected void btnBatDelete_Click(object sender, EventArgs e)
        {
            string msgIds = ReqParas["msgid"];
            MessageBll bll = new MessageBll();
            bll.Delete(this.CurrentUser.UserId,0,msgIds);
            SearPageInfo.PageIndex = 1;
            BindList();
        }
    }
}
