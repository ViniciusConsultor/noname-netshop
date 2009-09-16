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
namespace NoName.NetShop.Web.CategoryParaModel
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
	if(!PageValidate.IsNumber(txtCateId.Text))
	{
		strErr+="CateId不是数字！\\n";	
	}
	if(this.txtParaName.Text =="")
	{
		strErr+="ParaName不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtParaType.Text))
	{
		strErr+="ParaType不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtParaGroupId.Text))
	{
		strErr+="ParaGroupId不是数字！\\n";	
	}
	if(this.txtParaValues.Text =="")
	{
		strErr+="ParaValues不能为空！\\n";	
	}
	if(this.txtDefaultValue.Text =="")
	{
		strErr+="DefaultValue不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int CateId=int.Parse(this.txtCateId.Text);
	string ParaName=this.txtParaName.Text;
	int ParaType=int.Parse(this.txtParaType.Text);
	int Status=int.Parse(this.txtStatus.Text);
	int ParaGroupId=int.Parse(this.txtParaGroupId.Text);
	string ParaValues=this.txtParaValues.Text;
	string DefaultValue=this.txtDefaultValue.Text;

	NoName.NetShop.Model.CategoryParaModel model=new NoName.NetShop.Model.CategoryParaModel();
	model.CateId=CateId;
	model.ParaName=ParaName;
	model.ParaType=ParaType;
	model.Status=Status;
	model.ParaGroupId=ParaGroupId;
	model.ParaValues=ParaValues;
	model.DefaultValue=DefaultValue;

	NoName.NetShop.BLL.CategoryParaModelBll bll=new NoName.NetShop.BLL.CategoryParaModelBll();
	bll.Add(model);

		}

    }
}
