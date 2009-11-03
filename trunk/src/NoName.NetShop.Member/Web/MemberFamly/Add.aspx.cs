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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TabTitle="��Ϣ��ӣ�����ϸ��д������Ϣ";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserId.Text))
			{
				strErr+="userId�������֣�\\n";	
			}
			if(this.txttruename.Text =="")
			{
				strErr+="truename����Ϊ�գ�\\n";	
			}
			if(this.txtidcard.Text =="")
			{
				strErr+="idcard����Ϊ�գ�\\n";	
			}
			if(this.txtAddress.Text =="")
			{
				strErr+="Address����Ϊ�գ�\\n";	
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
			if(this.txtEmail.Text =="")
			{
				strErr+="Email����Ϊ�գ�\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userId=int.Parse(this.txtuserId.Text);
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
			model.userId=userId;
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
			bll.Add(model);

		}

    }
}
