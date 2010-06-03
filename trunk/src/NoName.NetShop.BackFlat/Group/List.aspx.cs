using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.GroupShopping.BLL;
using NoName.Utility;
using NoName.NetShop.GroupShopping.Model;

namespace NoName.NetShop.BackFlat.Group
{
    public partial class List : System.Web.UI.Page
    {
        private GroupProductBll bll = new GroupProductBll();

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
            GridView1.DataSource = bll.GetList(PageIndex,AspNetPager.PageSize,String.Empty,out RecordCount);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }

        protected void AspNetPager_PageChanged(object sender,PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                bll.Delete(Convert.ToInt32(e.CommandArgument));
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "sr")
            {
                bll.SetRecommend(Convert.ToInt32(e.CommandArgument), true);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "dr")
            {
                bll.SetRecommend(Convert.ToInt32(e.CommandArgument), false);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "fz")
            {
                bll.Freeze(Convert.ToInt32(e.CommandArgument), (int)GroupShoppingProductStatus.冻结);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "uf")
            {
                bll.Freeze(Convert.ToInt32(e.CommandArgument), (int)GroupShoppingProductStatus.正在团购);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }
                
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    LinkButton TheButton = ((LinkButton)e.Row.Cells[8].FindControl("Button_Delete"));
                    TheButton.Attributes.Add("onclick", "javascript:return confirm('确认删除?')");                 
                }                
            }
        }
    }
}
