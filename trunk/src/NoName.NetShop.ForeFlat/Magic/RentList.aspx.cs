using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using System.Data;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class RentList : System.Web.UI.Page
    {
        private RentProductBll bll = new RentProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;

            DataTable newRents = bll.GetList(1, 5, ""," createtime desc", out RecordCount);
            DataTable rentings = bll.GetList(PageIndex, AspNetPager.PageSize, " and status=0", " createtime desc", out RecordCount);

            foreach (DataRow row in newRents.Rows) { row["smallimage"] = MagicWorldImageRule.GetMainImageUrl(row["smallimage"].ToString()); row["mediumimage"] = MagicWorldImageRule.GetMainImageUrl(row["mediumimage"].ToString()); }
            foreach (DataRow row in rentings.Rows) { row["smallimage"] = MagicWorldImageRule.GetMainImageUrl(row["smallimage"].ToString()); row["mediumimage"] = MagicWorldImageRule.GetMainImageUrl(row["mediumimage"].ToString()); }

            Repeater_NewRents.DataSource = newRents;
            Repeater_NewRents.DataBind();

            Repeater_Rentings.DataSource = rentings;
            Repeater_Rentings.DataBind();
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }
    }
}
