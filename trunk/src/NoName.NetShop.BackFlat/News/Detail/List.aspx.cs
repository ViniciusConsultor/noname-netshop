using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NoName.Utility;
using NoName.NetShop.News.BLL;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.News.Model;

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class List : System.Web.UI.Page
    {
        private NewsModelBll bll = new NewsModelBll();
        private string SearchCondition
        {
            get { if (ViewState["news-SearchCondition"] != null) return (string)ViewState["news-SearchCondition"]; else return null; }
            set { ViewState["news-SearchCondition"] = value; }
        }
        public int InitialPageIndex
        {
            get { if (ViewState["InitialPageIndex"] != null) return Convert.ToInt32(ViewState["InitialPageIndex"]); else return 1; }
            set { ViewState["InitialPageIndex"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["page"])) InitialPageIndex = Convert.ToInt32(Request.QueryString["page"]);
                BindData(InitialPageIndex);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;
            GetSearchCondition();

            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, SearchCondition, out RecordCount);

            GridView1.DataSource = ProcessCategory(dt);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
            AspNetPager.CurrentPageIndex = PageIndex;
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            InitialPageIndex = AspNetPager.CurrentPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(NewsID);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(6, true);
            }
            if (e.CommandName == "ss")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.SetSplendid(NewsID, true);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(6, true);
            }
            if (e.CommandName == "ds")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.SetSplendid(NewsID, false);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(6, true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[5].FindControl("LinkButton_Delete")).Attributes.Add("onclick", "javascript:return confirm('确认删除?')");
                }
            }
        }

        private DataTable ProcessCategory(DataTable dt)
        {
            string ForeFlatRootUrl = ConfigurationManager.AppSettings["foreFlatRootUrl"];

            dt.Columns.Add("catename");
            dt.Columns.Add("fronturl");

            foreach (DataRow row in dt.Rows)
            {
                row["catename"] = new NewsCategoryModelBll().GetModel(Convert.ToInt32(row["cateid"])).CateName;
                row["fronturl"] = String.Format("{0}news-{1}.html", ForeFlatRootUrl.EndsWith("/") ? ForeFlatRootUrl : ForeFlatRootUrl + "/", row["newsid"]);
            }
            return dt;
        }

        protected void Button_Search_Click(object o, EventArgs e)
        {
            BindData(1);
        }

        public void GetSearchCondition()
        {
            SearchCondition = "";

            if (CheckBox_NewsID.Checked)
            {
                if (PageValidate.IsNumber(TextBox_NewsID.Text))
                {
                    SearchCondition += " and newsid=" + Convert.ToInt32(TextBox_NewsID.Text);
                }
                else
                {
                    MessageBox.Show(this,"请输入正确的新闻ID");
                    return;
                }
            }

            if (CheckBox_NewsName.Checked)
            {
                if (!String.IsNullOrEmpty(TextBox_NewsName.Text))
                {
                    SearchCondition += " and title like '%" + TextBox_NewsName.Text.Trim().Replace("'","") + "%'";
                }
                else
                {
                    MessageBox.Show(this, "请输入新闻标题");
                    return;
                }
            }

            if (CheckBox_Category.Checked)
            { 
                bool test;
                NewsCategoryModel model = NewsCategorySelect1.GetSelectedRegionInfo(out test);
                if (model != null)
                {
                    SearchCondition += " and dbo.GetNewsCategoryPath(cateid)+'/' like dbo.GetNewsCategoryPath(" + model.CateID + ")+'/%'";

                    if (!CheckBox_Category.Checked) CheckBox_Category.Checked = true;
                    string CategoryPath = new NewsCategoryModelBll().GetPath(model.CateID);
                    //CategoryPath = CategoryPath.Contains("/") ? CategoryPath.Substring(0, CategoryPath.LastIndexOf("/")) : CategoryPath;
                    NewsCategorySelect1.PresetRegionInfo(CategoryPath);
                }
                else
                {
                    MessageBox.Show(this, "请选择分类");
                    return;
                }
            }
            
        }
    }
}
