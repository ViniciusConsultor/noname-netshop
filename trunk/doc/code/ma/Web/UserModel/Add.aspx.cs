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
namespace NoName.NetShop.Web.UserModel
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
	if(this.txtUserName.Text =="")
	{
		strErr+="UserName����Ϊ�գ�\\n";	
	}
	if(this.txtUserEmail.Text =="")
	{
		strErr+="UserEmail����Ϊ�գ�\\n";	
	}
	if(this.txtPassword.Text =="")
	{
		strErr+="Password����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastLoginTime.Text))
	{
	strErr+="LastLoginTime����ʱ���ʽ��\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string UserName=this.txtUserName.Text;
	string UserEmail=this.txtUserEmail.Text;
	string Password=this.txtPassword.Text;
	DateTime LastLoginTime=DateTime.Parse(this.txtLastLoginTime.Text);

	NoName.NetShop.Model.UserModel model=new NoName.NetShop.Model.UserModel();
	model.UserName=UserName;
	model.UserEmail=UserEmail;
	model.Password=Password;
	model.LastLoginTime=LastLoginTime;

	NoName.NetShop.BLL.UserModelBll bll=new NoName.NetShop.BLL.UserModelBll();
	bll.Add(model);

		}

    }
}
