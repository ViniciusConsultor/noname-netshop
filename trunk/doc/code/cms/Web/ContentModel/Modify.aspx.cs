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
namespace NoName.NetShop.Web.ContentModel
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
		NoName.NetShop.BLL.ContentModelBll bll=new NoName.NetShop.BLL.ContentModelBll();
		NoName.NetShop.Model.ContentModel model=bll.GetModel(CmsTagId);
		this.lblCmsTagId.Text=model.CmsTagId.ToString();
		this.txtContent.Text=model.Content;
		this.txtLastModifyTime.Text=model.LastModifyTime.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtLastModifyTime.Text))
	{
		strErr+="LastModifyTime不是时间格式！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string Content=this.txtContent.Text;
	DateTime LastModifyTime=DateTime.Parse(this.txtLastModifyTime.Text);


	NoName.NetShop.Model.ContentModel model=new NoName.NetShop.Model.ContentModel();
	model.Content=Content;
	model.LastModifyTime=LastModifyTime;

	NoName.NetShop.BLL.ContentModelBll bll=new NoName.NetShop.BLL.ContentModelBll();
	bll.Update(model);

		}

    }
}
