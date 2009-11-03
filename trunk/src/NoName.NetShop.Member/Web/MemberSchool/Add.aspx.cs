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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TabTitle="��Ϣ��ӣ�����ϸ��д������Ϣ";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserid.Text))
			{
				strErr+="userid�������֣�\\n";	
			}
			if(this.txttruename.Text =="")
			{
				strErr+="truename����Ϊ�գ�\\n";	
			}
			if(!PageValidate.IsNumber(txtduty.Text))
			{
				strErr+="duty�������֣�\\n";	
			}
			if(this.txtschool.Text =="")
			{
				strErr+="school����Ϊ�գ�\\n";	
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
			int userid=int.Parse(this.txtuserid.Text);
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
			model.userid=userid;
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
			bll.Add(model);

		}

    }
}
