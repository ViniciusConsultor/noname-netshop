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
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ���";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtCateId.Text))
	{
		strErr+="CateId�������֣�\\n";	
	}
	if(this.txtParaName.Text =="")
	{
		strErr+="ParaName����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsNumber(txtParaType.Text))
	{
		strErr+="ParaType�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtParaGroupId.Text))
	{
		strErr+="ParaGroupId�������֣�\\n";	
	}
	if(this.txtParaValues.Text =="")
	{
		strErr+="ParaValues����Ϊ�գ�\\n";	
	}
	if(this.txtDefaultValue.Text =="")
	{
		strErr+="DefaultValue����Ϊ�գ�\\n";	
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
