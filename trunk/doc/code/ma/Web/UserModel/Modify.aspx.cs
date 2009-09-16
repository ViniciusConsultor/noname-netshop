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
					//ShowInfo(UserId);
				}
			}
		}
			
	private void ShowInfo(int UserId)
	{
		NoName.NetShop.BLL.UserModelBll bll=new NoName.NetShop.BLL.UserModelBll();
		NoName.NetShop.Model.UserModel model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtUserEmail.Text=model.UserEmail;
		this.txtPassword.Text=model.Password;
		this.txtLastLoginTime.Text=model.LastLoginTime.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtUserName.Text =="")
	{
		strErr+="UserName不能为空！\\n";	
	}
	if(this.txtUserEmail.Text =="")
	{
		strErr+="UserEmail不能为空！\\n";	
	}
	if(this.txtPassword.Text =="")
	{
		strErr+="Password不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastLoginTime.Text))
	{
		strErr+="LastLoginTime不是时间格式！\\n";	
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
	bll.Update(model);

		}

    }
}
