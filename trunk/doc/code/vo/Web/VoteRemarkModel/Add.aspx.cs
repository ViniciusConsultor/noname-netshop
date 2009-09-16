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
namespace NoName.NetShop.Web.VoteRemarkModel
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
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtVoteTime.Text))
	{
	strErr+="VoteTime不是时间格式！\\n";	
	}
	if(this.txtVoteIP.Text =="")
	{
		strErr+="VoteIP不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string Remark=this.txtRemark.Text;
	DateTime VoteTime=DateTime.Parse(this.txtVoteTime.Text);
	string VoteIP=this.txtVoteIP.Text;

	NoName.NetShop.Model.VoteRemarkModel model=new NoName.NetShop.Model.VoteRemarkModel();
	model.Remark=Remark;
	model.VoteTime=VoteTime;
	model.VoteIP=VoteIP;

	NoName.NetShop.BLL.VoteRemarkModelBll bll=new NoName.NetShop.BLL.VoteRemarkModelBll();
	bll.Add(model);

		}

    }
}
