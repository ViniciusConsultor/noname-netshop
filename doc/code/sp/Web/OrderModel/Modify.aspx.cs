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
using LTP.Common;
namespace NoName.NetShop.Web.OrderModel
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
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
		this.txtUserId.Text=model.UserId.ToString();
		this.lblOrderId.Text=model.OrderId.ToString();
		this.txtOrderStatus.Text=model.OrderStatus.ToString();
		this.txtPayMethod.Text=model.PayMethod.ToString();
		this.txtShipMethod.Text=model.ShipMethod.ToString();
		this.txtPayStatus.Text=model.PayStatus.ToString();
		this.txtPaysum.Text=model.Paysum.ToString();
		this.txtShipFee.Text=model.ShipFee.ToString();
		this.txtProductFee.Text=model.ProductFee.ToString();
		this.txtDerateFee.Text=model.DerateFee.ToString();
		this.txtAddressId.Text=model.AddressId.ToString();
		this.txtRecieverName.Text=model.RecieverName;
		this.txtRecieverEmail.Text=model.RecieverEmail;
		this.txtRecieverPhone.Text=model.RecieverPhone;
		this.txtPostalcode.Text=model.Postalcode;
		this.txtRecieverCity.Text=model.RecieverCity;
		this.txtRecieverProvince.Text=model.RecieverProvince;
		this.txtAddressDetial.Text=model.AddressDetial;
		this.txtChangeTime.Text=model.ChangeTime.ToString();
		this.txtPayTime.Text=model.PayTime.ToString();
		this.txtCreateTime.Text=model.CreateTime.ToString();
		this.txtOrderType.Text=model.OrderType.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtUserId.Text))
	{
		strErr+="UserId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtOrderStatus.Text))
	{
		strErr+="OrderStatus不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtPayMethod.Text))
	{
		strErr+="PayMethod不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtShipMethod.Text))
	{
		strErr+="ShipMethod不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtPayStatus.Text))
	{
		strErr+="PayStatus不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtPaysum.Text))
	{
		strErr+="Paysum不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtShipFee.Text))
	{
		strErr+="ShipFee不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtProductFee.Text))
	{
		strErr+="ProductFee不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtDerateFee.Text))
	{
		strErr+="DerateFee不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtAddressId.Text))
	{
		strErr+="AddressId不是数字！\\n";	
	}
	if(this.txtRecieverName.Text =="")
	{
		strErr+="RecieverName不能为空！\\n";	
	}
	if(this.txtRecieverEmail.Text =="")
	{
		strErr+="RecieverEmail不能为空！\\n";	
	}
	if(this.txtRecieverPhone.Text =="")
	{
		strErr+="RecieverPhone不能为空！\\n";	
	}
	if(this.txtPostalcode.Text =="")
	{
		strErr+="Postalcode不能为空！\\n";	
	}
	if(this.txtRecieverCity.Text =="")
	{
		strErr+="RecieverCity不能为空！\\n";	
	}
	if(this.txtRecieverProvince.Text =="")
	{
		strErr+="RecieverProvince不能为空！\\n";	
	}
	if(this.txtAddressDetial.Text =="")
	{
		strErr+="AddressDetial不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtChangeTime.Text))
	{
		strErr+="ChangeTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtPayTime.Text))
	{
		strErr+="PayTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCreateTime.Text))
	{
		strErr+="CreateTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtOrderType.Text))
	{
		strErr+="OrderType不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int UserId=int.Parse(this.txtUserId.Text);
	int OrderStatus=int.Parse(this.txtOrderStatus.Text);
	int PayMethod=int.Parse(this.txtPayMethod.Text);
	int ShipMethod=int.Parse(this.txtShipMethod.Text);
	int PayStatus=int.Parse(this.txtPayStatus.Text);
	decimal Paysum=decimal.Parse(this.txtPaysum.Text);
	decimal ShipFee=decimal.Parse(this.txtShipFee.Text);
	decimal ProductFee=decimal.Parse(this.txtProductFee.Text);
	decimal DerateFee=decimal.Parse(this.txtDerateFee.Text);
	int AddressId=int.Parse(this.txtAddressId.Text);
	string RecieverName=this.txtRecieverName.Text;
	string RecieverEmail=this.txtRecieverEmail.Text;
	string RecieverPhone=this.txtRecieverPhone.Text;
	string Postalcode=this.txtPostalcode.Text;
	string RecieverCity=this.txtRecieverCity.Text;
	string RecieverProvince=this.txtRecieverProvince.Text;
	string AddressDetial=this.txtAddressDetial.Text;
	DateTime ChangeTime=DateTime.Parse(this.txtChangeTime.Text);
	DateTime PayTime=DateTime.Parse(this.txtPayTime.Text);
	DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
	int OrderType=int.Parse(this.txtOrderType.Text);


	NoName.NetShop.Model.OrderModel model=new NoName.NetShop.Model.OrderModel();
	model.UserId=UserId;
	model.OrderStatus=OrderStatus;
	model.PayMethod=PayMethod;
	model.ShipMethod=ShipMethod;
	model.PayStatus=PayStatus;
	model.Paysum=Paysum;
	model.ShipFee=ShipFee;
	model.ProductFee=ProductFee;
	model.DerateFee=DerateFee;
	model.AddressId=AddressId;
	model.RecieverName=RecieverName;
	model.RecieverEmail=RecieverEmail;
	model.RecieverPhone=RecieverPhone;
	model.Postalcode=Postalcode;
	model.RecieverCity=RecieverCity;
	model.RecieverProvince=RecieverProvince;
	model.AddressDetial=AddressDetial;
	model.ChangeTime=ChangeTime;
	model.PayTime=PayTime;
	model.CreateTime=CreateTime;
	model.OrderType=OrderType;

	NoName.NetShop.BLL.OrderModelBll bll=new NoName.NetShop.BLL.OrderModelBll();
	bll.Update(model);

		}

    }
}
