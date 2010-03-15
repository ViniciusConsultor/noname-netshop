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
using NoName.NetShop.Common;
using NoName.NetShop.News.Facade;

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class Add : System.Web.UI.Page
    {
        private NewsModelBll bll = new NewsModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button_Submit_Click(object sender, EventArgs e) 
        {
            bool isEndCate = false;
            int SelectedParentCategoryID = NewsCategorySelect1.GetSelectedCategoryInfo(out isEndCate);

            string strErr = String.Empty;
            if (TextBox_Title.Text == String.Empty)
            {
                strErr += "新闻标题不能为空！\\n";
            }
            if (TextBox_Author.Text==String.Empty)
            {
                strErr += "新闻作者不能为空！\\n";
            }
            if (TextBox_Tags.Text == String.Empty)
            {
                strErr += "新闻标签不能为空！\\n";
            }
            if (!isEndCate)
            {
                strErr += "新闻不能添加在非末级分类下！\\n";
            }

            if (strErr != String.Empty)
            {
                MessageBox.Show(this, strErr);
                return;
            }

            int NewsID = CommDataHelper.GetNewSerialNum("ne"); 
            NewsModel model = new NewsModel();

            model.NewsId = NewsID;
            model.Title = TextBox_Title.Text;
            model.SubTitle = TextBox_SubTitle.Text;
            model.Author = TextBox_Author.Text;
            model.From = TextBox_NewsFrom.Text;
            model.CategoryID = SelectedParentCategoryID;
            model.Tags = TextBox_Tags.Text;
            model.Brief = TextBox_Brief.Text;
            model.Content = TextBox_Content.Text;
            model.InsertTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            model.ProductId = String.IsNullOrEmpty(TextBox_ProductID.Text) ? "0" : TextBox_ProductID.Text;


            model.NewsType = 1;
            model.Status = 1;
            model.ImageUrl = "";
            model.SmallImageUrl = "";
            model.VideoUrl = "";

            if (!String.IsNullOrEmpty(FileUpload_Image.FileName))
            {
                string ImageUrl = String.Empty;

                if (NewsImageRule.SaveNewsImage(NewsID, FileUpload_Image.PostedFile, out ImageUrl))
                {
                    model.ImageUrl = ImageUrl;
                }
                else
                {
                    MessageBox.Show(this,"图片上传失败！");
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
                    MessageBox.Show(this,"视频上传失败！");
                }
            }

            bll.Add(model);
            Response.Redirect("List.aspx");
        }
    }
}
