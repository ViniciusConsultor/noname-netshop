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
namespace NoName.NetShop.Web.SuitSchemeModel
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
	if(this.txtSchemeName.Text =="")
	{
		strErr+="SchemeName����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtCreateTime.Text))
	{
	strErr+="CreateTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status�������֣�\\n";	
	}
	if(this.txtSchemeDesc.Text =="")
	{
		strErr+="SchemeDesc����Ϊ�գ�\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string SchemeName=this.txtSchemeName.Text;
	DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
	int Status=int.Parse(this.txtStatus.Text);
	string SchemeDesc=this.txtSchemeDesc.Text;

	NoName.NetShop.Model.SuitSchemeModel model=new NoName.NetShop.Model.SuitSchemeModel();
	model.SchemeName=SchemeName;
	model.CreateTime=CreateTime;
	model.Status=Status;
	model.SchemeDesc=SchemeDesc;

	NoName.NetShop.BLL.SuitSchemeModelBll bll=new NoName.NetShop.BLL.SuitSchemeModelBll();
	bll.Add(model);

		}

    }
}
