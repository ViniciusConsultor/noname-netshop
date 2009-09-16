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
namespace NoName.NetShop.Web.OrderItemModel
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
	if(!PageValidate.IsNumber(txtOrderId.Text))
	{
		strErr+="OrderId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtProductId.Text))
	{
		strErr+="ProductId不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtProductFee.Text))
	{
		strErr+="ProductFee不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtQuantity.Text))
	{
		strErr+="Quantity不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtDerateFee.Text))
	{
		strErr+="DerateFee不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtMerchantPrice.Text))
	{
		strErr+="MerchantPrice不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTotalFee.Text))
	{
		strErr+="TotalFee不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int OrderId=int.Parse(this.txtOrderId.Text);
	int ProductId=int.Parse(this.txtProductId.Text);
	decimal ProductFee=decimal.Parse(this.txtProductFee.Text);
	int Quantity=int.Parse(this.txtQuantity.Text);
	decimal DerateFee=decimal.Parse(this.txtDerateFee.Text);
	decimal MerchantPrice=decimal.Parse(this.txtMerchantPrice.Text);
	decimal TotalFee=decimal.Parse(this.txtTotalFee.Text);

	NoName.NetShop.Model.OrderItemModel model=new NoName.NetShop.Model.OrderItemModel();
	model.OrderId=OrderId;
	model.ProductId=ProductId;
	model.ProductFee=ProductFee;
	model.Quantity=Quantity;
	model.DerateFee=DerateFee;
	model.MerchantPrice=MerchantPrice;
	model.TotalFee=TotalFee;

	NoName.NetShop.BLL.OrderItemModelBll bll=new NoName.NetShop.BLL.OrderItemModelBll();
	bll.Add(model);

		}

    }
}
