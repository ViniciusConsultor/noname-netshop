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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
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
	bll.Add(model);

		}

    }
}
