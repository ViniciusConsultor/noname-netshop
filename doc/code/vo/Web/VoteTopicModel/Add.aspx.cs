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
	if(!PageValidate.IsNumber(txtContentId.Text))
	{
		strErr+="ContentId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtContentType.Text))
	{
		strErr+="ContentType不是数字！\\n";	
	}
	if(this.txtTopic.Text =="")
	{
		strErr+="Topic不能为空！\\n";	
	}
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtStartTime.Text))
	{
	strErr+="StartTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtEndTime.Text))
	{
	strErr+="EndTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtVoteUserNum.Text))
	{
		strErr+="VoteUserNum不是数字！\\n";	
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
	bll.Add(model);

		}

    }
}
