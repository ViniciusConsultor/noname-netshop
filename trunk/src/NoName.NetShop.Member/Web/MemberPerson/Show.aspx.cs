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
namespace NoName.NetShop.UserManager.Web.MemberPerson
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
					//ShowInfo(userid);
				}
			}
		}
		
	private void ShowInfo(int userid)
	{
		NoName.NetShop.UserManager.BLL.MemberPerson bll=new NoName.NetShop.UserManager.BLL.MemberPerson();
		NoName.NetShop.UserManager.Model.MemberPerson model=bll.GetModel(userid);
		this.lbltruename.Text=model.truename;
		this.lblIdCard.Text=model.IdCard;
		this.lblMobile.Text=model.Mobile;
		this.lblTelePhone.Text=model.TelePhone;
		this.lblEmail.Text=model.Email;
		this.lblUserLevel.Text=model.UserLevel.ToString();

	}


    }
}
