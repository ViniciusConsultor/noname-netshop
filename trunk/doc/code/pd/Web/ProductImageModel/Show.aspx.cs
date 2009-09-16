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
namespace NoName.NetShop.Web.ProductImageModel
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
					//ShowInfo(ImageId);
				}
			}
		}
		
	private void ShowInfo(int ImageId)
	{
		NoName.NetShop.BLL.ProductImageModelBll bll=new NoName.NetShop.BLL.ProductImageModelBll();
		NoName.NetShop.Model.ProductImageModel model=bll.GetModel(ImageId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblSmallImage.Text=model.SmallImage;
		this.lblLargeImage.Text=model.LargeImage;
		this.lblOriginImage.Text=model.OriginImage;
		this.lblTitle.Text=model.Title;

	}


    }
}
