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
namespace NoName.NetShop.Web.ActionProductModel
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
	if(this.txtSmallIamge.Text =="")
	{
		strErr+="SmallIamge不能为空！\\n";	
	}
	if(this.txtMediumImage.Text =="")
	{
		strErr+="MediumImage不能为空！\\n";	
	}
	if(this.txtOutLinkUrl.Text =="")
	{
		strErr+="OutLinkUrl不能为空！\\n";	
	}
	if(!PageValidate.IsDecimal(txtStartPrice.Text))
	{
		strErr+="StartPrice不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtAddPrices.Text))
	{
		strErr+="AddPrices不是数字！\\n";	
	}
	if(!PageValidate.IsDecimal(txtCurPrice.Text))
	{
		strErr+="CurPrice不是数字！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtStartTime.Text))
	{
	strErr+="StartTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtEndTime.Text))
	{
	strErr+="EndTime不是时间格式！\\n";	
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
	string ProductName=this.txtProductName.Text;
	string SmallIamge=this.txtSmallIamge.Text;
	string MediumImage=this.txtMediumImage.Text;
	string OutLinkUrl=this.txtOutLinkUrl.Text;
	decimal StartPrice=decimal.Parse(this.txtStartPrice.Text);
	decimal AddPrices=decimal.Parse(this.txtAddPrices.Text);
	decimal CurPrice=decimal.Parse(this.txtCurPrice.Text);
	string Brief=this.txtBrief.Text;
	DateTime StartTime=DateTime.Parse(this.txtStartTime.Text);
	DateTime EndTime=DateTime.Parse(this.txtEndTime.Text);
	int Status=int.Parse(this.txtStatus.Text);

	NoName.NetShop.Model.ActionProductModel model=new NoName.NetShop.Model.ActionProductModel();
	model.ProductName=ProductName;
	model.SmallIamge=SmallIamge;
	model.MediumImage=MediumImage;
	model.OutLinkUrl=OutLinkUrl;
	model.StartPrice=StartPrice;
	model.AddPrices=AddPrices;
	model.CurPrice=CurPrice;
	model.Brief=Brief;
	model.StartTime=StartTime;
	model.EndTime=EndTime;
	model.Status=Status;

	NoName.NetShop.BLL.ActionProductModelBll bll=new NoName.NetShop.BLL.ActionProductModelBll();
	bll.Add(model);

		}

    }
}
