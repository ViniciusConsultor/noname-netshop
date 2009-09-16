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
namespace NoName.NetShop.Web.FavoriteModel
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
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		NoName.NetShop.BLL.FavoriteModelBll bll=new NoName.NetShop.BLL.FavoriteModelBll();
		NoName.NetShop.Model.FavoriteModel model=bll.GetModel();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblFavoriteId.Text=model.FavoriteId.ToString();
		this.lblFavoriteUrl.Text=model.FavoriteUrl;
		this.lblFavoriteName.Text=model.FavoriteName;
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblContentId.Text=model.ContentId.ToString();
		this.lblContentType.Text=model.ContentType.ToString();

	}


    }
}
