using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;

namespace NoName.NetShop.ForeFlat.member.Demand
{
    public partial class List : AuthBasePage
    {
        private DemandProductBll bll = new DemandProductBll();

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
            Repeater_DemandList.DataSource = bll.GetList(AspNetPager.PageSize, PageIndex, " and userid = '" + GetUserID() + "'", out RecordCount);
            Repeater_DemandList.DataBind();

            AspNetPager.RecordCount = RecordCount;
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
