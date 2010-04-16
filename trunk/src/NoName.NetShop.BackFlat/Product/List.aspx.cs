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
using NoName.NetShop.Search.Config;
using NoName.NetShop.Search.DataIndexer;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class List : System.Web.UI.Page
    {
        private string SearchCondition
        {
            get { if (ViewState["SearchCondition"] != null) return ViewState["SearchCondition"].ToString(); else return String.Empty; }
            set { ViewState["SearchCondition"]=value; }
        }
        private int InitialPageIndex
        {
            get { if (ViewState["InitialPageIndex"] != null) return Convert.ToInt32(ViewState["InitialPageIndex"]); else return 1; }
            set { ViewState["InitialPageIndex"] = value; }
        }
        private int InitialCategoryID
        {
            get { if (ViewState["InitialCategoryID"] != null) return Convert.ToInt32(ViewState["InitialCategoryID"]); else return -1; }
            set { ViewState["InitialCategoryID"] = value; }
        }
        private ProductModelBll bll = new ProductModelBll();
        private SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["page"])) InitialPageIndex = Convert.ToInt32(Request.QueryString["page"]);
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) InitialCategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                BindData(InitialPageIndex);
                BindDropDownData();
            }
        }

        //大类>>小类，商品点击量|购买量    批量操作上下架
        private void BindData(int PageIndex)
        {
            ConstructSearchCondition();

            //Response.Write(SearchCondition);
            int RecordCount=0;
            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, SearchCondition, out RecordCount).Tables[0];

            //Response.Write("<br/>recordcount:"+RecordCount);

            dt.Columns.Add("producturl");
            dt.Columns.Add("secondarycategoryid");
            dt.Columns.Add("secondarycategoryname");
            dt.Columns.Add("endcategoryid");
            dt.Columns.Add("endcategoryname");
            dt.Columns.Add("ishotsale");
            dt.Columns.Add("isreduce");
            dt.Columns.Add("isrecommend");

            foreach (DataRow row in dt.Rows)
            {
                string CategoryNamePath = new CategoryModelBll().GetCategoryNamePath(Convert.ToInt32(row["cateid"]));
                string CategoryIDPath = new CategoryModelBll().GetCategoryPath(Convert.ToInt32(row["cateid"]));
                row["producturl"] = GetProductUrl(Convert.ToInt32(row["productid"]));

                row["secondarycategoryid"] = CategoryIDPath.Split('/')[1];
                row["endcategoryid"] = CategoryIDPath.Split('/')[CategoryIDPath.Split('/').Length - 2];

                row["secondarycategoryname"] = CategoryNamePath.Split('/')[1];
                row["endcategoryname"] = CategoryNamePath.Split('/')[CategoryNamePath.Split('/').Length-2];

                SalesProductModelBll salesBll = new SalesProductModelBll();
                row["ishotsale"] = salesBll.Exists(Convert.ToInt32(row["productid"]),SalesProductType.热销商品);
                row["isreduce"] = salesBll.Exists(Convert.ToInt32(row["productid"]), SalesProductType.直降特卖);
                row["isrecommend"] = salesBll.Exists(Convert.ToInt32(row["productid"]), SalesProductType.鼎鼎推荐);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
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

                DataIndexerProduct SearchIndexer = new DataIndexerProduct(Config.Searches["product"]);
                SearchIndexer.DeleteSingleIndex(ProductID);
            }
            if (e.CommandName.ToLower() == "s1")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().SetSalesProduct(ProductID, SalesProductType.热销商品);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "d1")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().DesetSalesProduct(ProductID, SalesProductType.热销商品);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "s2")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().SetSalesProduct(ProductID, SalesProductType.直降特卖);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "d2")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().DesetSalesProduct(ProductID, SalesProductType.直降特卖);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "s3")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().SetSalesProduct(ProductID, SalesProductType.鼎鼎推荐);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName.ToLower() == "d3")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                new SalesProductModelBll().DesetSalesProduct(ProductID, SalesProductType.鼎鼎推荐);
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

        protected void Button_MassOn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    int ProductID = int.Parse(GridView1.Rows[i].Cells[1].Text);
                    bll.UpdateStatus(ProductID, ProductStatus.上架);
                }
            }
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void Button_MassOff_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    int ProductID = int.Parse(GridView1.Rows[i].Cells[1].Text);
                    bll.UpdateStatus(ProductID, ProductStatus.下架);
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
                    ((LinkButton)e.Row.Cells[10].FindControl("LinkButtonDelete")).Attributes.Add("onclick", "javascript:return confirm('确认删除?')");                    
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
                BindData(1);
        }

        private void ConstructSearchCondition()
        {
            SearchCondition = String.Empty;
            //构建搜索条件
            if (CheckBox1.Checked || InitialCategoryID!=-1)
            {
                bool IsEnd;
                int SelectedCategoryID = 0;

                if (IsPostBack)
                {
                    SelectedCategoryID = CategorySelect1.GetSelectedCategoryInfo(out IsEnd);
                    if (SelectedCategoryID == -1)
                    {
                        MessageBox.Show(this, "请至少选择一个分类");
                        return; 
                    }
                }
                else
                {
                    SelectedCategoryID = InitialCategoryID;
                }

                if (SelectedCategoryID != -1)
                {
                    string CategoryPath = new CategoryModelBll().GetModel(SelectedCategoryID).CatePath;
                    SearchCondition += " and catepath like '" + CategoryPath + "%'";

                    if (!CheckBox1.Checked) CheckBox1.Checked = true;
                    CategoryPath = CategoryPath.Substring(0, CategoryPath.LastIndexOf("/"));
                    CategorySelect1.PresetCategoryInfo(CategoryPath);
                }
            }

            if (CheckBox2.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox1.Text) && PageValidate.IsNumber(TextBox1.Text))
                {
                    SearchCondition += " and productid=" + TextBox1.Text;
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的产品ID");
                    return;
                }
            }
            if (CheckBox3.Checked)
            {
                int Status = Convert.ToInt32(drpStatus.SelectedValue);
                SearchCondition += " and status='" + Status + "'";

            }
            if (CheckBox4.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox2.Text))
                {
                    SearchCondition += " and productname like '%" + TextBox2.Text + "%'";
                }
                else
                {
                    MessageBox.Show(this, "请输入产品名称");
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
                    MessageBox.Show(this, "请输入正确的日期");
                    return;
                }
            }
            if (CheckBox6.Checked)
            {
                if (!String.IsNullOrEmpty(TextBoxSearch_ScoreStart.Text) && !String.IsNullOrEmpty(TextBoxSearch_ScoreEnd.Text))
                    SearchCondition += String.Format(" and score between {0} and {1}", TextBoxSearch_ScoreStart.Text, TextBoxSearch_ScoreEnd.Text);
                else
                {
                    MessageBox.Show(this, "请输入正确的积分");
                    return;
                }
            }
            if (CheckBox7.Checked)
            {
                int StockStatus = Convert.ToInt32(DropDownList_Stock.SelectedValue);
                if (StockStatus == 0)
                    SearchCondition += " and stock=0";
                else
                    SearchCondition += " and stock>0";
            }
            if (CheckBox8.Checked)
            {
                if (!String.IsNullOrEmpty(TextBoxSearch_StartTime.Text) && !String.IsNullOrEmpty(TextBoxSearch_EndTime.Text) && PageValidate.IsDate(TextBoxSearch_StartTime.Text) && PageValidate.IsDate(TextBoxSearch_EndTime.Text))
                {
                    DateTime start = Convert.ToDateTime(TextBoxSearch_StartTime.Text);
                    DateTime end = Convert.ToDateTime(TextBoxSearch_EndTime.Text);
                    SearchCondition += String.Format(" and changetime >= '{0}' and changetime <= '{1}'", start, end);
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的日期");
                    return;
                }
            }
        }
    }
}
