using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Model;
using NoName.NetShop.CMS.Data;
using System.Configuration;
using NoName.NetShop.CMS.Config;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace NoName.NetShop.BackFlat.CMS.Publish
{
    public partial class List : System.Web.UI.Page
    {
        private PageCategorySection config = (PageCategorySection)ConfigurationManager.GetSection("pageCategorySection");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = DataAccess.GetPageList(PageCategory.SecondaryPage);
            GridView1.DataBind();

            string[] Templates = Directory.GetFiles(Server.MapPath("../Templates"));
            DataTable dt = new DataTable();
            DataColumnCollection columns = dt.Columns;

            columns.Add("name");
            columns.Add("path");

            foreach (string t in Templates)
            {
                if (t.EndsWith("aspx"))
                {
                    DataRow row = dt.NewRow();
                    row["name"] = t.Substring(t.LastIndexOf("\\")+1);
                    row["path"] = "/cms" + Regex.Split(t, "CMS")[1].Replace("\\","/"); ;
                    dt.Rows.Add(row);
                }
            }

            this.SelectTemplate.DataSource = dt;
            this.SelectTemplate.DataTextField = "name";
            this.SelectTemplate.DataValueField = "path";
            this.SelectTemplate.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string PageName = TextBox1.Text;
            string PageTitle = TextBox2.Text;

            PageInfo page = new PageInfo();

            page.PageName = PageName;
            page.PageTitle = PageTitle;
            page.Author = "";
            page.Category = SelectCategory.SelectedValue == "1" ? PageCategory.Index : (SelectCategory.SelectedValue=="2"?PageCategory.SecondaryPage:PageCategory.TopicPage);
            page.CreateTime = DateTime.Now;
            page.LastModify = "";
            page.PhysicalPath = config.PageCategory[page.Category.ToString()].PhysicalPath + PageName;
            page.TemplatePath = SelectTemplate.SelectedValue;
            page.UpdateTime = DateTime.Now;

            DataAccess.PageInsert(page);

            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int PageID = Convert.ToInt32(e.CommandArgument);
                DataAccess.PageDelete(PageID);
                BindData();
            }
        }
    }
}
