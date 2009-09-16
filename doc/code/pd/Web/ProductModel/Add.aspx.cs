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
namespace NoName.NetShop.Web.ProductModel
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
	if(this.txtProductName.Text =="")
	{
		strErr+="ProductName不能为空！\\n";	
	}
	if(this.txtProductCode.Text =="")
	{
		strErr+="ProductCode不能为空！\\n";	
	}
	if(this.txtCatePath.Text =="")
	{
		strErr+="CatePath不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtCateId.Text))
	{
		strErr+="CateId不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtTradePrice.Text))
	{
		strErr+="TradePrice不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtMerchantPrice.Text))
	{
		strErr+="MerchantPrice不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtReducePrice.Text))
	{
		strErr+="ReducePrice不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtStock.Text))
	{
		strErr+="Stock不是数字！\\n";	
	}
	if(this.txtSmallImage.Text =="")
	{
		strErr+="SmallImage不能为空！\\n";	
	}
	if(this.txtMediumImage.Text =="")
	{
		strErr+="MediumImage不能为空！\\n";	
	}
	if(this.txtLargeImage.Text =="")
	{
		strErr+="LargeImage不能为空！\\n";	
	}
	if(this.txtKeywords.Text =="")
	{
		strErr+="Keywords不能为空！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtPageView.Text))
	{
		strErr+="PageView不是数字！\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
	strErr+="InsertTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtChangeTime.Text))
	{
	strErr+="ChangeTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtSortValue.Text))
	{
		strErr+="SortValue不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtScore.Text))
	{
		strErr+="Score不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ProductName=this.txtProductName.Text;
	string ProductCode=this.txtProductCode.Text;
	string CatePath=this.txtCatePath.Text;
	int CateId=int.Parse(this.txtCateId.Text);
	decimal TradePrice=decimal.Parse(this.txtTradePrice.Text);
	decimal MerchantPrice=decimal.Parse(this.txtMerchantPrice.Text);
	decimal ReducePrice=decimal.Parse(this.txtReducePrice.Text);
	int Stock=int.Parse(this.txtStock.Text);
	string SmallImage=this.txtSmallImage.Text;
	string MediumImage=this.txtMediumImage.Text;
	string LargeImage=this.txtLargeImage.Text;
	string Keywords=this.txtKeywords.Text;
	string Brief=this.txtBrief.Text;
	int PageView=int.Parse(this.txtPageView.Text);
	DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
	DateTime ChangeTime=DateTime.Parse(this.txtChangeTime.Text);
	int Status=int.Parse(this.txtStatus.Text);
	int SortValue=int.Parse(this.txtSortValue.Text);
	int Score=int.Parse(this.txtScore.Text);

	NoName.NetShop.Model.ProductModel model=new NoName.NetShop.Model.ProductModel();
	model.ProductName=ProductName;
	model.ProductCode=ProductCode;
	model.CatePath=CatePath;
	model.CateId=CateId;
	model.TradePrice=TradePrice;
	model.MerchantPrice=MerchantPrice;
	model.ReducePrice=ReducePrice;
	model.Stock=Stock;
	model.SmallImage=SmallImage;
	model.MediumImage=MediumImage;
	model.LargeImage=LargeImage;
	model.Keywords=Keywords;
	model.Brief=Brief;
	model.PageView=PageView;
	model.InsertTime=InsertTime;
	model.ChangeTime=ChangeTime;
	model.Status=Status;
	model.SortValue=SortValue;
	model.Score=Score;

	NoName.NetShop.BLL.ProductModelBll bll=new NoName.NetShop.BLL.ProductModelBll();
	bll.Add(model);

		}

    }
}
