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
namespace NoName.NetShop.Web.CommendModel
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
					//ShowInfo(SchemeId,CateId,ProductId);
				}
			}
		}
		
	private void ShowInfo(int SchemeId,int CateId,int ProductId)
	{
		NoName.NetShop.BLL.CommendModelBll bll=new NoName.NetShop.BLL.CommendModelBll();
		NoName.NetShop.Model.CommendModel model=bll.GetModel(SchemeId,CateId,ProductId);
		this.lblQuantity.Text=model.Quantity.ToString();

	}


    }
}
