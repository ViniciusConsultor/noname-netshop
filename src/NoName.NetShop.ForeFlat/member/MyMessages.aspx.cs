﻿using System;
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
                    spage.FieldNames = "UserId,MsgId,MsgType,Subject,Content,SenderId,InsertTime,ReadTime,Status";
                    spage.PriKeyName = "MsgId";
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
            rpList.DataSource = ds.Tables[0];
            rpList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex - 1;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;

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
                bll.Delete(this.CurrentUser.UserId, msgId);
                SearPageInfo.PageIndex = 1;
                BindList();
            }
        }

        protected void btnBatDelete_Click(object sender, EventArgs e)
        {
            string msgIds = ReqParas["msgid"];
            MessageBll bll = new MessageBll();
            bll.Delete(this.CurrentUser.UserId,msgIds);
            SearPageInfo.PageIndex = 1;
            BindList();
        }
    }
}
