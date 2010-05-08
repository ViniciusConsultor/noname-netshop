using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Comment;

namespace NoName.NetShop.ForeFlat.qa
{
    public partial class ShowQuestion : BasePage
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "qaQuestion";
                    spage.FieldNames = "QuestionId,UserId,ContentType,ContentId,Title,Content,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum";
                    spage.PriKeyName = "QuestionId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere =string.Empty;
                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId;
                if (!int.TryParse(ReqParas["pid"],out productId))
                {
                    throw new ShopException("需要提供商品Id");
                }
                ShowProductInfo(productId);
                SearPageInfo.StrWhere = "contentType=1 and contentid=" + productId;
                ShowQuestionInfo();
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
            this.imgProductL.ImageUrl = pmodel.MediumImage;
            this.imgProductM.ImageUrl = pmodel.LargeImage;
        }

        private void ShowQuestionInfo()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            rpList.DataSource = ds.Tables[0];
            rpList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            ShowQuestionInfo();
        }

        protected void lbtnDoQuestion_Click(object sender, EventArgs e)
        {
            QuestionBll qbll = new QuestionBll();
            QuestionModel qmodel = new QuestionModel();
            qmodel.UserId = Context.User.Identity.Name;
            string content = txtContent.Text.Trim();
            qmodel.Title = content.Substring(0,content.Length>50?50:content.Length);
            qmodel.Content = content;
            qmodel.ContentType = NetShop.Common.ContentType.Product;
            qmodel.ContentId = int.Parse(litProductId.Text);
            qbll.Add(qmodel);
            ShowQuestionInfo();
        }

        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView row = e.Item.DataItem as DataRowView;
            Repeater rpSubList = e.Item.FindControl("rpSubList") as Repeater;
            AnswerBll abll = new AnswerBll();

            rpSubList.DataSource = abll.GetModelOfQuestion(Convert.ToInt32(row["QuestionId"]));
            rpSubList.DataBind();
        }

    }
}
