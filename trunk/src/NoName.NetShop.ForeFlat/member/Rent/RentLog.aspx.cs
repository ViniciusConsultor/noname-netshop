using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.ForeFlat.member.Rent
{
    public partial class RentLog : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (CurrentUser == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
        }
    }
}
