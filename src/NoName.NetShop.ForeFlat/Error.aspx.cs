using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat
{
    public partial class Error : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger("JiajuAppLog");
        protected void Page_Load(object sender, EventArgs e)
        {
            String ErrorMsgs = "发生错误，请与相关技术人员联系";
            Exception ex = Server.GetLastError().GetBaseException();//捕获出错
            log.Error(ex);

            if (ex is ShopException)
            {
                if (((ShopException)ex).IsShowToClient)
                {
                    ErrorMsgs = ex.Message;
                }
            }
            Server.ClearError();
            lblErrorMsg.Text = ErrorMsgs;
        }
    }
}
