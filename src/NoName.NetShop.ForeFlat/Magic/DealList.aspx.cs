using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class DealList : System.Web.UI.Page
    {
        private DemandProductBll dbll = new DemandProductBll();
        private SecondhandProductBll sbll = new SecondhandProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSalesData(1);
                BindDemandData(1);
            }
        }

        private void BindSalesData(int PageIndex)
        {
            int RecordCount = 0;

            Repeater_Sale.DataSource = sbll.GetList(PageIndex, AspNetPager_Sales.PageSize, " and status="+(int)SecondhandProductStatus.审核通过, out RecordCount);
            Repeater_Sale.DataBind();

            AspNetPager_Sales.RecordCount = RecordCount;
        }

        private void BindDemandData(int PageIndex)
        {
            int RecordCount = 0;

            Repeater_Demand.DataSource = dbll.GetList(PageIndex, AspNetPager_Demand.PageSize, " and status=" + (int)DemandProductStatus.审核通过, out RecordCount);
            Repeater_Demand.DataBind();

            AspNetPager_Demand.RecordCount = RecordCount;
        }

        protected void AspNetPager_Sales_PageChanged(object src, PageChangedEventArgs e) 
        {
            AspNetPager_Sales.CurrentPageIndex = e.NewPageIndex;
            BindSalesData(AspNetPager_Sales.CurrentPageIndex);
        }

        protected void AspNetPager_Demand_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager_Demand.CurrentPageIndex = e.NewPageIndex;
            BindDemandData(AspNetPager_Demand.CurrentPageIndex);
        }
    }
}
