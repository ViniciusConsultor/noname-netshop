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
namespace NoName.NetShop.Web.VoteItemsModel
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
					//ShowInfo(ItemId);
				}
			}
		}
			
	private void ShowInfo(int ItemId)
	{
		NoName.NetShop.BLL.VoteItemsModelBll bll=new NoName.NetShop.BLL.VoteItemsModelBll();
		NoName.NetShop.Model.VoteItemsModel model=bll.GetModel(ItemId);
		this.txtVoteGroupId.Text=model.VoteGroupId.ToString();
		this.txtVoteId.Text=model.VoteId.ToString();
		this.lblItemId.Text=model.ItemId.ToString();
		this.txtItemContent.Text=model.ItemContent;
		this.txtVoteCount.Text=model.VoteCount.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtVoteGroupId.Text))
	{
		strErr+="VoteGroupId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtVoteId.Text))
	{
		strErr+="VoteId不是数字！\\n";	
	}
	if(this.txtItemContent.Text =="")
	{
		strErr+="ItemContent不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtVoteCount.Text))
	{
		strErr+="VoteCount不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int VoteGroupId=int.Parse(this.txtVoteGroupId.Text);
	int VoteId=int.Parse(this.txtVoteId.Text);
	string ItemContent=this.txtItemContent.Text;
	int VoteCount=int.Parse(this.txtVoteCount.Text);


	NoName.NetShop.Model.VoteItemsModel model=new NoName.NetShop.Model.VoteItemsModel();
	model.VoteGroupId=VoteGroupId;
	model.VoteId=VoteId;
	model.ItemContent=ItemContent;
	model.VoteCount=VoteCount;

	NoName.NetShop.BLL.VoteItemsModelBll bll=new NoName.NetShop.BLL.VoteItemsModelBll();
	bll.Update(model);

		}

    }
}
