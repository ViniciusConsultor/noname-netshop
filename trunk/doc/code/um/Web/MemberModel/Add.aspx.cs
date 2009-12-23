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
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ����";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtUserEmail.Text =="")
	{
		strErr+="UserEmail����Ϊ�գ�\\n";	
	}
	if(this.txtPassword.Text =="")
	{
		strErr+="Password����Ϊ�գ�\\n";	
	}
	if(this.txtNickName.Text =="")
	{
		strErr+="NickName����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsNumber(txtAllScore.Text))
	{
		strErr+="AllScore�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtCurScore.Text))
	{
		strErr+="CurScore�������֣�\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastLogin.Text))
	{
	strErr+="LastLogin����ʱ���ʽ��\\n";	
	}
	if(this.txtLoginIP.Text =="")
	{
		strErr+="LoginIP����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtRegisterTime.Text))
	{
	strErr+="RegisterTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsDateTime(txtModifyTime.Text))
	{
	strErr+="ModifyTime����ʱ���ʽ��\\n";	
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