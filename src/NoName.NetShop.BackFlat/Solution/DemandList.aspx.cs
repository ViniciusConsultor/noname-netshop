using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "p")
            {
                int DemandID = Convert.ToInt32(e.CommandArgument);
                SolutionDemandModel model = bll.GetModel(DemandID);
                model.Status = (int)SolutionDemandStatus.已处理;
                bll.Update(model);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }
    }
}
