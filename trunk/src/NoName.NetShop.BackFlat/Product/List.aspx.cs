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
using System.Web.UI.HtmlControls;
using System.Configuration;

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
            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, SearchCondition,out RecordCount).Tables[0];

            dt.Columns.Add("producturl");
            foreach (DataRow row in dt.Rows) row["producturl"] = GetProductUrl(Convert.ToInt32(row["productid"]));

            GridView1.DataSource = dt;
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

        private string GetProductUrl(int ProductID)
        {
            string ForeFlatRootUrl = ConfigurationManager.AppSettings["foreFlatRootUrl"];
            return String.Format("{0}product-{1}.html", ForeFlatRootUrl.EndsWith("/") ? ForeFlatRootUrl : ForeFlatRootUrl + "/", ProductID);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            //构建搜索条件
            
            if (CheckBox2.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox1.Text) && PageValidate.IsNumber(TextBox1.Text))
                {
                    SearchCondition += " and productid=" + TextBox1.Text;
                }
                else
                {
                    MessageBox.Show(this,"请输入正确的产品ID");
                    return;
                }
            }
            if (CheckBox3.Checked)
            {
                int Status = Convert.ToInt32(drpStatus.SelectedValue);
                SearchCondition += " and status='" + Status+"'";

            }
            if (CheckBox4.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox2.Text))
                {
                    SearchCondition += " and productname like '%" + TextBox2.Text + "%'";
                }
                else
                {
                    MessageBox.Show(this,"请输入产品名称");
                    return;
                }
            }
            if (CheckBox5.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text) && PageValidate.IsDate(TextBox3.Text) && PageValidate.IsDate(TextBox4.Text))
                {
                    DateTime start = Convert.ToDateTime(TextBox3.Text);
                    DateTime end = Convert.ToDateTime(TextBox4.Text);
                    SearchCondition += String.Format(" and InsertTime >= '{0}' and InsertTime <= '{1}'", start, end);
                }
                else
                {
                    MessageBox.Show(this,"请输入正确的日期");
                    return;
                }
            }

            if (!String.IsNullOrEmpty(SearchCondition))
            {
                BindData(1);
            }
        }
    }
}
