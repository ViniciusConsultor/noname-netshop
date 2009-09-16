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
namespace NoName.NetShop.Web.OrderModel
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
					//ShowInfo(OrderId);
				}
			}
		}
		
	private void ShowInfo(int OrderId)
	{
		NoName.NetShop.BLL.OrderModelBll bll=new NoName.NetShop.BLL.OrderModelBll();
		NoName.NetShop.Model.OrderModel model=bll.GetModel(OrderId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblOrderStatus.Text=model.OrderStatus.ToString();
		this.lblPayMethod.Text=model.PayMethod.ToString();
		this.lblShipMethod.Text=model.ShipMethod.ToString();
		this.lblPayStatus.Text=model.PayStatus.ToString();
		this.lblPaysum.Text=model.Paysum.ToString();
		this.lblShipFee.Text=model.ShipFee.ToString();
		this.lblProductFee.Text=model.ProductFee.ToString();
		this.lblDerateFee.Text=model.DerateFee.ToString();
		this.lblAddressId.Text=model.AddressId.ToString();
		this.lblRecieverName.Text=model.RecieverName;
		this.lblRecieverEmail.Text=model.RecieverEmail;
		this.lblRecieverPhone.Text=model.RecieverPhone;
		this.lblPostalcode.Text=model.Postalcode;
		this.lblRecieverCity.Text=model.RecieverCity;
		this.lblRecieverProvince.Text=model.RecieverProvince;
		this.lblAddressDetial.Text=model.AddressDetial;
		this.lblChangeTime.Text=model.ChangeTime.ToString();
		this.lblPayTime.Text=model.PayTime.ToString();
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblOrderType.Text=model.OrderType.ToString();

	}


    }
}
