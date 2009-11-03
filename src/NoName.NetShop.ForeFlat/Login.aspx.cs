using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace NoName.NetShop.ForeFlat
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string optype = Request.QueryString["loginop"];
                if (optype == "2")
                {
                    FormsAuthentication.SignOut();
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;
            string md5pass = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            NoName.NetShop.Member.BLL.Member mbll = new NoName.NetShop.Member.BLL.Member();
            if (mbll.ValidateUser(username, md5pass))
            {
                NoName.NetShop.Member.Model.MemberModel mmodel = mbll.GetModel(username);
                string userData = String.Format("{0}:{1}:{2}:{3}", mmodel.userId, mmodel.NickName, (int)mmodel.Status, (int)mmodel.UserType);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  username,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(30), true,
                  userData,
                  FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // Redirect back to original URL.
                Response.Redirect(FormsAuthentication.GetRedirectUrl(username, true));

            }
        }
    }
}
