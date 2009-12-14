using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.MagicWorld.Secondhand
{
    public partial class Comments : System.Web.UI.Page
    {
        private int SecondhandProductID
        {
            get { if (ViewState["SecondhandProductID"] != null) return Convert.ToInt32(ViewState["SecondhandProductID"]); else return -1; }
            set { ViewState["SecondhandProductID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["secondhandid"])) SecondhandProductID = Convert.ToInt32(Request.QueryString["secondhandid"]);
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
 
        }
    }
}
