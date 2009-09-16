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
namespace NoName.NetShop.Web.PagesModel
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
	if(!PageValidate.IsNumber(txtPageId.Text))
	{
		strErr+="PageId�������֣�\\n";	
	}
	if(this.txtTemplateFile.Text =="")
	{
		strErr+="TemplateFile����Ϊ�գ�\\n";	
	}
	if(this.txtPageUrl.Text =="")
	{
		strErr+="PageUrl����Ϊ�գ�\\n";	
	}
	if(this.txtPagePhyPath.Text =="")
	{
		strErr+="PagePhyPath����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status�������֣�\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastPubTime.Text))
	{
	strErr+="LastPubTime����ʱ���ʽ��\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int PageId=int.Parse(this.txtPageId.Text);
	string TemplateFile=this.txtTemplateFile.Text;
	string PageUrl=this.txtPageUrl.Text;
	string PagePhyPath=this.txtPagePhyPath.Text;
	int Status=int.Parse(this.txtStatus.Text);
	DateTime LastPubTime=DateTime.Parse(this.txtLastPubTime.Text);

	NoName.NetShop.Model.PagesModel model=new NoName.NetShop.Model.PagesModel();
	model.PageId=PageId;
	model.TemplateFile=TemplateFile;
	model.PageUrl=PageUrl;
	model.PagePhyPath=PagePhyPath;
	model.Status=Status;
	model.LastPubTime=LastPubTime;

	NoName.NetShop.BLL.PagesModelBll bll=new NoName.NetShop.BLL.PagesModelBll();
	bll.Add(model);

		}

    }
}
