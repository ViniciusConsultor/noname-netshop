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
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(userId);
				}
			}
		}
		
	private void ShowInfo(int userId)
	{
		NoName.NetShop.UserManager.BLL.Member bll=new NoName.NetShop.UserManager.BLL.Member();
		NoName.NetShop.UserManager.Model.Member model=bll.GetModel(userId);
		this.lblUserEmail.Text=model.UserEmail;
		this.lblPassword.Text=model.Password;
		this.lblNickName.Text=model.NickName;
		this.lblAllScore.Text=model.AllScore.ToString();
		this.lblCurScore.Text=model.CurScore.ToString();
		this.lblLastLogin.Text=model.LastLogin.ToString();
		this.lblLoginIP.Text=model.LoginIP;
		this.lblRegisterTime.Text=model.RegisterTime.ToString();
		this.lblModifyTime.Text=model.ModifyTime.ToString();
		this.lblUserType.Text=model.UserType.ToString();
		this.lblstatus.Text=model.status.ToString();

	}


    }
}
