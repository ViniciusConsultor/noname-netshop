using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using System.Data;

namespace NoName.NetShop.ForeFlat.member.Rent
{
    public partial class RentLogList : AuthBasePage
    {
        private RentLogBll bll = new RentLogBll();
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
            DataTable dt = bll.GetListOfUser(PageIndex, AspNetPager.PageSize, GetUserID(), out RecordCount);



            Repeater_LogList.DataSource = dt;
            Repeater_LogList.DataBind();

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
