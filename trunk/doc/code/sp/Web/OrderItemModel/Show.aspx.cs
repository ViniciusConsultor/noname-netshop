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
namespace NoName.NetShop.Web.OrderItemModel
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
					//ShowInfo(OrderItem);
				}
			}
		}
		
	private void ShowInfo(int OrderItem)
	{
		NoName.NetShop.BLL.OrderItemModelBll bll=new NoName.NetShop.BLL.OrderItemModelBll();
		NoName.NetShop.Model.OrderItemModel model=bll.GetModel(OrderItem);
		this.lblOrderId.Text=model.OrderId.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblProductFee.Text=model.ProductFee.ToString();
		this.lblQuantity.Text=model.Quantity.ToString();
		this.lblDerateFee.Text=model.DerateFee.ToString();
		this.lblMerchantPrice.Text=model.MerchantPrice.ToString();
		this.lblTotalFee.Text=model.TotalFee.ToString();

	}


    }
}
