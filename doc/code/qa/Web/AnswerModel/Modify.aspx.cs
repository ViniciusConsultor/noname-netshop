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
					//ShowInfo(AnswerId);
				}
			}
		}
			
	private void ShowInfo(int AnswerId)
	{
		NoName.NetShop.BLL.AnswerModelBll bll=new NoName.NetShop.BLL.AnswerModelBll();
		NoName.NetShop.Model.AnswerModel model=bll.GetModel(AnswerId);
		this.txtQuestionId.Text=model.QuestionId.ToString();
		this.lblAnswerId.Text=model.AnswerId.ToString();
		this.txtTitle.Text=model.Title;
		this.txtBrief.Text=model.Brief;
		this.txtContent.Text=model.Content;
		this.txtAnswerTime.Text=model.AnswerTime.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtQuestionId.Text))
	{
		strErr+="QuestionId不是数字！\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title不能为空！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtAnswerTime.Text))
	{
		strErr+="AnswerTime不是时间格式！\\n";	
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
	bll.Update(model);

		}

    }
}
