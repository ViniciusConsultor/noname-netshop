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

namespace NoName.NetShop.UserManager.Web.Member
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TabTitle="信息添加，请详细填写下列信息";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserId.Text))
			{
				strErr+="userId不是数字！\\n";	
			}
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
			if(!PageValidate.IsNumber(txtUserType.Text))
			{
				strErr+="UserType不是数字！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="status不是数字！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userId=int.Parse(this.txtuserId.Text);
			string UserEmail=this.txtUserEmail.Text;
			string Password=this.txtPassword.Text;
			string NickName=this.txtNickName.Text;
			int AllScore=int.Parse(this.txtAllScore.Text);
			int CurScore=int.Parse(this.txtCurScore.Text);
			DateTime LastLogin=DateTime.Parse(this.txtLastLogin.Text);
			string LoginIP=this.txtLoginIP.Text;
			DateTime RegisterTime=DateTime.Parse(this.txtRegisterTime.Text);
			DateTime ModifyTime=DateTime.Parse(this.txtModifyTime.Text);
			int UserType=int.Parse(this.txtUserType.Text);
			int status=int.Parse(this.txtstatus.Text);

			NoName.NetShop.UserManager.Model.Member model=new NoName.NetShop.UserManager.Model.Member();
			model.userId=userId;
			model.UserEmail=UserEmail;
			model.Password=Password;
			model.NickName=NickName;
			model.AllScore=AllScore;
			model.CurScore=CurScore;
			model.LastLogin=LastLogin;
			model.LoginIP=LoginIP;
			model.RegisterTime=RegisterTime;
			model.ModifyTime=ModifyTime;
			model.UserType=UserType;
			model.status=status;

			NoName.NetShop.UserManager.BLL.Member bll=new NoName.NetShop.UserManager.BLL.Member();
			bll.Add(model);

		}

    }
}
