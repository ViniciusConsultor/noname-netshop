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
namespace NoName.NetShop.UserManager.Web.MemberSchool
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
		NoName.NetShop.UserManager.BLL.MemberSchool bll=new NoName.NetShop.UserManager.BLL.MemberSchool();
		NoName.NetShop.UserManager.Model.MemberSchool model=bll.GetModel(userid);
		this.lbltruename.Text=model.truename;
		this.lblduty.Text=model.duty.ToString();
		this.lblschool.Text=model.school;
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
