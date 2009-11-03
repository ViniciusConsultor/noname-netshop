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
namespace NoName.NetShop.UserManager.Web.Favorite
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		NoName.NetShop.UserManager.BLL.Favorite bll=new NoName.NetShop.UserManager.BLL.Favorite();
		NoName.NetShop.UserManager.Model.Favorite model=bll.GetModel();
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
