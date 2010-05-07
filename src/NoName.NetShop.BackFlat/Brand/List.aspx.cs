using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.Utility;
using System.Data;
using NoName.NetShop.Common;
using System.Configuration;

namespace NoName.NetShop.BackFlat.Brand
{
    public partial class List : System.Web.UI.Page
    {
        private BrandModelBll bll = new BrandModelBll();
        private string SearchCondition
        {
            get { if (ViewState["SearchCondition"] != null) return ViewState["SearchCondition"].ToString(); else return String.Empty; }
            set { ViewState["SearchCondition"] = value; }
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
            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, SearchCondition, out RecordCount).Tables[0];

            foreach (DataRow row in dt.Rows) row["brandlogo"] = CommonImageUpload.GetCommonImageFullUrl(row["brandlogo"].ToString());

            GridView1.DataSource = dt;
            GridView1.DataBind();
            AspNetPager.RecordCount = RecordCount;
            AspNetPager.CurrentPageIndex = PageIndex;
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            InitialPageIndex = AspNetPager.CurrentPageIndex;
            BindData(InitialPageIndex);
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

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            SearchCondition = String.Empty;
            if (String.IsNullOrEmpty(TextBox_BrandName.Text))
            {
                MessageBox.Show(this, "请输入检索词");
                return;
            }
            else
            {
                SearchCondition += " and brandname like '%" + TextBox_BrandName.Text + "%'";
                BindData(1);
            }
        }

        protected void Link_Back_Click(object sender, EventArgs e)
        {
            SearchCondition = String.Empty;
            TextBox_BrandName.Text = String.Empty;
            BindData(1); 
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


        public string GetBrandUrl(int BrandID)
        {
            string BrandUrl = ConfigurationManager.AppSettings["foreFlatRootUrl"] + "brand-{0}.html";
            return String.Format(BrandUrl,BrandID);
        }
    }
}
