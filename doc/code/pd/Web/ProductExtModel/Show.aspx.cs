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
namespace NoName.NetShop.Web.ProductExtModel
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
					//ShowInfo(ProductId);
				}
			}
		}
		
	private void ShowInfo(int ProductId)
	{
		NoName.NetShop.BLL.ProductExtModelBll bll=new NoName.NetShop.BLL.ProductExtModelBll();
		NoName.NetShop.Model.ProductExtModel model=bll.GetModel(ProductId);
		this.lblProductDesc.Text=model.ProductDesc;

	}


    }
}
