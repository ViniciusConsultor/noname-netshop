using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Solution.BLL;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class DemandList : System.Web.UI.Page
    {
        private SolutionDemandBll bll = new SolutionDemandBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        private void BindData(int PageIndex) 
        {
            int RecordCount = 0;
            GridView1.DataSource = bll.GetList(PageIndex,AspNetPager.PageSize,"",out RecordCount);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }
    }
}
