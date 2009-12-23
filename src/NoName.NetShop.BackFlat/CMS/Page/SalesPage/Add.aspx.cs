using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.CMS.Model;
using NoName.Utility;
using NoName.NetShop.CMS.Config;
using System.Configuration;

namespace NoName.NetShop.BackFlat.CMS.Page.SalesPage
{
    public partial class Add : System.Web.UI.Page
    {
        private PageCategoryElement Element = ((PageCategorySection)ConfigurationManager.GetSection("pageCategorySection")).PageCategories["SalesPage"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DropDownList_Template.DataSource = TemplateControler.GetTemplateList(PageCategory.SalesPage);
            DropDownList_Template.DataTextField = "name";
            DropDownList_Template.DataValueField = "fullname";
            DropDownList_Template.DataBind();
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_PageName.Text)) ErrorMessage += "页面名称不能为空\n";
            if (String.IsNullOrEmpty(TextBox_PageTitle.Text)) ErrorMessage += "页面标题不能为空";

            if (!String.IsNullOrEmpty(ErrorMessage)) MessageBox.Show(this,ErrorMessage);

            PageModel page = new PageModel();

            page.PageName = TextBox_PageName.Text;
            page.PageTitle = TextBox_PageTitle.Text;
            page.Category = (int)PageCategory.SalesPage;
            page.PhysicalPath = String.Format(Element.NameRule, DateTime.Today.ToString("yyMM"), DateTime.Today.ToString("dd"), page.PageName);
            page.TempatePath = DropDownList_Template.SelectedValue;
            page.Author = "";
            page.LastModify = "";
            page.CreateTime = DateTime.Now;
            page.UpdateTime = page.CreateTime;
            page.SelfClassid = 0;
            page.ExtendPageInfo = "";

            PageControler.Insert(page);
            MessageBox.Show(this,"添加成功！");
        }
    }
}
