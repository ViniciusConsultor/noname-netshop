using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Comment;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Product.Model;
using NoName.Utility;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Product
{
    public partial class TopicList : System.Web.UI.Page
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return -1; }
            set { ViewState["ProductID"] = value; }
        }
        private ProductModelBll productBll = new ProductModelBll();
        private TopicBll topicBll = new TopicBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //验证用户，如果未登录则提示登录
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                else throw new ArgumentNullException();


                BindProductData();
                BindTopicData(1);
            }
        }

        private void BindProductData()
        {
            ProductModel model = productBll.GetModel(ProductID);

            Literal_ProductID.Text = model.ProductId.ToString();

            Literal_ProductName1.Text = model.ProductName;
            Literal_ProductName2.Text = model.ProductName;

            Literal_MerchantPrice.Text = model.MerchantPrice.ToString("0.00");
            Literal_TradePrice.Text = model.TradePrice.ToString("0.00");

            Image_LargeImage.ImageUrl = ProductMainImageRule.GetMainImageUrl(model.LargeImage);
            Image_SmallImage.ImageUrl = ProductMainImageRule.GetMainImageUrl(model.MediumImage);

            HyperLink_Buy.NavigateUrl = "/sp/addtocart.aspx?pid=" + model.ProductId;
            HyperLink_Favorite.NavigateUrl = "";
        }

        private void BindTopicData(int PageIndex)
        {
            int RecordCount = 0;
            DataTable dt = topicBll.GetList(PageIndex, AspNetPager.PageSize,ProductID, Common.ContentType.Product, out RecordCount);

            Repeater_TopicList.DataSource = dt;
            Repeater_TopicList.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }

        protected void Button_Submit_Click(object sender,EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(TextBox_TopicTitle.Text)) ErrorMessage += "主题标题不能为空；";
            if (String.IsNullOrEmpty(TextBox_TopicContent.Text)) ErrorMessage += "主题内容不能为空";
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            TopicModel model = new TopicModel();

            model.TopicId = CommDataHelper.GetNewSerialNum(AppType.Other);
            model.Title = "";
            model.Content = "";
            model.UserId = "";
            model.InsertTime = DateTime.Now;

            model.ContentId = ProductID;
            model.ContentType = NoName.NetShop.Common.ContentType.Product;
            //model.LastReplyId = "";
            //model.LastReplyTime = "";
            //model.ReplyNum = "";
            model.Status = true;

            topicBll.Add(model); 
        }


        private string GetUserID()
        {
            return "zhangfeng";
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindTopicData(e.NewPageIndex);
        }
    }
}
