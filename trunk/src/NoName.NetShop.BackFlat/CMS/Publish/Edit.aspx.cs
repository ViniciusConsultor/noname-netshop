using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FredCK.FCKeditorV2;
using NoName.NetShop.CMS.Model;
using NoName.Utility;
using System.Reflection;

namespace NoName.NetShop.BackFlat.CMS.Publish
{
    public partial class Edit : System.Web.UI.Page
    {
        private int PageID
        {
            get { if (ViewState["pageid"] != null) return int.Parse(ViewState["pageid"].ToString()); else return -1; }
            set { ViewState["pageid"] = value; }
        }

        public PageInfo cmsPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            PageID = int.Parse(Request.QueryString["pid"].ToString());
            cmsPage = PageInfo.GetPageInfo(PageID);
            previewLink.HRef = cmsPage.TemplatePath + "?pageid=" + cmsPage.PageID;

            if (!IsPostBack)
            {
                Bind();
            }
            Initialize();
        }

        private void Bind()
        {
            //获取Page对象

            GridView1.DataSource = cmsPage.GetTemplateTags();
            GridView1.DataBind();
        }


        private void Initialize()
        {
            editWrap.Controls.Clear();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    string ServerID = GridView1.Rows[i].Cells[1].Text;
                    int TagID = int.Parse(GridView1.Rows[i].Cells[2].Text);

                    TagInfo tag = new TagInfo(TagID, ServerID);

                    //string ControlUrl = "/controls/TagEditor_" + GridView1.Rows[i].Cells[2].Text + ".ascx";

                    UserControl tagEditControl = (UserControl)LoadControl(tag.EditControl);
                    Type tagEditControl_type = tagEditControl.GetType();
                    //下面是给ascx赋值

                    PropertyInfo tagEditControl_PageID = tagEditControl_type.GetProperty("PageID");//) .GetProperty("RelatedDatagrid");
                    tagEditControl_PageID.SetValue(tagEditControl, PageID, null);

                    PropertyInfo tagEditControl_ServerID = tagEditControl_type.GetProperty("ServerID");
                    tagEditControl_ServerID.SetValue(tagEditControl, ServerID, null);

                    PropertyInfo tagEditControl_ID = tagEditControl_type.GetProperty("ID");
                    tagEditControl_ID.SetValue(tagEditControl, ServerID + "-Eidtor", null);

                    editWrap.Controls.Add(tagEditControl);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("chkItem")).Checked == true)
                {
                    string ServerID = GridView1.Rows[i].Cells[1].Text;
                    int TagID = int.Parse(GridView1.Rows[i].Cells[2].Text);

                    TagInfo tag = new TagInfo(TagID, ServerID);
                    switch (TagID)
                    {
                        case 1:
                            FCKeditor editor1 = (FCKeditor)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("FCKeditor1"));
                            tag.SaveContent(PageInfo.GetPageInfo(PageID), null, editor1.Value);
                            break;
                        case 2:
                            FCKeditor editor2 = (FCKeditor)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("FCKeditor1"));

                            TagParameterInfo parm2 = new TagParameterInfo();
                            parm2.PageID = PageID;
                            parm2.TagID = TagID;
                            parm2.ServerID = ServerID;
                            parm2.Parameters = HttpUtil.GetParameters("productids=" + ((TextBox)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("TextBox1"))).Text);
                            parm2.IsUseDefault = ((CheckBox)(editWrap.FindControl(ServerID + "-Eidtor").FindControl("CheckBox1"))).Checked;

                            tag.SaveContent(PageInfo.GetPageInfo(PageID), parm2, editor2.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            Initialize();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //string url = cmsPage.TemplatePath + "?pageid=" + cmsPage.PageID;

            //Uri uri = new Uri(url, UriKind.Relative);
            cmsPage.PublishPageFile();
        }
    }
}
