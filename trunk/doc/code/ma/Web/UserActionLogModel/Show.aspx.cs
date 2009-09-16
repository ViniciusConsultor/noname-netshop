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
namespace NoName.NetShop.Web.UserActionLogModel
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
					//ShowInfo(UserId);
				}
			}
		}
		
	private void ShowInfo(int UserId)
	{
		NoName.NetShop.BLL.UserActionLogModelBll bll=new NoName.NetShop.BLL.UserActionLogModelBll();
		NoName.NetShop.Model.UserActionLogModel model=bll.GetModel(UserId);
		this.lblActionName.Text=model.ActionName;
		this.lblActionTime.Text=model.ActionTime.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
