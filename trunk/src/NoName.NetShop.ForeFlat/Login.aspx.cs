﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NoName.NetShop.Member;

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
            string userId = txtUserId.Text.Trim();
            string password = txtPassword.Text;

            if (MemberInfo.Login(userId, password, Request.UserHostAddress))
            {
                MemberInfo mmodel = MemberInfo.GetBaseInfo(userId);
                string userData = String.Format("{0}:{1}:{2}:{3}", mmodel.UserEmail, mmodel.UserName, (int)mmodel.Status, (int)mmodel.UserType);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  userId,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(30), true,
                  userData,
                  FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                // Redirect back to original URL.
                Response.Redirect(FormsAuthentication.GetRedirectUrl(userId, true));

            }
        }
    }
}