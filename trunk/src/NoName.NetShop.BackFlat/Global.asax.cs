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
            // �l��δ̎���e�`�r���еĳ�ʽ�a
            // Server.Transfer("~/Error.aspx", false); //�ӳٳ�������errorpage.aspx�д���
        }

       
    }
}