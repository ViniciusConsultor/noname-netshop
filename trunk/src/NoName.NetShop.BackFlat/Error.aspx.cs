using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using log4net;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat
{
    public partial class Error : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger("JiajuAppLog");
        protected void Page_Load(object sender, EventArgs e)
        {
            String ErrorMsgs = "��������������ؼ�����Ա��ϵ";
            Exception ex = Server.GetLastError().GetBaseException();//�������
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
