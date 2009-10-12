using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using NoName.NetShop.Member.Model;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberList : System.Web.UI.Page
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
                    spage.FieldNames = "UserId,UserEmail,NickName,Status,LastLogin,UserType";
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

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);
            NoName.NetShop.UserManager.BLL.Member bll = new NoName.NetShop.UserManager.BLL.Member();
            switch (e.CommandName)
            {
                case "delete":
                    bll.SetStatus(userId, MemberStatus.Deleted);
                    break;
                case "show":
                    Response.Redirect("MemberInfo.aspx?userid=" + userId, true);
                    Response.End();
                    break;
                case "lock":
                    bll.SetStatus(userId, MemberStatus.Locked);
                    break;
                case "active":
                    bll.SetStatus(userId, MemberStatus.Formal);
                    break;
            }
            BindList();
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex + 1;
            BindList();
        }

        protected void doSearch_Click(object sender, EventArgs e)
        {
            string useremail = txtUserEmail.Text.Trim();
            string usertype = ddlUserType.SelectedValue;

            SearPageInfo.PageIndex = 0;
            if (!String.IsNullOrEmpty(useremail))
            {
                SearPageInfo.StrWhere += " and UserEmail like '" + useremail + "'";
            }
            if (!String.IsNullOrEmpty(usertype))
            {
                SearPageInfo.StrWhere += " and UserType=" + usertype;
            }

            BindList();
        }
    }
}
