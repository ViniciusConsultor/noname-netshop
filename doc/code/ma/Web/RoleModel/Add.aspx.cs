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
using LTP.Common;
namespace NoName.NetShop.Web.RoleModel
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtRoleName.Text =="")
	{
		strErr+="RoleName不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string RoleName=this.txtRoleName.Text;

	NoName.NetShop.Model.RoleModel model=new NoName.NetShop.Model.RoleModel();
	model.RoleName=RoleName;

	NoName.NetShop.BLL.RoleModelBll bll=new NoName.NetShop.BLL.RoleModelBll();
	bll.Add(model);

		}

    }
}
