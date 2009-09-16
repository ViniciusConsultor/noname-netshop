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
namespace NoName.NetShop.Web.AnswerModel
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
	if(!PageValidate.IsNumber(txtQuestionId.Text))
	{
		strErr+="QuestionId�������֣�\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title����Ϊ�գ�\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief����Ϊ�գ�\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtAnswerTime.Text))
	{
	strErr+="AnswerTime����ʱ���ʽ��\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int QuestionId=int.Parse(this.txtQuestionId.Text);
	string Title=this.txtTitle.Text;
	string Brief=this.txtBrief.Text;
	string Content=this.txtContent.Text;
	DateTime AnswerTime=DateTime.Parse(this.txtAnswerTime.Text);

	NoName.NetShop.Model.AnswerModel model=new NoName.NetShop.Model.AnswerModel();
	model.QuestionId=QuestionId;
	model.Title=Title;
	model.Brief=Brief;
	model.Content=Content;
	model.AnswerTime=AnswerTime;

	NoName.NetShop.BLL.AnswerModelBll bll=new NoName.NetShop.BLL.AnswerModelBll();
	bll.Add(model);

		}

    }
}
