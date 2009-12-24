using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using NoName.NetShop.CMS.Config;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.CMS.Model;
using System.Reflection;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.CMS.Page.HomePage
{
    public partial class Publish : System.Web.UI.Page
    {
        private int PageID
        {
            get { if (ViewState["PUBLISH-PAGEID"] != null) return Convert.ToInt32(ViewState["PUBLISH-PAGEID"]); else return -1; }
            set { ViewState["PUBLISH-PAGEID"] = value; }
        }
        private PageCategorySection Config = (PageCategorySection)ConfigurationManager.GetSection("pageCategorySection");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pageid"])) PageID = Convert.ToInt32(Request.QueryString["pageid"]);
                BindData();
            }
            Initialize();
        }

        private void BindData()
        {
            PageModel model = PageControler.GetModel(PageID);

            Label_PageTitle.InnerText = model.PageTitle;

            GridView1.DataSource = TemplateControler.GetTagList(PageID);
            GridView1.DataBind();

            string PreviewUrl = String.Empty, FormalUrl = String.Empty;

            PageControler.GetPageUrl(PageID, Config.PageCategories["HomePage"], out PreviewUrl, out FormalUrl);

            Link_Preview.NavigateUrl = PreviewUrl;
            Link_Formal.NavigateUrl = FormalUrl;
        }

        private void Initialize()
        {
            editWrap.Controls.Clear();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    string ServerID = GridView1.Rows[i].Cells[2].Text;
                    int TagID = int.Parse(GridView1.Rows[i].Cells[3].Text);
                    string TagTitle = ((DataBoundLiteralControl)GridView1.Rows[i].Cells[1].Controls[0]).Text;

                    TagModel tag = TagControler.GetModel(TagID);


                    UserControl tagEditControl = (UserControl)LoadControl(tag.EditControl);
                    Type tagEditControl_type = tagEditControl.GetType();
                    //下面是给ascx赋值

                    PropertyInfo tagEditControl_PageID = tagEditControl_type.GetProperty("PageID");
                    tagEditControl_PageID.SetValue(tagEditControl, PageID, null);

                    PropertyInfo tagEditControl_ServerID = tagEditControl_type.GetProperty("ServerID");
                    tagEditControl_ServerID.SetValue(tagEditControl, ServerID, null);

                    PropertyInfo tagEditControl_TagID = tagEditControl_type.GetProperty("TagID");
                    tagEditControl_TagID.SetValue(tagEditControl, TagID, null);

                    PropertyInfo tagEtitControl_TagTitle = tagEditControl_type.GetProperty("TagTitle");
                    tagEtitControl_TagTitle.SetValue(tagEditControl, TagTitle, null);

                    PropertyInfo tagEditControl_ID = tagEditControl_type.GetProperty("ID");
                    tagEditControl_ID.SetValue(tagEditControl, ServerID + "-Eidtor", null);

                    editWrap.Controls.Add(tagEditControl);
                }
            }
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    string ServerID = GridView1.Rows[i].Cells[2].Text;
                    int TagID = int.Parse(GridView1.Rows[i].Cells[3].Text);
                    string TagTitle = ((DataBoundLiteralControl)GridView1.Rows[i].Cells[1].Controls[0]).Text;

                    string Content = ((TextBox)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("TextBox_Content"))).Text;

                    TagContentModel TagContent = new TagContentModel();
                    TagContent.PageID = PageID;
                    TagContent.ServerID = ServerID;
                    TagContent.TagID = TagID;
                    TagContent.Content = Content;

                    TagControler.TagContentImport(TagContent);
                }
            }
            MessageBox.Show(this, "保存成功！");
        }

        protected void Button_Publish_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    string ServerID = GridView1.Rows[i].Cells[2].Text;
                    int TagID = int.Parse(GridView1.Rows[i].Cells[3].Text);
                    string TagTitle = ((DataBoundLiteralControl)GridView1.Rows[i].Cells[1].Controls[0]).Text;

                    string Content = ((TextBox)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("TextBox_Content"))).Text;

                    TagContentModel TagContent = new TagContentModel();
                    TagContent.PageID = PageID;
                    TagContent.ServerID = ServerID;
                    TagContent.TagID = TagID;
                    TagContent.Content = Content;

                    TagControler.TagContentImport(TagContent);
                }
            }
            PageControler.Publish(PageID);
            MessageBox.Show(this, "发布成功！");
        }
    }
}
