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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TabTitle="信息添加，请详细填写下列信息";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid不是数字！\\n";	
			}
			if(this.txttruename.Text =="")
			{
				strErr+="truename不能为空！\\n";	
			}
			if(this.txtidcard.Text =="")
			{
				strErr+="idcard不能为空！\\n";	
			}
			if(this.txtcompanyname.Text =="")
			{
				strErr+="companyname不能为空！\\n";	
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
			int userid=int.Parse(this.txtuserid.Text);
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
			model.userid=userid;
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
			bll.Add(model);

		}

    }
}
