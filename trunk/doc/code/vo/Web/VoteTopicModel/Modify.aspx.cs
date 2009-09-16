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
namespace NoName.NetShop.Web.VoteTopicModel
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
					//ShowInfo(VoteId);
				}
			}
		}
			
	private void ShowInfo(int VoteId)
	{
		NoName.NetShop.BLL.VoteTopicModelBll bll=new NoName.NetShop.BLL.VoteTopicModelBll();
		NoName.NetShop.Model.VoteTopicModel model=bll.GetModel(VoteId);
		this.lblVoteId.Text=model.VoteId.ToString();
		this.txtContentId.Text=model.ContentId.ToString();
		this.txtContentType.Text=model.ContentType.ToString();
		this.txtTopic.Text=model.Topic;
		this.txtRemark.Text=model.Remark;
		this.txtStartTime.Text=model.StartTime.ToString();
		this.txtEndTime.Text=model.EndTime.ToString();
		this.chkIsRegUser.Checked=model.IsRegUser;
		this.txtVoteUserNum.Text=model.VoteUserNum.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtContentId.Text))
	{
		strErr+="ContentId�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtContentType.Text))
	{
		strErr+="ContentType�������֣�\\n";	
	}
	if(this.txtTopic.Text =="")
	{
		strErr+="Topic����Ϊ�գ�\\n";	
	}
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtStartTime.Text))
	{
		strErr+="StartTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsDateTime(txtEndTime.Text))
	{
		strErr+="EndTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsNumber(txtVoteUserNum.Text))
	{
		strErr+="VoteUserNum�������֣�\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int ContentId=int.Parse(this.txtContentId.Text);
	int ContentType=int.Parse(this.txtContentType.Text);
	string Topic=this.txtTopic.Text;
	string Remark=this.txtRemark.Text;
	DateTime StartTime=DateTime.Parse(this.txtStartTime.Text);
	DateTime EndTime=DateTime.Parse(this.txtEndTime.Text);
	bool IsRegUser=this.chkIsRegUser.Checked;
	int VoteUserNum=int.Parse(this.txtVoteUserNum.Text);


	NoName.NetShop.Model.VoteTopicModel model=new NoName.NetShop.Model.VoteTopicModel();
	model.ContentId=ContentId;
	model.ContentType=ContentType;
	model.Topic=Topic;
	model.Remark=Remark;
	model.StartTime=StartTime;
	model.EndTime=EndTime;
	model.IsRegUser=IsRegUser;
	model.VoteUserNum=VoteUserNum;

	NoName.NetShop.BLL.VoteTopicModelBll bll=new NoName.NetShop.BLL.VoteTopicModelBll();
	bll.Update(model);

		}

    }
}
