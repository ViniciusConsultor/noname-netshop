﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.IMMessage;
using System.Web.Security;
using NoName.Utility;
using System.Text.RegularExpressions;

namespace NoName.NetShop.BackFlat.message
{
    public partial class UserMessageList : System.Web.UI.Page
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
                    spage.FieldNames = "UserId,MsgId,msgtype,usertype,case MsgType when 1 then '公告' when 2 then '组消息' else '用户消息' end as TMsgType,Subject,Content,SenderId,InsertTime,ReadTime,Status,case usertype when 0 then '前台用户' else '后台用户' end as TUserType ";
                    spage.PriKeyName = "MsgId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "usertype=1 and ((msgtype=1 and userId='alluser' and (expiretime is null or expireTime>getdate()))"
                        + " or (msgtype=0 and userId='" + Context.User.Identity.Name + "')"
                        + " or (msgtype=2 and userId in ('" + String.Join("','", Roles.GetRolesForUser()) + "') and (expiretime is null or expireTime>getdate()))) /*originalend*/ ";
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

            bll.Delete(Context.User.Identity.Name,1, String.Join(",", msgIds.ToArray()));
            SearPageInfo.PageIndex = 1;
            BindList();
        }

 
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int msgId = Convert.ToInt32(gvList.DataKeys[e.RowIndex][0]);
            MessageBll bll = new MessageBll();
            bll.Delete(Context.User.Identity.Name,1, msgId);
            SearPageInfo.PageIndex = 1;
            BindList();

        }


        protected void Button_Search_Click(object sender, EventArgs e)
        {
            string SearchCondition = String.Empty;

            if (Check_Sender.Checked)
            {
                if (TextBox_Sender.Text != String.Empty)
                {
                    SearchCondition += " and senderid like '%" + TextBox_Sender.Text + "%'";
                }
                else
                {
                    MessageBox.Show(this, "请输入发送用户ID");
                    return;
                }
            }

            if (Check_Type.Checked)
            {
                SearchCondition += " and msgType = " + DropDown_Type.SelectedValue;
            }

            if (Check_Date.Checked)
            {
                DateTime StartDate, EndDate;
                string Condition = String.Empty;
                if (TextBox_StartDate.Text != String.Empty && DateTime.TryParse(TextBox_StartDate.Text, out StartDate))
                {
                    Condition += " and inserttime >= '" + StartDate.ToString("yyyy-MM-dd") + "' ";
                }

                if (TextBox_EndDate.Text != String.Empty && DateTime.TryParse(TextBox_EndDate.Text, out EndDate))
                {
                    Condition += " and inserttime <= '" + EndDate.ToString("yyyy-MM-dd") + "' ";
                }

                if (!String.IsNullOrEmpty(Condition))
                {
                    SearchCondition += Condition;
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的起至日期");
                    return;
                }
            }

            //Response.Write("<p style=\"color:gray\">" + SearPageInfo.StrWhere + "</p>");
            //Response.Write("<p style=\"color:red\">" + Regex.Split(SearPageInfo.StrWhere, "originalend")[0] + "</p>");
            //Response.Write("<p style=\"color:blue\">" + SearchCondition + "</p>");
            SearPageInfo.StrWhere = Regex.Split(SearPageInfo.StrWhere, "originalend")[0].Replace("*", "").Replace("/", "") + "/*originalend*/" + SearchCondition;
            //Response.Write(SearPageInfo.StrWhere);
            BindList();
        }
    }
}
