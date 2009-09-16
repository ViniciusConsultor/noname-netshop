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
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(CmsTagId);
				}
			}
		}
			
	private void ShowInfo(int CmsTagId)
	{
		NoName.NetShop.BLL.TagsModelBll bll=new NoName.NetShop.BLL.TagsModelBll();
		NoName.NetShop.Model.TagsModel model=bll.GetModel(CmsTagId);
		this.lblCmsTagId.Text=model.CmsTagId.ToString();
		this.txtCmsTagName.Text=model.CmsTagName;
		this.txtTagBrief.Text=model.TagBrief;
		this.txtDefaultContent.Text=model.DefaultContent;
		this.txtTagType.Text=model.TagType;
		this.txtTagParas.Text=model.TagParas;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtCmsTagName.Text =="")
	{
		strErr+="CmsTagName不能为空！\\n";	
	}
	if(this.txtTagBrief.Text =="")
	{
		strErr+="TagBrief不能为空！\\n";	
	}
	if(this.txtDefaultContent.Text =="")
	{
		strErr+="DefaultContent不能为空！\\n";	
	}
	if(this.txtTagType.Text =="")
	{
		strErr+="TagType不能为空！\\n";	
	}
	if(this.txtTagParas.Text =="")
	{
		strErr+="TagParas不能为空！\\n";	
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
	bll.Update(model);

		}

    }
}
