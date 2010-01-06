using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class DoFavorite : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoriteBll fbll = new FavoriteBll();
            FavoriteModel favModel = new FavoriteModel();

            favModel.ContentId = int.Parse(ReqParas["cid"]);
            favModel.UserId = CurrentUser.UserId;
            favModel.ContentType = (ContentType)int.Parse(ReqParas["ctype"]);
            favModel.FavoriteName = "";
            favModel.FavoriteUrl = "";
            fbll.Add(favModel);
            Response.Redirect("MyFavorite.aspx");
        }
    }
}
