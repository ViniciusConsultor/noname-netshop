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
namespace NoName.NetShop.Web.MessageModel
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
		NoName.NetShop.BLL.MessageModelBll bll=new NoName.NetShop.BLL.MessageModelBll();
		NoName.NetShop.Model.MessageModel model=bll.GetModel();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtMsgId.Text=model.MsgId.ToString();
		this.txtMsgType.Text=model.MsgType.ToString();
		this.txtSubject.Text=model.Subject;
		this.txtContent.Text=model.Content;
		this.txtSenderId.Text=model.SenderId.ToString();
		this.txtInsertTime.Text=model.InsertTime.ToString();
		this.txtReadTime.Text=model.ReadTime.ToString();
		this.txtStatus.Text=model.Status.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtUserId.Text))
	{
		strErr+="UserId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtMsgId.Text))
	{
		strErr+="MsgId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtMsgType.Text))
	{
		strErr+="MsgType不是数字！\\n";	
	}
	if(this.txtSubject.Text =="")
	{
		strErr+="Subject不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtSenderId.Text))
	{
		strErr+="SenderId不是数字！\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
		strErr+="InsertTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtReadTime.Text))
	{
		strErr+="ReadTime不是时间格式！\\n";	
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
	int UserId=int.Parse(this.txtUserId.Text);
	int MsgId=int.Parse(this.txtMsgId.Text);
	int MsgType=int.Parse(this.txtMsgType.Text);
	string Subject=this.txtSubject.Text;
	string Content=this.txtContent.Text;
	int SenderId=int.Parse(this.txtSenderId.Text);
	DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
	DateTime ReadTime=DateTime.Parse(this.txtReadTime.Text);
	int Status=int.Parse(this.txtStatus.Text);


	NoName.NetShop.Model.MessageModel model=new NoName.NetShop.Model.MessageModel();
	model.UserId=UserId;
	model.MsgId=MsgId;
	model.MsgType=MsgType;
	model.Subject=Subject;
	model.Content=Content;
	model.SenderId=SenderId;
	model.InsertTime=InsertTime;
	model.ReadTime=ReadTime;
	model.Status=Status;

	NoName.NetShop.BLL.MessageModelBll bll=new NoName.NetShop.BLL.MessageModelBll();
	bll.Update(model);

		}

    }
}
