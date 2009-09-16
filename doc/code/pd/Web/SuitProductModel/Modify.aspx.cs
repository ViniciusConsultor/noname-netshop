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
namespace NoName.NetShop.Web.SuitProductModel
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
					//ShowInfo(SuitProductId);
				}
			}
		}
			
	private void ShowInfo(int SuitProductId)
	{
		NoName.NetShop.BLL.SuitProductModelBll bll=new NoName.NetShop.BLL.SuitProductModelBll();
		NoName.NetShop.Model.SuitProductModel model=bll.GetModel(SuitProductId);
		this.lblSuitProductId.Text=model.SuitProductId.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtSuitName.Text=model.SuitName;
		this.txtMerchantPrice.Text=model.MerchantPrice.ToString();
		this.txtTradePrice.Text=model.TradePrice.ToString();
		this.txtStatus.Text=model.Status.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtProductId.Text))
	{
		strErr+="ProductId不是数字！\\n";	
	}
	if(this.txtSuitName.Text =="")
	{
		strErr+="SuitName不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtMerchantPrice.Text))
	{
		strErr+="MerchantPrice不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTradePrice.Text))
	{
		strErr+="TradePrice不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int ProductId=int.Parse(this.txtProductId.Text);
	string SuitName=this.txtSuitName.Text;
	decimal MerchantPrice=decimal.Parse(this.txtMerchantPrice.Text);
	decimal TradePrice=decimal.Parse(this.txtTradePrice.Text);
	int Status=int.Parse(this.txtStatus.Text);


	NoName.NetShop.Model.SuitProductModel model=new NoName.NetShop.Model.SuitProductModel();
	model.ProductId=ProductId;
	model.SuitName=SuitName;
	model.MerchantPrice=MerchantPrice;
	model.TradePrice=TradePrice;
	model.Status=Status;

	NoName.NetShop.BLL.SuitProductModelBll bll=new NoName.NetShop.BLL.SuitProductModelBll();
	bll.Update(model);

		}

    }
}
