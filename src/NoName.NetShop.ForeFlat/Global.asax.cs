using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using NoName.NetShop.Member;
using System.Threading;

namespace NoName.NetShop.ForeFlat
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated
                && user.Identity.AuthenticationType == "Forms")
            {
                try
                {
                    FormsIdentity formIdentity = user.Identity as FormsIdentity;
                    ShopIdentity identity = new ShopIdentity(formIdentity.Ticket);

                    ShopPrincipal principal = new ShopPrincipal(identity);
                    HttpContext.Current.User = principal;
                    Thread.CurrentPrincipal = principal;
                }
                catch
                {

                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }
}