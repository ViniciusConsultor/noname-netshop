using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.MagicWorld.Auction
{
    public partial class Comments : System.Web.UI.Page
    {
        private int AuctionID
        {
            get { if (ViewState["AuctionID"] != null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1; }
            set { ViewState["AuctionID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["auctionid"])) AuctionID = Convert.ToInt32(Request.QueryString["auctionid"]);
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
 
        }
    }
}
