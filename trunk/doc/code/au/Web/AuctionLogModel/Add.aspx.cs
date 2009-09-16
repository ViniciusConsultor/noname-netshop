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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ���";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtAuctionId.Text))
	{
		strErr+="AuctionId�������֣�\\n";	
	}
	if(this.txtUserName.Text =="")
	{
		strErr+="UserName����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtAuctionTime.Text))
	{
	strErr+="AuctionTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsDecimal(txtAutionPrice.Text))
	{
		strErr+="AutionPrice�������֣�\\n";	
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
	bll.Add(model);

		}

    }
}
