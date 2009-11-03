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
namespace NoName.NetShop.UserManager.Web.MemberCompany
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
		NoName.NetShop.UserManager.BLL.MemberCompany bll=new NoName.NetShop.UserManager.BLL.MemberCompany();
		NoName.NetShop.UserManager.Model.MemberCompany model=bll.GetModel(userid);
		this.lbltruename.Text=model.truename;
		this.lblidcard.Text=model.idcard;
		this.lblcompanyname.Text=model.companyname;
		this.lblprovince.Text=model.province;
		this.lblcity.Text=model.city;
		this.lblcounty.Text=model.county;
		this.lblMobile.Text=model.Mobile;
		this.lblTelePhone.Text=model.TelePhone;
		this.lblFax.Text=model.Fax;
		this.lblEmail.Text=model.Email;

	}


    }
}
