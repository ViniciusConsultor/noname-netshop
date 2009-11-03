using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace NoName.NetShop.ForeFlat
{
    public class BasePage : System.Web.UI.Page
    {
        NameValueCollection _reqParas = null;

        private static readonly string REDIRECT_BY_WINDOW_LOCATION = @"<script type='text/javascript'>window.location='{0}';</script>";
        private static readonly string CLIENT_ALERT = @"<script type='text/javascript'>alert('{0}');</script>";
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
        }

        protected NameValueCollection ReqParas
        {
            get
            {
                if (_reqParas == null)
                {
                    if (Request.RequestType == "GET")
                    {
                        _reqParas = Request.QueryString;
                    }
                    else
                    {
                        _reqParas = Request.Form;
                    }
                }
                return _reqParas;
            }
        }

 
        protected void RedirectByWindowLocation(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "clientRedirect", String.Format(REDIRECT_BY_WINDOW_LOCATION, url));
            }
        }

        protected void ClientAlert(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "clientAlert", String.Format(CLIENT_ALERT, message.Replace("'", "\"")));
            }
        }
    }

}
