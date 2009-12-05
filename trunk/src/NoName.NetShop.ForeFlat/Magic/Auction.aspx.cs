using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class Auction : System.Web.UI.Page
    {
        private int AuctionID
        {
            get { if (ViewState["AuctionID"] != null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1; }
            set { ViewState["AuctionID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["a"])) AuctionID = Convert.ToInt32(Request.QueryString["a"]);
                if (AuctionID != -1) BindData();
                else Response.End();
            }            
        }

        private void BindData()
        {
            AuctionProductModel model = bll.GetModel(AuctionID);

            Image_Large.ImageUrl = AuctionImageRule.GetMainImageUrl(model.MediumImage);
            Image_Medium.ImageUrl = AuctionImageRule.GetMainImageUrl(model.SmallImage);

            Literal_ProductName.Text = model.ProductName;
            Literal_StartPrice.Text = model.StartPrice.ToString("0.00");
            Literal_CurrentPrice.Text = model.CurPrice.ToString("0.00"); ;
            Literal_MinAddPrice.Text = model.AddPrices;
            Literal_MaxAddPrice.Text = model.AddPrices;
            Literal_StartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            Literal_EndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            Literal_Description.Text = model.Brief;
        }


        protected void Button_Comment_Click(object sender, EventArgs e)
        {
 
        }
    }
}
