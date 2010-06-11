using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class AuctionHome : System.Web.UI.Page
    {
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            int RecordCount = 0;

            Repeater_Auctioning.DataSource = bll.GetList(1, 1, " and status=" + (int)AuctionProductStatus.审核通过 + " and starttime<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and endtime>'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", " starttime desc", out RecordCount);
            Repeater_Auctioning.DataBind();

            Repeater_Auctioned.DataSource = bll.GetList(1, 1, " and status=" + (int)AuctionProductStatus.审核通过 + " and endtime < '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", " auctionid desc", out RecordCount);
            Repeater_Auctioned.DataBind();

            Repeater_NewAuction.DataSource = bll.GetList(1, 1, " and status="+(int)AuctionProductStatus.审核通过, " auctionid desc", out RecordCount);
            Repeater_NewAuction.DataBind();

            Repeater_HotAuctioning.DataSource = bll.GetHotAuctioningProduct(3);
            Repeater_HotAuctioning.DataBind();            
        }

        public int GetAuctionCount(int AuctionID)
        {
            return new AuctionLogBll().GetAuctionCount(AuctionID);
        }
    }
}
