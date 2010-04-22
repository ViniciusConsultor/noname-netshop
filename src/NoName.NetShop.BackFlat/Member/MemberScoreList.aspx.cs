using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using NoName.NetShop.Member.Model;
using NoName.NetShop.Member;
using System.Data;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberScoreList : System.Web.UI.Page
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "umMember";
                    spage.FieldNames = "UserId,UserEmail,UserName,Status,LastLogin,UserType,userlevel,allscore,curscore";
                    spage.PriKeyName = "UserId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "status<3";
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
            gvList.DataSource = CommDataHelper.GetDataFromSingleTableByPage(SearPageInfo);
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

        protected void doSearch_Click(object sender, EventArgs e)
        {
            string userId = NoName.Utility.input.Filter(txtUserId.Text.Trim());
            string usertype = ddlUserType.SelectedValue;
            string userlevel = ddlUserLevel.SelectedValue;
            SearPageInfo.StrWhere = "status<3";
            SearPageInfo.PageIndex = 0;
            if (!String.IsNullOrEmpty(userId))
            {
                SearPageInfo.StrWhere += " and UserId='" + userId + "'";
            }
            if (!String.IsNullOrEmpty(usertype))
            {
                SearPageInfo.StrWhere += " and UserType=" + usertype;
            }
            if (!String.IsNullOrEmpty(userlevel))
            {
                SearPageInfo.StrWhere += " and UserLevel=" + userlevel;
            }
            BindList();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = e.Row.DataItem as DataRowView;
                MemberType userType =(MemberType)(Convert.ToInt32(row["userType"]));
                UserLevel userLevel = (UserLevel)Convert.ToInt32(row["userLevel"]);
                Label lblUserType = e.Row.FindControl("lblUserType") as Label;
                Label lblUserLevel = e.Row.FindControl("lblUserLevel") as Label;
                switch (userType)
                {
                    case MemberType.Personal:
                        lblUserType.Text = "个人会员";
                        lblUserLevel.Text = userLevel.ToString();
                        break;
                    case MemberType.Company:
                        lblUserType.Text = "鼎企会员";
                        lblUserLevel.Text = "";
                        break;
                    case MemberType.Famly:
                        lblUserType.Text = "鼎宅会员";
                        lblUserLevel.Text = "";
                        break;
                    case MemberType.School:
                        lblUserType.Text = "鼎校会员";
                        lblUserLevel.Text = "";
                        break;
                    default:
                        lblUserType.Text = "个人会员";
                        lblUserLevel.Text = userLevel.ToString();
                        break;
                }
            }
        }

        protected void btnAddScore_Click(object sender, EventArgs e)
        {
            string users = Request.Form["selUsers"];
            MemberInfo.LogScore(users, ScoreType.Other, int.Parse(txtScore.Text), "", "");
            txtScore.Text = "";
            BindList();
            
        }



    }
}
