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
		NoName.NetShop.UserManager.BLL.MemberSchool bll=new NoName.NetShop.UserManager.BLL.MemberSchool();
		NoName.NetShop.UserManager.Model.MemberSchool model=bll.GetModel(userid);
		this.lbluserid.Text=model.userid.ToString();
		this.txttruename.Text=model.truename;
		this.txtduty.Text=model.duty.ToString();
		this.txtschool.Text=model.school;
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
				strErr+="truename不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtduty.Text))
			{
				strErr+="duty不是数字！\\n";	
			}
			if(this.txtschool.Text =="")
			{
				strErr+="school不能为空！\\n";	
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
			if(this.txtFax.Text =="")
			{
				strErr+="Fax不能为空！\\n";	
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
			int duty=int.Parse(this.txtduty.Text);
			string school=this.txtschool.Text;
			string province=this.txtprovince.Text;
			string city=this.txtcity.Text;
			string county=this.txtcounty.Text;
			string Mobile=this.txtMobile.Text;
			string TelePhone=this.txtTelePhone.Text;
			string Fax=this.txtFax.Text;
			string Email=this.txtEmail.Text;


			NoName.NetShop.UserManager.Model.MemberSchool model=new NoName.NetShop.UserManager.Model.MemberSchool();
			model.truename=truename;
			model.duty=duty;
			model.school=school;
			model.province=province;
			model.city=city;
			model.county=county;
			model.Mobile=Mobile;
			model.TelePhone=TelePhone;
			model.Fax=Fax;
			model.Email=Email;

			NoName.NetShop.UserManager.BLL.MemberSchool bll=new NoName.NetShop.UserManager.BLL.MemberSchool();
			bll.Update(model);

		}

    }
}
