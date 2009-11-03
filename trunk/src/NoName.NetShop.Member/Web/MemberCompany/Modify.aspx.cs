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
    public partial class Modify : System.Web.UI.Page
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
		this.lbluserid.Text=model.userid.ToString();
		this.txttruename.Text=model.truename;
		this.txtidcard.Text=model.idcard;
		this.txtcompanyname.Text=model.companyname;
		this.txtprovince.Text=model.province;
		this.txtcity.Text=model.city;
		this.txtcounty.Text=model.county;
		this.txtMobile.Text=model.Mobile;
		this.txtTelePhone.Text=model.TelePhone;
		this.txtFax.Text=model.Fax;
		this.txtEmail.Text=model.Email;

	}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttruename.Text =="")
			{
				strErr+="truename����Ϊ�գ�\\n";	
			}
			if(this.txtidcard.Text =="")
			{
				strErr+="idcard����Ϊ�գ�\\n";	
			}
			if(this.txtcompanyname.Text =="")
			{
				strErr+="companyname����Ϊ�գ�\\n";	
			}
			if(this.txtprovince.Text =="")
			{
				strErr+="province����Ϊ�գ�\\n";	
			}
			if(this.txtcity.Text =="")
			{
				strErr+="city����Ϊ�գ�\\n";	
			}
			if(this.txtcounty.Text =="")
			{
				strErr+="county����Ϊ�գ�\\n";	
			}
			if(this.txtMobile.Text =="")
			{
				strErr+="Mobile����Ϊ�գ�\\n";	
			}
			if(this.txtTelePhone.Text =="")
			{
				strErr+="TelePhone����Ϊ�գ�\\n";	
			}
			if(this.txtFax.Text =="")
			{
				strErr+="Fax����Ϊ�գ�\\n";	
			}
			if(this.txtEmail.Text =="")
			{
				strErr+="Email����Ϊ�գ�\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string truename=this.txttruename.Text;
			string idcard=this.txtidcard.Text;
			string companyname=this.txtcompanyname.Text;
			string province=this.txtprovince.Text;
			string city=this.txtcity.Text;
			string county=this.txtcounty.Text;
			string Mobile=this.txtMobile.Text;
			string TelePhone=this.txtTelePhone.Text;
			string Fax=this.txtFax.Text;
			string Email=this.txtEmail.Text;


			NoName.NetShop.UserManager.Model.MemberCompany model=new NoName.NetShop.UserManager.Model.MemberCompany();
			model.truename=truename;
			model.idcard=idcard;
			model.companyname=companyname;
			model.province=province;
			model.city=city;
			model.county=county;
			model.Mobile=Mobile;
			model.TelePhone=TelePhone;
			model.Fax=Fax;
			model.Email=Email;

			NoName.NetShop.UserManager.BLL.MemberCompany bll=new NoName.NetShop.UserManager.BLL.MemberCompany();
			bll.Update(model);

		}

    }
}
