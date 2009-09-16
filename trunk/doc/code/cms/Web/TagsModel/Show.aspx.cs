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
namespace NoName.NetShop.Web.TagsModel
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
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
		this.lblCmsTagName.Text=model.CmsTagName;
		this.lblTagBrief.Text=model.TagBrief;
		this.lblDefaultContent.Text=model.DefaultContent;
		this.lblTagType.Text=model.TagType;
		this.lblTagParas.Text=model.TagParas;

	}


    }
}
