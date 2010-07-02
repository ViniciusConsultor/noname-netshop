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
using NoName.NetShop.News.BLL;
using NoName.NetShop.News.Model;
using NoName.Utility;
using NoName.NetShop.News.Facade;
using NoName.NetShop.CMS.Controler;

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class Edit : System.Web.UI.Page
    {
        private int NewsID
        {
            get { if (ViewState["NewsID"] != null) return Convert.ToInt32(ViewState["NewsID"]); else return -1; }
            set { ViewState["NewsID"] = value; }
        }
        private int CurrentPageIndex
        {
            get { if (ViewState["CurrentPageIndex"] != null) return Convert.ToInt32(ViewState["CurrentPageIndex"]); else return 1; }
            set { ViewState["CurrentPageIndex"] = value; }
        }
        private NewsModelBll bll = new NewsModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pageid"])) CurrentPageIndex = Convert.ToInt32(Request.QueryString["pageid"]);
                NewsID = Convert.ToInt32(Request.QueryString["id"]);
                BindData();
            }
        }

        private void BindData()
        {
            NewsModel model = bll.GetModel(NewsID);

            if (model != null)
            {
                TextBox_Title.Text = model.Title;
                TextBox_SubTitle.Text = model.SubTitle;
                TextBox_Author.Text = model.Author;
                TextBox_NewsFrom.Text = model.From;
                TextBox_ProductID.Text = model.ProductId=="0"?"":model.ProductId;

                NewsCategorySelect1.PresetRegionInfo(new NewsCategoryModelBll().GetPath(model.CategoryID));

                TextBox_Tags.Text = model.Tags;
                TextBox_Brief.Text = model.Brief;
                TextBox_Content.Text = model.Content;
                Image_NewsImage.ImageUrl = NewsImageRule.GetImageUrl(model.ImageUrl);
            }
            else
            {
                MessageBox.Show(this, "指定新闻不存在");
            } 
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            NewsModel model = bll.GetModel(NewsID);
            bool IsEndClass;

            int SelectedParentCategoryID = NewsCategorySelect1.GetSelectedRegionInfo(out IsEndClass).CateID;

            string strErr = String.Empty;
            if (TextBox_Title.Text == String.Empty)
            {
                strErr += "新闻标题不能为空！\\n";
            }
            if (TextBox_Author.Text == String.Empty)
            {
                strErr += "新闻作者不能为空！\\n";
            }
            if (TextBox_NewsFrom.Text == String.Empty)
            {
                strErr += "新闻来源不能为空！\\n";
            }
            if (TextBox_Tags.Text == String.Empty)
            {
                strErr += "新闻标签不能为空！\\n";
            }
            if (!IsEndClass)
            {
                strErr += "新闻不能添加在非末级分类下！\\n";
            }

            if (strErr != String.Empty)
            {
                MessageBox.Show(this, strErr);
                return;
            }

            model.Title = TextBox_Title.Text;
            model.SubTitle = TextBox_SubTitle.Text;
            model.Author = TextBox_Author.Text;
            model.From = TextBox_NewsFrom.Text;
            model.CategoryID = SelectedParentCategoryID;
            model.Tags = TextBox_Tags.Text;
            model.Brief = TextBox_Brief.Text;
            model.Content = TextBox_Content.Text;
            model.ModifyTime = DateTime.Now;
            model.ProductId = String.IsNullOrEmpty(TextBox_ProductID.Text) ? "0" : TextBox_ProductID.Text;

            if (!String.IsNullOrEmpty(FileUpload_Image.FileName))
            {
                string ImageUrl = String.Empty;

                if (NewsImageRule.SaveNewsImage(NewsID, FileUpload_Image.PostedFile, out ImageUrl))
                {
                    model.ImageUrl = ImageUrl;
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败，请检查格式及大小是否正确。");
                    return;
                }
            }
            if (!String.IsNullOrEmpty(FileUpload_Video.FileName))
            {
                string VideoUrl = String.Empty;

                if (NewsVideoRule.SaveNewsVideo(NewsID, FileUpload_Video.PostedFile, out VideoUrl))
                {
                    model.VideoUrl = VideoUrl;
                }
                else
                {
                    MessageBox.Show(this, "视频上传失败，请检查格式及大小是否正确。");
                    return;
                }
            }

            bll.Update(model);
            PageControler.Publish(6, true);
            Response.Redirect("List.aspx?page=" + CurrentPageIndex);
        }
    }
}
