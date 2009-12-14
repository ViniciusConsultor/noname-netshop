using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class AuctionList : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["c"])) CategoryID = Convert.ToInt32(Request.QueryString["c"]); else CategoryID = 0;
                if(CategoryID != -1) BindData();
                else Response.End();
            }
        }

        private void BindData() 
        {

        }
    }
}
