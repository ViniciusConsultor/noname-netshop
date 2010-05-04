using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Comment;
using NoName.Utility;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Product.Model;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Product
{
    public partial class QuestionList : AuthBasePage
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return -1; }
            set { ViewState["ProductID"] = value; }
        }
        private ProductModelBll productBll = new ProductModelBll();
        private QuestionBll questionBll = new QuestionBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //验证用户，如果未登录则提示登录
                if (CurrentUser == null || !CurrentUser.IsAuthenticated)
                {
                    Response.Redirect("/Login.aspx?returnurl="+Request.RawUrl);
                    return;
                }

                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                else throw new ArgumentNullException();

                BindProductData();
                BindQuestionData(1);
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

        private void BindQuestionData(int PageIndex)
        {
            int RecordCount = 0;
            DataTable dt = questionBll.GetList(PageIndex,AspNetPager.PageSize,ProductID,Common.ContentType.Product,out RecordCount);

            Repeater_Question.DataSource = dt;
            Repeater_Question.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }


        protected void Button_Question_Click(object sender, EventArgs e)
        {
            //验证用户，如果未登录则提示登录
            if (String.IsNullOrEmpty(TextBox_QuestionContent.Text.Trim()))
            {
                MessageBox.Show(this, "输入问题内容");
                return;
            }

            QuestionModel model = new QuestionModel();

            model.QuestionId = CommDataHelper.GetNewSerialNum(AppType.Other);
            model.Content = TextBox_QuestionContent.Text.Trim();
            model.ContentId = ProductID;
            model.ContentType = NoName.NetShop.Common.ContentType.Product;
            model.InsertTime = DateTime.Now;
            //model.LastAnswerId = "";
            //model.LastAnswerTime = "";
            model.Title = "";
            model.UserId = GetUserID();

            questionBll.Add(model);

            BindQuestionData(AspNetPager.CurrentPageIndex);

            Response.Redirect(Request.RawUrl);
        }
        
        private string GetUserID()
        {
            return CurrentUser.UserId;
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindQuestionData(e.NewPageIndex); 
        }
    }
}
