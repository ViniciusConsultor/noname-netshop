using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Brand
{
    public partial class List : System.Web.UI.Page
    {
        private BrandModelBll bll = new BrandModelBll();

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
            GridView1.DataSource = bll.GetList(PageIndex,AspNetPager.PageSize, "",out RecordCount);
            GridView1.DataBind();
            AspNetPager.RecordCount = RecordCount;
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int BrandID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(BrandID);
                MessageBox.Show(this, "删除成功");
            }
            if (e.CommandName == "moveup")
            {
                int OriginBrandID = Convert.ToInt32(e.CommandArgument);
                int SwitchBrandID = GetSwitchUpBrandID(OriginBrandID);
                bll.SwitchOrder(OriginBrandID, SwitchBrandID);
            }
            if (e.CommandName == "movedown")
            {
                int OriginBrandID = Convert.ToInt32(e.CommandArgument);
                int SwitchBrandID = GetSwitchDownBrandID(OriginBrandID);
                bll.SwitchOrder(OriginBrandID, SwitchBrandID);
            }

            BindData(AspNetPager.CurrentPageIndex);
        }

        private int GetSwitchDownBrandID(int OriginBrandID)
        {
            for (int i=0;i<GridView1.Rows.Count;i++)
            {
                GridViewRow r=GridView1.Rows[i];
                if (OriginBrandID == int.Parse(r.Cells[0].Text))
                {
                    if (i == GridView1.Rows.Count - 1)
                    {
                        return int.Parse(GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].Text);
                    }
                    return int.Parse(GridView1.Rows[i + 1].Cells[0].Text);
                }
            }
            return 0;
        }
        private int GetSwitchUpBrandID(int OriginBrandID)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow r = GridView1.Rows[i];
                if (OriginBrandID == int.Parse(r.Cells[0].Text))
                {
                    if (i == 0)
                    {
                        return int.Parse(GridView1.Rows[GridView1.Rows.Count - 1].Cells[0].Text);
                    }
                    return int.Parse(GridView1.Rows[i - 1].Cells[0].Text);
                }
            }
            return 0;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[4].FindControl("deleteBrand")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
                }
            }
        }
    }
}
