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
namespace NoName.NetShop.Web.MemberModel
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
	if(this.txtUserEmail.Text =="")
	{
		strErr+="UserEmail不能为空！\\n";	
	}
	if(this.txtPassword.Text =="")
	{
		strErr+="Password不能为空！\\n";	
	}
	if(this.txtNickName.Text =="")
	{
		strErr+="NickName不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtAllScore.Text))
	{
		strErr+="AllScore不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtCurScore.Text))
	{
		strErr+="CurScore不是数字！\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastLogin.Text))
	{
	strErr+="LastLogin不是时间格式！\\n";	
	}
	if(this.txtLoginIP.Text =="")
	{
		strErr+="LoginIP不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtRegisterTime.Text))
	{
	strErr+="RegisterTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtModifyTime.Text))
	{
	strErr+="ModifyTime不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string UserEmail=this.txtUserEmail.Text;
	string Password=this.txtPassword.Text;
	string NickName=this.txtNickName.Text;
	int AllScore=int.Parse(this.txtAllScore.Text);
	int CurScore=int.Parse(this.txtCurScore.Text);
	DateTime LastLogin=DateTime.Parse(this.txtLastLogin.Text);
	string LoginIP=this.txtLoginIP.Text;
	DateTime RegisterTime=DateTime.Parse(this.txtRegisterTime.Text);
	DateTime ModifyTime=DateTime.Parse(this.txtModifyTime.Text);

	NoName.NetShop.Model.MemberModel model=new NoName.NetShop.Model.MemberModel();
	model.UserEmail=UserEmail;
	model.Password=Password;
	model.NickName=NickName;
	model.AllScore=AllScore;
	model.CurScore=CurScore;
	model.LastLogin=LastLogin;
	model.LoginIP=LoginIP;
	model.RegisterTime=RegisterTime;
	model.ModifyTime=ModifyTime;

	NoName.NetShop.BLL.MemberModelBll bll=new NoName.NetShop.BLL.MemberModelBll();
	bll.Add(model);

		}

    }
}
