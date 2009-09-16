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
namespace NoName.NetShop.Web.UserInRoleModel
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "ÐÅÏ¢ÐÞ¸Ä";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(UserId,RoleId);
				}
			}
		}
			
	private void ShowInfo(int UserId,int RoleId)
	{
		NoName.NetShop.BLL.UserInRoleModelBll bll=new NoName.NetShop.BLL.UserInRoleModelBll();
		NoName.NetShop.Model.UserInRoleModel model=bll.GetModel(UserId,RoleId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblRoleId.Text=model.RoleId.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}


	NoName.NetShop.Model.UserInRoleModel model=new NoName.NetShop.Model.UserInRoleModel();

	NoName.NetShop.BLL.UserInRoleModelBll bll=new NoName.NetShop.BLL.UserInRoleModelBll();
	bll.Update(model);

		}

    }
}
