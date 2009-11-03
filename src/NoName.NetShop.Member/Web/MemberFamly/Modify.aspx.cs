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

namespace NoName.NetShop.UserManager.Web.MemberFamly
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
					//ShowInfo(userId);
				}
			}
		}
			
	private void ShowInfo(int userId)
	{
		NoName.NetShop.UserManager.BLL.MemberFamly bll=new NoName.NetShop.UserManager.BLL.MemberFamly();
		NoName.NetShop.UserManager.Model.MemberFamly model=bll.GetModel(userId);
		this.lbluserId.Text=model.userId.ToString();
		this.txttruename.Text=model.truename;
		this.txtidcard.Text=model.idcard;
		this.txtAddress.Text=model.Address;
		this.txtprovince.Text=model.province;
		this.txtcity.Text=model.city;
		this.txtcounty.Text=model.county;
		this.txtMobile.Text=model.Mobile;
		this.txtTelePhone.Text=model.TelePhone;
		this.txtEmail.Text=model.Email;

	}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttruename.Text =="")
			{
				strErr+="truename不能为空！\\n";	
			}
			if(this.txtidcard.Text =="")
			{
				strErr+="idcard不能为空！\\n";	
			}
			if(this.txtAddress.Text =="")
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtprovince.Text =="")
			{
				strErr+="province不能为空！\\n";	
			}
			if(this.txtcity.Text =="")
			{
				strErr+="city不能为空！\\n";	
			}
			if(this.txtcounty.Text =="")
			{
				strErr+="county不能为空！\\n";	
			}
			if(this.txtMobile.Text =="")
			{
				strErr+="Mobile不能为空！\\n";	
			}
			if(this.txtTelePhone.Text =="")
			{
				strErr+="TelePhone不能为空！\\n";	
			}
			if(this.txtEmail.Text =="")
			{
				strErr+="Email不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string truename=this.txttruename.Text;
			string idcard=this.txtidcard.Text;
			string Address=this.txtAddress.Text;
			string province=this.txtprovince.Text;
			string city=this.txtcity.Text;
			string county=this.txtcounty.Text;
			string Mobile=this.txtMobile.Text;
			string TelePhone=this.txtTelePhone.Text;
			string Email=this.txtEmail.Text;


			NoName.NetShop.UserManager.Model.MemberFamly model=new NoName.NetShop.UserManager.Model.MemberFamly();
			model.truename=truename;
			model.idcard=idcard;
			model.Address=Address;
			model.province=province;
			model.city=city;
			model.county=county;
			model.Mobile=Mobile;
			model.TelePhone=TelePhone;
			model.Email=Email;

			NoName.NetShop.UserManager.BLL.MemberFamly bll=new NoName.NetShop.UserManager.BLL.MemberFamly();
			bll.Update(model);

		}

    }
}
