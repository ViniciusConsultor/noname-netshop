using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.MagicWorld.PawnShop
{
    public partial class Comments : System.Web.UI.Page
    {
        private int PawnProductID
        {
            get { if (ViewState["PawnProductID"] != null) return Convert.ToInt32(ViewState["PawnProductID"]); else return -1; }
            set { ViewState["PawnProductID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pawnid"])) PawnProductID = Convert.ToInt32(Request.QueryString["pawnid"]);
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
 
        }
    }
}
