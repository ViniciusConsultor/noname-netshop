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
		NoName.NetShop.UserManager.BLL.MemberPerson bll=new NoName.NetShop.UserManager.BLL.MemberPerson();
		NoName.NetShop.UserManager.Model.MemberPerson model=bll.GetModel(userid);
		this.lbluserid.Text=model.userid.ToString();
		this.txttruename.Text=model.truename;
		this.txtIdCard.Text=model.IdCard;
		this.txtMobile.Text=model.Mobile;
		this.txtTelePhone.Text=model.TelePhone;
		this.txtEmail.Text=model.Email;
		this.txtUserLevel.Text=model.UserLevel.ToString();

	}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttruename.Text =="")
			{
				strErr+="truename不能为空！\\n";	
			}
			if(this.txtIdCard.Text =="")
			{
				strErr+="IdCard不能为空！\\n";	
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
			if(!PageValidate.IsNumber(txtUserLevel.Text))
			{
				strErr+="UserLevel不是数字！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string truename=this.txttruename.Text;
			string IdCard=this.txtIdCard.Text;
			string Mobile=this.txtMobile.Text;
			string TelePhone=this.txtTelePhone.Text;
			string Email=this.txtEmail.Text;
			int UserLevel=int.Parse(this.txtUserLevel.Text);


			NoName.NetShop.UserManager.Model.MemberPerson model=new NoName.NetShop.UserManager.Model.MemberPerson();
			model.truename=truename;
			model.IdCard=IdCard;
			model.Mobile=Mobile;
			model.TelePhone=TelePhone;
			model.Email=Email;
			model.UserLevel=UserLevel;

			NoName.NetShop.UserManager.BLL.MemberPerson bll=new NoName.NetShop.UserManager.BLL.MemberPerson();
			bll.Update(model);

		}

    }
}
