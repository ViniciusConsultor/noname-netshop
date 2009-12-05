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
    public partial class PawnProduct : System.Web.UI.Page
    {
        private int PawnProductID
        {
            get { if (ViewState["PawnProductID"] != null) return Convert.ToInt32(ViewState["PawnProductID"]); else return -1; }
            set { ViewState["PawnProductID"] = value; }
        }
        private PawnProductBll bll = new PawnProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["p"])) PawnProductID = Convert.ToInt32(Request.QueryString["p"]);
                if (PawnProductID != -1) BindData(); else Response.End();
            }
        }

        private void BindData() 
        {
            PawnProductModel model = bll.GetModel(PawnProductID);


        }
    }
}
