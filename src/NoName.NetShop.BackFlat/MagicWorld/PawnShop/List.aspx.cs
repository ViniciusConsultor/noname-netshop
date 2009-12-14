using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.BackFlat.MagicWorld.PawnShop
{
    public partial class List : System.Web.UI.Page
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
            GridView1.DataSource = bll.GetList(AspNetPager.PageSize, PageIndex, String.Empty, out RecordCount);
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
            if (e.CommandName.ToLower() == "d")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(ProductID);
                BindData(AspNetPager.CurrentPageIndex);
                MessageBox.Show(this, "删除成功！");
            }
            if (e.CommandName.ToLower() == "f")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.ChangeStatus(ProductID, (int)PawnProductStatus.冻结);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "m")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.ChangeStatus(ProductID, (int)PawnProductStatus.尚未收当);
                BindData(AspNetPager.CurrentPageIndex);
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[6].FindControl("Button_Delete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
                }
            }
        }

        public bool GetButtonStatus(int Status, string ButtonType)
        {
            switch (ButtonType)
            {
                case "f":
                    return Status != (int)PawnProductStatus.冻结;
                case "m":
                    return Status == (int)PawnProductStatus.冻结;
                default:
                    return false;
            }
        }
    }
}
