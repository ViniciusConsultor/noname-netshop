using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;

namespace NoName.NetShop.BackFlat.Product.Specifications
{
    public partial class List : System.Web.UI.Page
    {
        private ProductSpecificationBll bll = new ProductSpecificationBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = bll.GetList();
            GridView1.DataBind(); 
        }

        protected void GridView_RowCommand(object Sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int SpecificationID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(SpecificationID);
                BindData();
            } 
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[3].FindControl("Button_Delete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
                }
            }
        }
    }
}
