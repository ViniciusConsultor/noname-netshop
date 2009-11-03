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

namespace NoName.NetShop.UserManager.Web.LoginLog
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
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId不是数字！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLoginTime.Text))
			{
				strErr+="LoginTime不是时间格式！\\n";	
			}
			if(this.txtIP.Text =="")
			{
				strErr+="IP不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserId=int.Parse(this.txtUserId.Text);
			DateTime LoginTime=DateTime.Parse(this.txtLoginTime.Text);
			string IP=this.txtIP.Text;

			NoName.NetShop.UserManager.Model.LoginLog model=new NoName.NetShop.UserManager.Model.LoginLog();
			model.UserId=UserId;
			model.LoginTime=LoginTime;
			model.IP=IP;

			NoName.NetShop.UserManager.BLL.LoginLog bll=new NoName.NetShop.UserManager.BLL.LoginLog();
			bll.Add(model);

		}

    }
}
