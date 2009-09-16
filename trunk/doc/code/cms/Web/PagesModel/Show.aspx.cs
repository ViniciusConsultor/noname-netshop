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
namespace NoName.NetShop.Web.PagesModel
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��ϸ��Ϣ";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		NoName.NetShop.BLL.PagesModelBll bll=new NoName.NetShop.BLL.PagesModelBll();
		NoName.NetShop.Model.PagesModel model=bll.GetModel();
		this.lblPageId.Text=model.PageId.ToString();
		this.lblTemplateFile.Text=model.TemplateFile;
		this.lblPageUrl.Text=model.PageUrl;
		this.lblPagePhyPath.Text=model.PagePhyPath;
		this.lblStatus.Text=model.Status.ToString();
		this.lblLastPubTime.Text=model.LastPubTime.ToString();

	}


    }
}
