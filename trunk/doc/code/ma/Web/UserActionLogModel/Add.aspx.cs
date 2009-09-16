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
namespace NoName.NetShop.Web.UserActionLogModel
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
	if(this.txtActionName.Text =="")
	{
		strErr+="ActionName不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtActionTime.Text))
	{
	strErr+="ActionTime不是时间格式！\\n";	
	}
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ActionName=this.txtActionName.Text;
	DateTime ActionTime=DateTime.Parse(this.txtActionTime.Text);
	string Remark=this.txtRemark.Text;

	NoName.NetShop.Model.UserActionLogModel model=new NoName.NetShop.Model.UserActionLogModel();
	model.ActionName=ActionName;
	model.ActionTime=ActionTime;
	model.Remark=Remark;

	NoName.NetShop.BLL.UserActionLogModelBll bll=new NoName.NetShop.BLL.UserActionLogModelBll();
	bll.Add(model);

		}

    }
}
