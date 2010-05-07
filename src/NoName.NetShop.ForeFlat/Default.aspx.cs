using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace NoName.NetShop.ForeFlat
{
    public partial class _Default : System.Web.UI.Page
    {
        private static ILog log = log4net.LogManager.GetLogger("test");
        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("this is log test");

        }
    }
}
