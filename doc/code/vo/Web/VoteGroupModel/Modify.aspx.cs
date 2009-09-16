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
namespace NoName.NetShop.Web.VoteGroupModel
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
					//ShowInfo(VoteGroupId);
				}
			}
		}
			
	private void ShowInfo(int VoteGroupId)
	{
		NoName.NetShop.BLL.VoteGroupModelBll bll=new NoName.NetShop.BLL.VoteGroupModelBll();
		NoName.NetShop.Model.VoteGroupModel model=bll.GetModel(VoteGroupId);
		this.lblVoteGroupId.Text=model.VoteGroupId.ToString();
		this.txtVoteId.Text=model.VoteId.ToString();
		this.txtGroupType.Text=model.GroupType.ToString();
		this.txtSubject.Text=model.Subject;
		this.txtContent.Text=model.Content;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtVoteId.Text))
	{
		strErr+="VoteId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtGroupType.Text))
	{
		strErr+="GroupType不是数字！\\n";	
	}
	if(this.txtSubject.Text =="")
	{
		strErr+="Subject不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int VoteId=int.Parse(this.txtVoteId.Text);
	int GroupType=int.Parse(this.txtGroupType.Text);
	string Subject=this.txtSubject.Text;
	string Content=this.txtContent.Text;


	NoName.NetShop.Model.VoteGroupModel model=new NoName.NetShop.Model.VoteGroupModel();
	model.VoteId=VoteId;
	model.GroupType=GroupType;
	model.Subject=Subject;
	model.Content=Content;

	NoName.NetShop.BLL.VoteGroupModelBll bll=new NoName.NetShop.BLL.VoteGroupModelBll();
	bll.Update(model);

		}

    }
}
