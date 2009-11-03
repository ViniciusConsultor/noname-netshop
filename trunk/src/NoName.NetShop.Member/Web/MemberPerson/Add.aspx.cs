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
			if(this.txtIdCard.Text =="")
			{
				strErr+="IdCard����Ϊ�գ�\\n";	
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
			if(!PageValidate.IsNumber(txtUserLevel.Text))
			{
				strErr+="UserLevel�������֣�\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userid=int.Parse(this.txtuserid.Text);
			string truename=this.txttruename.Text;
			string IdCard=this.txtIdCard.Text;
			string Mobile=this.txtMobile.Text;
			string TelePhone=this.txtTelePhone.Text;
			string Email=this.txtEmail.Text;
			int UserLevel=int.Parse(this.txtUserLevel.Text);

			NoName.NetShop.UserManager.Model.MemberPerson model=new NoName.NetShop.UserManager.Model.MemberPerson();
			model.userid=userid;
			model.truename=truename;
			model.IdCard=IdCard;
			model.Mobile=Mobile;
			model.TelePhone=TelePhone;
			model.Email=Email;
			model.UserLevel=UserLevel;

			NoName.NetShop.UserManager.BLL.MemberPerson bll=new NoName.NetShop.UserManager.BLL.MemberPerson();
			bll.Add(model);

		}

    }
}
