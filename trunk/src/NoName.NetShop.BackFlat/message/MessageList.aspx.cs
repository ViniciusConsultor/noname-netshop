using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.IMMessage;
using System.Web.Security;

namespace NoName.NetShop.BackFlat.message
{
    public partial class MessageList : System.Web.UI.Page
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
                    spage.StrWhere = "usertype=1 and userid='" + Context.User.Identity.Name + "'";

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


        protected void btnBatDelete_Click(object sender, EventArgs e)
        {
            List<string> msgIds = new List<string>();
            foreach (GridViewRow row in gvList.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].Controls[0];
                if (cb.Checked)
                    msgIds.Add(gvList.DataKeys[row.RowIndex][0].ToString());
            }
            MessageBll bll = new MessageBll();

            bll.Delete(Context.User.Identity.Name, String.Join(",", msgIds.ToArray()), 1);
            SearPageInfo.PageIndex = 1;
            BindList();
        }

 
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int msgId = Convert.ToInt32(gvList.DataKeys[e.RowIndex][0]);
            MessageBll bll = new MessageBll();
            bll.Delete(Context.User.Identity.Name, msgId,1);
            SearPageInfo.PageIndex = 1;
            BindList();

        }
    }
}
