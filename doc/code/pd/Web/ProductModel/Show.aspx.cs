using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace NoName.NetShop.Web.ProductModel
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(ProductId);
				}
			}
		}
		
	private void ShowInfo(int ProductId)
	{
		NoName.NetShop.BLL.ProductModelBll bll=new NoName.NetShop.BLL.ProductModelBll();
		NoName.NetShop.Model.ProductModel model=bll.GetModel(ProductId);
		this.lblProductName.Text=model.ProductName;
		this.lblProductCode.Text=model.ProductCode;
		this.lblCatePath.Text=model.CatePath;
		this.lblCateId.Text=model.CateId.ToString();
		this.lblTradePrice.Text=model.TradePrice.ToString();
		this.lblMerchantPrice.Text=model.MerchantPrice.ToString();
		this.lblReducePrice.Text=model.ReducePrice.ToString();
		this.lblStock.Text=model.Stock.ToString();
		this.lblSmallImage.Text=model.SmallImage;
		this.lblMediumImage.Text=model.MediumImage;
		this.lblLargeImage.Text=model.LargeImage;
		this.lblKeywords.Text=model.Keywords;
		this.lblBrief.Text=model.Brief;
		this.lblPageView.Text=model.PageView.ToString();
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblChangeTime.Text=model.ChangeTime.ToString();
		this.lblStatus.Text=model.Status.ToString();
		this.lblSortValue.Text=model.SortValue.ToString();
		this.lblScore.Text=model.Score.ToString();

	}


    }
}
