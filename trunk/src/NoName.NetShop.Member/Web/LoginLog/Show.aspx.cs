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
    public partial class Show : System.Web.UI.Page
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
		this.lblLoginTime.Text=model.LoginTime.ToString();
		this.lblIP.Text=model.IP;

	}


    }
}
