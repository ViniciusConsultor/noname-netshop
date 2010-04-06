using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.CMS.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.CMS.Page.News
{
    public partial class Edit : System.Web.UI.Page
    {
        private int PageID
        {
            get { if (ViewState["pageid"] != null)return Convert.ToInt32(ViewState["pageid"]); else return -1; }
            set { ViewState["pageid"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pageid"])) PageID = Convert.ToInt32(Request.QueryString["pageid"]);
                BindData();
            }
        }

        private void BindData()
        {
            PageModel page = PageControler.GetModel(PageID);

            DropDownList_Template.DataSource = TemplateControler.GetTemplateList(PageCategory.News);
            DropDownList_Template.DataTextField = "name";
            DropDownList_Template.DataValueField = "fullname";
            DropDownList_Template.DataBind();

            DropDownList_Template.SelectedValue = page.TempatePath;
            TextBox_PageName.Text = page.PageName;
            TextBox_PageTitle.Text = page.PageTitle;
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_PageName.Text)) ErrorMessage += "页面名称不能为空\\n";
            if (String.IsNullOrEmpty(TextBox_PageTitle.Text)) ErrorMessage += "页面标题不能为空\\n";

            if (!String.IsNullOrEmpty(ErrorMessage)) MessageBox.Show(this, ErrorMessage);


            PageModel page = PageControler.GetModel(PageID);
            page.PageTitle = TextBox_PageTitle.Text;

            PageControler.Update(page);
        }
    }
}
