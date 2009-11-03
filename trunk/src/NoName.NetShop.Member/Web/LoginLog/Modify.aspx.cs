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

namespace NoName.NetShop.UserManager.Web.LoginLog
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(UserId);
				}
			}
		}
			
	private void ShowInfo(int UserId)
	{
		NoName.NetShop.UserManager.BLL.LoginLog bll=new NoName.NetShop.UserManager.BLL.LoginLog();
		NoName.NetShop.UserManager.Model.LoginLog model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.txtLoginTime.Text=model.LoginTime.ToString();
		this.txtIP.Text=model.IP;

	}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtLoginTime.Text))
			{
				strErr+="LoginTime不是时间格式！\\n";	
			}
			if(this.txtIP.Text =="")
			{
				strErr+="IP不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			DateTime LoginTime=DateTime.Parse(this.txtLoginTime.Text);
			string IP=this.txtIP.Text;


			NoName.NetShop.UserManager.Model.LoginLog model=new NoName.NetShop.UserManager.Model.LoginLog();
			model.LoginTime=LoginTime;
			model.IP=IP;

			NoName.NetShop.UserManager.BLL.LoginLog bll=new NoName.NetShop.UserManager.BLL.LoginLog();
			bll.Update(model);

		}

    }
}
