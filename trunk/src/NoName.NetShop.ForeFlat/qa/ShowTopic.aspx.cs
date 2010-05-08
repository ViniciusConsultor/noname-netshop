using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Comment;

namespace NoName.NetShop.ForeFlat.qa
{
    public partial class ShowTopic : BasePage
    {

        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "qaTopic";
                    spage.FieldNames = "TopicId,UserId,ContentType,ContentId,Title,Content,InsertTime,LastReplyTime,LastReplyId,ReplyNum,Status";
                    spage.PriKeyName = "TopicId";
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
                int productId;
                if (!int.TryParse(ReqParas["pid"], out productId))
                {
                    throw new ShopException("需要提供商品Id");
                }
                ShowProductInfo(productId);
                SearPageInfo.StrWhere = "status=1 and contentType=1 and contentid=" + productId;
                ShowTopicInfo();
            }
        }

        protected void btnDoQuestion_Click(object sender, EventArgs e)
        {
            TopicBll tbll = new TopicBll();
            TopicModel tmodel = new TopicModel();

            tmodel.UserId = Context.User.Identity.Name;
            tmodel.Title = txtTile.Text.Trim();
            tmodel.Content = txtContent.Text.Trim(); ;
            tmodel.ContentType = NetShop.Common.ContentType.Product;
            tmodel.ContentId = int.Parse(litProductId.Text);
            tbll.Add(tmodel);
            ShowTopicInfo();
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
            this.imgProductL.ImageUrl = pmodel.MediumImage;
            this.imgProductM.ImageUrl = pmodel.LargeImage;
        }

        private void ShowTopicInfo()
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
            ShowTopicInfo();
        }


    }
}
