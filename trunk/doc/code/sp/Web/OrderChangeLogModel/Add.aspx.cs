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
namespace NoName.NetShop.Web.OrderChangeLogModel
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
	if(!PageValidate.IsNumber(txtOrderId.Text))
	{
		strErr+="OrderId不是数字！\\n";	
	}
	if(!PageValidate.IsDateTime(txtChangeTime.Text))
	{
	strErr+="ChangeTime不是时间格式！\\n";	
	}
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark不能为空！\\n";	
	}
	if(this.txtOperator.Text =="")
	{
		strErr+="Operator不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int OrderId=int.Parse(this.txtOrderId.Text);
	DateTime ChangeTime=DateTime.Parse(this.txtChangeTime.Text);
	string Remark=this.txtRemark.Text;
	string Operator=this.txtOperator.Text;

	NoName.NetShop.Model.OrderChangeLogModel model=new NoName.NetShop.Model.OrderChangeLogModel();
	model.OrderId=OrderId;
	model.ChangeTime=ChangeTime;
	model.Remark=Remark;
	model.Operator=Operator;

	NoName.NetShop.BLL.OrderChangeLogModelBll bll=new NoName.NetShop.BLL.OrderChangeLogModelBll();
	bll.Add(model);

		}

    }
}
