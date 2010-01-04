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
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ�޸�";
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
		this.txtOrderId.Text=model.OrderId.ToString();
		this.lblOrderItem.Text=model.OrderItem.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtProductFee.Text=model.ProductFee.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtDerateFee.Text=model.DerateFee.ToString();
		this.txtMerchantPrice.Text=model.MerchantPrice.ToString();
		this.txtTotalFee.Text=model.TotalFee.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtOrderId.Text))
	{
		strErr+="OrderId�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtProductId.Text))
	{
		strErr+="ProductId�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtProductFee.Text))
	{
		strErr+="ProductFee�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtQuantity.Text))
	{
		strErr+="Quantity�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtDerateFee.Text))
	{
		strErr+="DerateFee�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtMerchantPrice.Text))
	{
		strErr+="MerchantPrice�������֣�\\n";	
	}
	if(!PageValidate.IsDecimal(txtTotalFee.Text))
	{
		strErr+="TotalFee�������֣�\\n";	
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
	bll.Update(model);

		}

    }
}