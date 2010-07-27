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
using System.Text.RegularExpressions;
using System.Collections;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class List : System.Web.UI.Page
    {
        private string SearchCondition
        {
            get { if (Session["product-SearchCondition"] != null) return (string)Session["product-SearchCondition"]; else return null; }
            set { Session["product-SearchCondition"] = value; }
        }
        public int InitialPageIndex
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
            //Response.Write(Session["product-SearchCondition"]==null?"":Session["product-SearchCondition"].ToString());
        }

        //大类>>小类，商品点击量|购买量    批量操作上下架
        private void BindData(int PageIndex)
        {
            if (SearchCondition != ConstructSearchCondition())
                SearchCondition = ConstructSearchCondition();

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
            AspNetPager.CurrentPageIndex = PageIndex;

            //InitializeSerchCondition();
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
            InitialPageIndex = AspNetPager.CurrentPageIndex;
            BindData(InitialPageIndex);

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

        private string ConstructSearchCondition()
        {
            string condition = String.Empty;
            //构建搜索条件
            if (CheckBox1.Checked || InitialCategoryID!=-1)
            {
                #region s1
                bool IsEnd;
                int SelectedCategoryID = 0;
                string s1 = String.Empty;

                if (IsPostBack)
                {
                    SelectedCategoryID = CategorySelect1.GetSelectedRegionInfo().CateId;
                    if (SelectedCategoryID == -1)
                    {
                        MessageBox.Show(this, "请至少选择一个分类");
                        return String.Empty; 
                    }
                }
                else
                {
                    SelectedCategoryID = InitialCategoryID;
                }

                if (SelectedCategoryID != -1)
                {
                    string CategoryPath = new CategoryModelBll().GetModel(SelectedCategoryID).CatePath;
                    s1=" and catepath like '" + CategoryPath + "%'";
                    condition += s1;
                    //SearchCondition.Add("s1",s1);

                    if (!CheckBox1.Checked) CheckBox1.Checked = true;
                    CategoryPath = CategoryPath.Substring(0, CategoryPath.LastIndexOf("/"));
                    CategorySelect1.PresetRegionInfo(CategoryPath);
                }
                #endregion
            }

            if (CheckBox2.Checked)
            {
                #region s2
                string s2 = String.Empty;
                if (!String.IsNullOrEmpty(TextBox1.Text) && PageValidate.IsNumber(TextBox1.Text))
                {
                    s2 = " and productid=" + TextBox1.Text;
                    condition += s2;
                    //SearchCondition.Add("s2",s2);
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的产品ID");
                    return String.Empty;
                }
                #endregion
            }
            if (CheckBox3.Checked)
            {
                #region s3
                string s3 = String.Empty;
                int Status = Convert.ToInt32(drpStatus.SelectedValue);
                s3 = " and status='" + Status + "'";
                condition += s3;
                #endregion
            }
            if (CheckBox4.Checked)
            {

                if (!String.IsNullOrEmpty(TextBox2.Text))
                {
                    condition += " and productname like '%" + TextBox2.Text + "%'";
                }
                else
                {
                    MessageBox.Show(this, "请输入产品名称");
                    return String.Empty;
                }
            }
            if (CheckBox5.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text) && PageValidate.IsDate(TextBox3.Text) && PageValidate.IsDate(TextBox4.Text))
                {
                    DateTime start = Convert.ToDateTime(TextBox3.Text);
                    DateTime end = Convert.ToDateTime(TextBox4.Text);
                    condition += String.Format(" and InsertTime >= '{0}' and InsertTime <= '{1}'", start, end);
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的日期");
                    return String.Empty;
                }
            }
            if (CheckBox6.Checked)
            {
                if (!String.IsNullOrEmpty(TextBoxSearch_ScoreStart.Text) && !String.IsNullOrEmpty(TextBoxSearch_ScoreEnd.Text))
                    condition += String.Format(" and score between {0} and {1}", TextBoxSearch_ScoreStart.Text, TextBoxSearch_ScoreEnd.Text);
                else
                {
                    MessageBox.Show(this, "请输入正确的积分");
                    return String.Empty;
                }
            }
            if (CheckBox7.Checked)
            {
                int StockStatus = Convert.ToInt32(DropDownList_Stock.SelectedValue);
                if (StockStatus == 0)
                    condition += " and stock=0";
                else
                    condition += " and stock>0";
            }
            if (CheckBox8.Checked)
            {
                if (!String.IsNullOrEmpty(TextBoxSearch_StartTime.Text) && !String.IsNullOrEmpty(TextBoxSearch_EndTime.Text) && PageValidate.IsDate(TextBoxSearch_StartTime.Text) && PageValidate.IsDate(TextBoxSearch_EndTime.Text))
                {
                    DateTime start = Convert.ToDateTime(TextBoxSearch_StartTime.Text);
                    DateTime end = Convert.ToDateTime(TextBoxSearch_EndTime.Text);
                    condition += String.Format(" and changetime >= '{0}' and changetime <= '{1}'", start, end);
                }
                else
                {
                    MessageBox.Show(this, "请输入正确的日期");
                    return String.Empty;
                }
            }
            if (CheckBox9.Checked)
            {
                BrandModel model ;

                if (!String.IsNullOrEmpty(TextBoxSearch_Brand.Text.Trim()) && new BrandModelBll().RawExists(TextBoxSearch_Brand.Text.Trim(),out model))
                {
                    condition += String.Format(" and brandid = " + model.BrandId);
                }
                else
                {
                    MessageBox.Show(this,"未输入或未查找到您输入的品牌");
                    return String.Empty;
                }
            }

            return condition;
        }

        //private void InitializeSerchCondition()
        //{
        //    if (SearchCondition.Contains("catepath like"))
        //    {
        //        CheckBox1.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"and catepath like '(?<catepath>.+)%'");
        //        if (m.Success)
        //            CategorySelect1.PresetRegionInfo(m.Groups["catepath"].ToString());
        //    }

        //    if (SearchCondition.Contains("productid="))
        //    {
        //        CheckBox2.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"and productid=(?<pid>\d+)");
        //        if (m.Success)
        //            TextBox1.Text = m.Groups["pid"].ToString();
        //    }

        //    if (SearchCondition.Contains("status="))
        //    {
        //        CheckBox3.Checked = true;
        //        Match m = Regex.Match(SearchCondition,@"and status='(?<status>\d+)'");
        //        if (m.Success)
        //            drpStatus.SelectedValue = m.Groups["status"].ToString();
        //    }

        //    if (SearchCondition.Contains("productname like"))
        //    {
        //        CheckBox4.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"and productname like '%(?<pname>.+)%'");
        //        if (m.Success)
        //            TextBox2.Text = m.Groups["pname"].ToString();
        //    }

        //    if (SearchCondition.Contains("InsertTime"))
        //    {
        //        CheckBox5.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"and InsertTime >= '(?<st>.+)' and InsertTime <= '(?<et>.+)'");
        //        if (m.Success)
        //        {
        //            TextBox3.Text = Convert.ToDateTime(m.Groups["st"]).ToString("yyyy-MM-dd");
        //            TextBox4.Text = Convert.ToDateTime(m.Groups["et"]).ToString("yyyy-MM-dd");
        //        }
        //    }

        //    if (SearchCondition.Contains("score between"))
        //    {                
        //        CheckBox6.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"and score between (?<ss>.+) and (?<se>.+)");
        //        if (m.Success)
        //        {
        //            TextBoxSearch_ScoreStart.Text = m.Groups["ss"].ToString();
        //            TextBoxSearch_ScoreEnd.Text = m.Groups["se"].ToString();
        //        }
        //    }

        //    if (SearchCondition.Contains("stock"))
        //    {
        //        CheckBox7.Checked = true;
        //        Match m = Regex.Match(SearchCondition, @"stock(?<stock>=|\>)(\d+)");
        //        if (m.Success)
        //        {
        //            DropDownList_Stock.SelectedValue = m.Groups["stock"].ToString() == "=" ? "0" : "1";
        //        }
        //    }

        //    if (SearchCondition.Contains("changetime"))
        //    {
        //        CheckBox8.Checked = true;
        //        DateTime start = Convert.ToDateTime(TextBoxSearch_StartTime.Text);
        //        DateTime end = Convert.ToDateTime(TextBoxSearch_EndTime.Text);
        //        SearchCondition += String.Format(" and changetime >= '{0}' and changetime <= '{1}'", start, end);

        //        Match m = Regex.Match(SearchCondition, @"changetime >= '(?<cs>\.+)' and changetime <= '(?<ce>\.+)'");
        //        if (m.Success)
        //        {
        //            TextBoxSearch_StartTime.Text=Convert.ToDateTime(m.Groups["cs"]).ToString("yyyy-MM-dd");
        //            TextBoxSearch_EndTime.Text = Convert.ToDateTime(m.Groups["ce"]).ToString("yyyy-MM-dd");
        //        }
        //    }

        //    if (SearchCondition.Contains("brandid"))
        //    {
        //        CheckBox9.Checked = true; 
        //        Match m = Regex.Match(SearchCondition, @"and brandid = (?<bid>\d+)");
        //        if (m.Success)
        //        {
        //            BrandModel b = new BrandModelBll().GetModel(Convert.ToInt32(m.Groups["bid"]));
        //            TextBoxSearch_Brand.Text = b.BrandName;
        //        }
        //    }
        //}
    }
}
