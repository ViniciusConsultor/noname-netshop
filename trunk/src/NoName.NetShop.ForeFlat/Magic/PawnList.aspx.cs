using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using System.Data;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class PawnList : System.Web.UI.Page
    {
        private PawnProductBll bll = new PawnProductBll();

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

            DataTable dt = bll.GetList(PageIndex, AspNetPager_Sales.PageSize, " and status=" + (int)PawnProductStatus.已收当, out RecordCount);

            foreach(DataRow row in dt.Rows)
            {
                row["mediumimage"] = MagicWorldImageRule.GetMainImageUrl(Convert.ToString(row["mediumimage"]));
                row["smallimage"] = MagicWorldImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"]));
            }

            Repeater_PawnProduct.DataSource = dt;
            Repeater_PawnProduct.DataBind();

            AspNetPager_Sales.RecordCount = RecordCount;
        }


        protected void AspNetPager_Sales_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager_Sales.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager_Sales.CurrentPageIndex);
        }
    }
}
