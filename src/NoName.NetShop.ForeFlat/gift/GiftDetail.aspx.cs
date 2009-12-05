using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.gift
{
    public partial class GiftDetail : System.Web.UI.Page
    {
        protected GiftModel model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId;
                if (!int.TryParse(Request.QueryString["productId"], out productId))
                {
                    productId = 0;
                }
                GiftBll gbll = new GiftBll();
                model = gbll.GetModel(productId);
                if (model == null)
                    throw new ShopException("你查找的积分商品不存在", true);

            }
        }
    }
}
