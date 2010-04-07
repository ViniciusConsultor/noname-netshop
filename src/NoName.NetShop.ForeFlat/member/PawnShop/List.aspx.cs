using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.ForeFlat.member.PawnShop
{
    public partial class List : AuthBasePage
    {
        private PawnProductBll bll = new PawnProductBll();

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
            Repeater_PawnList.DataSource = bll.GetList(AspNetPager.PageSize, PageIndex, String.Empty, out RecordCount);
            Repeater_PawnList.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }


        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

    }
}
