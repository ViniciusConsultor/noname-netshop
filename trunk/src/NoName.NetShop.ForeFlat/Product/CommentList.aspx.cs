using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Comment;
using NoName.NetShop.Product.Model;
using NoName.Utility;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Facade;


namespace NoName.NetShop.ForeFlat.Product
{
    public partial class CommentList : AuthBasePage
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return -1; }
            set { ViewState["ProductID"] = value; }
        }
        private ProductModelBll productBll = new ProductModelBll();
        private CommentBll commentBll = new CommentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //验证用户，如果未登录则提示登录
                if (CurrentUser == null || !CurrentUser.IsAuthenticated)
                {
                    Response.Redirect("/Login.aspx?returnurl=" + Request.RawUrl);
                    return;
                }

                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                else throw new ArgumentNullException();

                BindProductData();
                BindCommentData(1);
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

        private void BindCommentData(int PageIndex)
        {
            DataTable dt = commentBll.GetList(AppType.Product, ProductID);

            Literal_CommentCount.Text = dt.Rows.Count.ToString();

            Repeater_Comments.DataSource = dt;
            Repeater_Comments.DataBind();
        }

        protected void Button_Comment_Click(object sender, EventArgs e)
        {
            //验证用户，如果未登录则提示登录
            if (String.IsNullOrEmpty(TextBox_CommentContent.Text))
            {
                MessageBox.Show(this,"请输入评论内容");
                return;
            }

            CommentModel model = new CommentModel();

            model.AppType = AppType.Product;
            model.CommentID = CommDataHelper.GetNewSerialNum(AppType.Product);
            model.Content = TextBox_CommentContent.Text;
            model.CreateTime = DateTime.Now;
            model.TargetID = ProductID;
            model.UserID = GetUserID();

            BindCommentData(AspNetPager.CurrentPageIndex);

            commentBll.Add(model);

            Response.Redirect(Request.RawUrl);
        }

        private string GetUserID()
        {
            return CurrentUser.UserId;
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindCommentData(e.NewPageIndex); 
        }
    }
}
