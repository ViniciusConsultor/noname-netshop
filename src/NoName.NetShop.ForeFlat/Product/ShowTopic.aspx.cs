using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Comment;
using NoName.Utility;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.ForeFlat.Product
{
    public partial class ShowTopic : AuthBasePage
    {

        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "qareply";
                    spage.FieldNames = "replyid,topicid,title,content,replytime,userid";
                    spage.PriKeyName = "replyid";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = String.Empty;

                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int topicId;
                if (!int.TryParse(ReqParas["topicid"], out topicId))
                {
                    throw new ShopException("需要提供话题Id");
                }
                SearPageInfo.StrWhere = "topicid=" + topicId;

                ShowTopicInfo(topicId);
                ShowReplyInfo();
           }
        }

        protected void btnDoQuestion_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null || !CurrentUser.IsAuthenticated)
            {
                Response.Redirect("/Login.aspx?returnurl=" + Request.RawUrl);
                return;
            }
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(txtTile.Text.Trim())) ErrorMessage += "标题不能为空；";
            if (String.IsNullOrEmpty(txtContent.Text.Trim())) ErrorMessage += "内容不能为空";
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }


            ReplyBll rbll = new ReplyBll();
            ReplyModel rmodel = new ReplyModel();

            rmodel.TopicId = int.Parse(hidTopicId.Value);
            rmodel.Content = txtContent.Text.Trim();
            rmodel.Title = txtTile.Text.Trim();
            rmodel.UserId = CurrentUser.UserId;
            rbll.Add(rmodel);
            txtContent.Text = "";
            txtTile.Text = "";
            ShowReplyInfo();
        }
        private void ShowTopicInfo(int topicId)
        {
            TopicBll tbll = new TopicBll();
            TopicModel tmodel = tbll.GetModel(topicId);
            if (tmodel != null)
            {
                litTitle.Text = String.Format("话题：{0} by （{1}） <span>{2:yyyy-MM-dd HH:mm}</span>",tmodel.Title,tmodel.UserId,tmodel.InsertTime);
                hidTopicId.Value = tmodel.TopicId.ToString();
                ShowProductInfo(tmodel.ContentId);
            }
            else
            {
                throw new ShopException("话题不存在", true);
            }
        }
        private void ShowProductInfo(int productId)
        {
            NetShop.Product.BLL.ProductModelBll pbll = new NoName.NetShop.Product.BLL.ProductModelBll();
            NetShop.Product.Model.ProductModel pmodel = pbll.GetModel(productId);
            this.litProductName.Text = pmodel.ProductName;
            this.litTopProductName.Text = pmodel.ProductName;
            this.litMerchantPrice.Text = pmodel.MerchantPrice.ToString("F2");
            this.litTradePrice.Text = pmodel.TradePrice.ToString("F2");
            this.litProductId.Text = pmodel.ProductId.ToString();
            this.litStock.Text = pmodel.Stock > 0 ? "库存充足" : "暂时缺货";
            this.imgProductL.ImageUrl = ProductMainImageRule.GetMainImageUrl(pmodel.MediumImage);
            this.imgProductM.ImageUrl = ProductMainImageRule.GetMainImageUrl(pmodel.LargeImage);
        }

        private void ShowReplyInfo()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            gvList.DataSource = ds.Tables[0];
            gvList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            ShowReplyInfo();
        }


    }
}
