using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NoName.NetShop.BackFlat
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 發生未處理錯誤時執行的程式碼
            // Server.Transfer("~/Error.aspx", false); //延迟出错处理，到errorpage.aspx中处理
        }

       
    }
}