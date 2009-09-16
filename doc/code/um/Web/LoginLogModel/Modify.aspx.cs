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
namespace NoName.NetShop.Web.LoginLogModel
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
		NoName.NetShop.BLL.LoginLogModelBll bll=new NoName.NetShop.BLL.LoginLogModelBll();
		NoName.NetShop.Model.LoginLogModel model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.txtLoginTime.Text=model.LoginTime.ToString();
		this.txtIP.Text=model.IP;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
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


	NoName.NetShop.Model.LoginLogModel model=new NoName.NetShop.Model.LoginLogModel();
	model.LoginTime=LoginTime;
	model.IP=IP;

	NoName.NetShop.BLL.LoginLogModelBll bll=new NoName.NetShop.BLL.LoginLogModelBll();
	bll.Update(model);

		}

    }
}
