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
namespace NoName.NetShop.Web.SupplyDemandModel
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
					//ShowInfo(sdId);
				}
			}
		}
		
	private void ShowInfo(int sdId)
	{
		NoName.NetShop.BLL.SupplyDemandModelBll bll=new NoName.NetShop.BLL.SupplyDemandModelBll();
		NoName.NetShop.Model.SupplyDemandModel model=bll.GetModel(sdId);
		this.lblsdType.Text=model.sdType.ToString();
		this.lbluserId.Text=model.userId.ToString();
		this.lblTitle.Text=model.Title;
		this.lblContent.Text=model.Content;
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblModifyTime.Text=model.ModifyTime.ToString();
		this.lblStatus.Text=model.Status.ToString();

	}


    }
}
