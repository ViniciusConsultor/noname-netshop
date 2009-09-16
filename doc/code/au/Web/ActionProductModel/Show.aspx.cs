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
namespace NoName.NetShop.Web.ActionProductModel
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
					//ShowInfo(AuctionId);
				}
			}
		}
		
	private void ShowInfo(int AuctionId)
	{
		NoName.NetShop.BLL.ActionProductModelBll bll=new NoName.NetShop.BLL.ActionProductModelBll();
		NoName.NetShop.Model.ActionProductModel model=bll.GetModel(AuctionId);
		this.lblProductName.Text=model.ProductName;
		this.lblSmallIamge.Text=model.SmallIamge;
		this.lblMediumImage.Text=model.MediumImage;
		this.lblOutLinkUrl.Text=model.OutLinkUrl;
		this.lblStartPrice.Text=model.StartPrice.ToString();
		this.lblAddPrices.Text=model.AddPrices.ToString();
		this.lblCurPrice.Text=model.CurPrice.ToString();
		this.lblBrief.Text=model.Brief;
		this.lblStartTime.Text=model.StartTime.ToString();
		this.lblEndTime.Text=model.EndTime.ToString();
		this.lblStatus.Text=model.Status.ToString();

	}


    }
}
