using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using System.Data;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.BackFlat.MagicWorld.Demand
{
    public partial class List : System.Web.UI.Page
    {
        DemandProductBll bll = new DemandProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordConut = 0;
            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, String.Empty, out RecordConut);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordConut;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "p")
            {
                int DemandID = Convert.ToInt32(e.CommandArgument);
                DemandProductModel m = bll.GetModel(DemandID);
                m.Status = (int)DemandProductStatus.锁定;
                bll.Update(m);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "u")
            {
                int DemandID = Convert.ToInt32(e.CommandArgument);
                DemandProductModel m = bll.GetModel(DemandID);
                m.Status = (int)DemandProductStatus.尚未审核;
                bll.Update(m);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex);
        }
    }
}
