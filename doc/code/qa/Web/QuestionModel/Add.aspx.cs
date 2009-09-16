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
namespace NoName.NetShop.Web.QuestionModel
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
	if(!PageValidate.IsNumber(txtUserId.Text))
	{
		strErr+="UserId不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtContentType.Text))
	{
		strErr+="ContentType不是数字！\\n";	
	}
	if(this.txtContentId.Text =="")
	{
		strErr+="ContentId不能为空！\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
	strErr+="InsertTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastAnswerTime.Text))
	{
	strErr+="LastAnswerTime不是时间格式！\\n";	
	}
	if(this.txtLastAnswerId.Text =="")
	{
		strErr+="LastAnswerId不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtAnswerNum.Text))
	{
		strErr+="AnswerNum不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int UserId=int.Parse(this.txtUserId.Text);
	int ContentType=int.Parse(this.txtContentType.Text);
	string ContentId=this.txtContentId.Text;
	string Title=this.txtTitle.Text;
	string Content=this.txtContent.Text;
	string Brief=this.txtBrief.Text;
	DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
	DateTime LastAnswerTime=DateTime.Parse(this.txtLastAnswerTime.Text);
	string LastAnswerId=this.txtLastAnswerId.Text;
	int AnswerNum=int.Parse(this.txtAnswerNum.Text);

	NoName.NetShop.Model.QuestionModel model=new NoName.NetShop.Model.QuestionModel();
	model.UserId=UserId;
	model.ContentType=ContentType;
	model.ContentId=ContentId;
	model.Title=Title;
	model.Content=Content;
	model.Brief=Brief;
	model.InsertTime=InsertTime;
	model.LastAnswerTime=LastAnswerTime;
	model.LastAnswerId=LastAnswerId;
	model.AnswerNum=AnswerNum;

	NoName.NetShop.BLL.QuestionModelBll bll=new NoName.NetShop.BLL.QuestionModelBll();
	bll.Add(model);

		}

    }
}
