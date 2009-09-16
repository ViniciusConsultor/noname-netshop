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
namespace NoName.NetShop.Web.TagsModel
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
	if(this.txtCmsTagName.Text =="")
	{
		strErr+="CmsTagName����Ϊ�գ�\\n";	
	}
	if(this.txtTagBrief.Text =="")
	{
		strErr+="TagBrief����Ϊ�գ�\\n";	
	}
	if(this.txtDefaultContent.Text =="")
	{
		strErr+="DefaultContent����Ϊ�գ�\\n";	
	}
	if(this.txtTagType.Text =="")
	{
		strErr+="TagType����Ϊ�գ�\\n";	
	}
	if(this.txtTagParas.Text =="")
	{
		strErr+="TagParas����Ϊ�գ�\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string CmsTagName=this.txtCmsTagName.Text;
	string TagBrief=this.txtTagBrief.Text;
	string DefaultContent=this.txtDefaultContent.Text;
	string TagType=this.txtTagType.Text;
	string TagParas=this.txtTagParas.Text;

	NoName.NetShop.Model.TagsModel model=new NoName.NetShop.Model.TagsModel();
	model.CmsTagName=CmsTagName;
	model.TagBrief=TagBrief;
	model.DefaultContent=DefaultContent;
	model.TagType=TagType;
	model.TagParas=TagParas;

	NoName.NetShop.BLL.TagsModelBll bll=new NoName.NetShop.BLL.TagsModelBll();
	bll.Add(model);

		}

    }
}
