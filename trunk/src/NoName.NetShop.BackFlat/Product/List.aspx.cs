using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class List : System.Web.UI.Page
    {
        private string SearchCondition
        {
            get { if (ViewState["SearchCondition"] != null) return ViewState["SearchCondition"].ToString(); else return String.Empty; }
            set { ViewState["SearchCondition"]=value; }
        }
        private ProductModelBll bll = new ProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
                BindDropDownData();
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount=0;
            GridView1.DataSource = bll.GetList(PageIndex, AspNetPager.PageSize, SearchCondition,out RecordCount);
            GridView1.DataBind();
        }

        private void BindDropDownData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("code");
            dt.Columns.Add("status");

            foreach (int code in Enum.GetValues(typeof(ProductStatus)))
            {
                DataRow row = dt.NewRow();
                row["code"] = code;
                row["status"] = Enum.GetName(typeof(ProductStatus), code);
                dt.Rows.Add(row);
            }

            drpStatus.DataSource = dt;
            drpStatus.DataTextField = "status";
            drpStatus.DataValueField = "code";
            drpStatus.DataBind();
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
                MessageBox.Show(this, "删除成功"); 
                BindData(AspNetPager.CurrentPageIndex);
            }
        }

        protected void Button_DeleteAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    int ProductID = int.Parse(GridView1.Rows[i].Cells[1].Text);
                    bll.Delete(ProductID);
                }
            }
            BindData(AspNetPager.CurrentPageIndex); 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[6].FindControl("LinkButtonDelete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[2].Text.Trim() + "\"吗?')");                    
                }
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            //构建搜索条件
        }
    }
}
