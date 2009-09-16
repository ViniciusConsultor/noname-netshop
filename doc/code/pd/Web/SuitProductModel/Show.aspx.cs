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
namespace NoName.NetShop.Web.SuitProductModel
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
					//ShowInfo(SuitProductId);
				}
			}
		}
		
	private void ShowInfo(int SuitProductId)
	{
		NoName.NetShop.BLL.SuitProductModelBll bll=new NoName.NetShop.BLL.SuitProductModelBll();
		NoName.NetShop.Model.SuitProductModel model=bll.GetModel(SuitProductId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblSuitName.Text=model.SuitName;
		this.lblMerchantPrice.Text=model.MerchantPrice.ToString();
		this.lblTradePrice.Text=model.TradePrice.ToString();
		this.lblStatus.Text=model.Status.ToString();

	}


    }
}
