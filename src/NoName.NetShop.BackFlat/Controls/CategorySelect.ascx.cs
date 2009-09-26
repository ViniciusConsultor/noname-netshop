using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Controls
{
    public partial class CategorySelect : System.Web.UI.UserControl
    {
        public int InitialCategory 
        {
            get { if (ViewState["InitialCategory"] != null) return Convert.ToInt32(ViewState["InitialCategory"]); else return 0; }
            set { ViewState["InitialCategory"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}