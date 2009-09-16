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
namespace NoName.NetShop.Web.VoteRemarkModel
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
					//ShowInfo(VoteId,UserId);
				}
			}
		}
			
	private void ShowInfo(int VoteId,int UserId)
	{
		NoName.NetShop.BLL.VoteRemarkModelBll bll=new NoName.NetShop.BLL.VoteRemarkModelBll();
		NoName.NetShop.Model.VoteRemarkModel model=bll.GetModel(VoteId,UserId);
		this.lblVoteId.Text=model.VoteId.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.txtRemark.Text=model.Remark;
		this.txtVoteTime.Text=model.VoteTime.ToString();
		this.txtVoteIP.Text=model.VoteIP;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtVoteTime.Text))
	{
		strErr+="VoteTime不是时间格式！\\n";	
	}
	if(this.txtVoteIP.Text =="")
	{
		strErr+="VoteIP不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string Remark=this.txtRemark.Text;
	DateTime VoteTime=DateTime.Parse(this.txtVoteTime.Text);
	string VoteIP=this.txtVoteIP.Text;


	NoName.NetShop.Model.VoteRemarkModel model=new NoName.NetShop.Model.VoteRemarkModel();
	model.Remark=Remark;
	model.VoteTime=VoteTime;
	model.VoteIP=VoteIP;

	NoName.NetShop.BLL.VoteRemarkModelBll bll=new NoName.NetShop.BLL.VoteRemarkModelBll();
	bll.Update(model);

		}

    }
}
