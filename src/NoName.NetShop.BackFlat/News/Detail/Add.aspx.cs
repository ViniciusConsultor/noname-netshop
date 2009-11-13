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

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class Add : System.Web.UI.Page
    {
        private NewsModelBll bll = new NewsModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button_ImageUpload_Click(object sender, EventArgs e) { }
        protected void Button_VideoUpload_Click(object sender, EventArgs e){}

        protected void Button_Submit_Click(object sender, EventArgs e) 
        {
            int SelectedParentCategoryID = Convert.ToInt32(((HtmlInputHidden)NewsCategorySelect1.FindControl("selectedCategory")).Value);

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
            if (new NewsCategoryModelBll().GetList(SelectedParentCategoryID).Rows.Count > 0)
            {
                strErr += "新闻不能添加在非末级分类下！\\n";
            }

            if (strErr != String.Empty)
            {
                MessageBox.Show(this, strErr);
                return;
            }

            NewsModel model = new NewsModel();

            model.NewsId = CommDataHelper.GetNewSerialNum("ne"); 
            model.Title = TextBox_Title.Text;
            model.SubTitle = TextBox_SubTitle.Text;
            model.Author = TextBox_Author.Text;
            model.From = TextBox_NewsFrom.Text;
            model.CategoryID = SelectedParentCategoryID;
            model.Tags = TextBox_Tags.Text;
            model.Brief = TextBox_Brief.Text;
            model.Content = TextBox_Content.Value;
            model.InsertTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            model.ProductId = String.IsNullOrEmpty(TextBox_ProductID.Text) ? "0" : TextBox_ProductID.Text;


            model.NewsType = 1;
            model.Status = 1;
            model.ImageUrl = "";
            model.SmallImageUrl = "";
            model.VideoUrl = "";

            bll.Add(model);
            MessageBox.Show(this,"添加成功！");
            Response.Redirect(Request.RawUrl);

        }
    }
}
