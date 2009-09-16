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
namespace NoName.NetShop.Web.AuctionLogModel
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
					ShowInfo();
				}
			}
		}
			
	private void ShowInfo()
	{
		NoName.NetShop.BLL.AuctionLogModelBll bll=new NoName.NetShop.BLL.AuctionLogModelBll();
		NoName.NetShop.Model.AuctionLogModel model=bll.GetModel();
		this.txtAuctionId.Text=model.AuctionId.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtAuctionTime.Text=model.AuctionTime.ToString();
		this.txtAutionPrice.Text=model.AutionPrice.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtAuctionId.Text))
	{
		strErr+="AuctionId不是数字！\\n";	
	}
	if(this.txtUserName.Text =="")
	{
		strErr+="UserName不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtAuctionTime.Text))
	{
		strErr+="AuctionTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDecimal(txtAutionPrice.Text))
	{
		strErr+="AutionPrice不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int AuctionId=int.Parse(this.txtAuctionId.Text);
	string UserName=this.txtUserName.Text;
	DateTime AuctionTime=DateTime.Parse(this.txtAuctionTime.Text);
	decimal AutionPrice=decimal.Parse(this.txtAutionPrice.Text);


	NoName.NetShop.Model.AuctionLogModel model=new NoName.NetShop.Model.AuctionLogModel();
	model.AuctionId=AuctionId;
	model.UserName=UserName;
	model.AuctionTime=AuctionTime;
	model.AutionPrice=AutionPrice;

	NoName.NetShop.BLL.AuctionLogModelBll bll=new NoName.NetShop.BLL.AuctionLogModelBll();
	bll.Update(model);

		}

    }
}
