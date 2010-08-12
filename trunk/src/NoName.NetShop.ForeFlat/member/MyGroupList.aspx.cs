using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.GroupShopping.BLL;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class MyGroupList : AuthBasePage
    {
        private GroupProductBll bll = new GroupProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser == null)
                {
                    Response.Redirect("/login.aspx");
                    return;
                }
                BindData(1);
            }

        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;
            DataTable dt = bll.GetUserGroupList(PageIndex, AspNetPager.PageSize, GetUserID(), out RecordCount);

            Repeater_GroupList.DataSource = dt;
            Repeater_GroupList.DataBind();
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }


        private string GetUserID()
        {
            return CurrentUser.UserId;
        }
    }
}
