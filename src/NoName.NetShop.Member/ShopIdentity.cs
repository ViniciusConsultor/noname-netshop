using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using NoName.NetShop.Member.Model;

namespace NoName.NetShop.Member
{
    public class ShopIdentity : IIdentity
    {
        private FormsAuthenticationTicket ticket;
        private HttpContext context = HttpContext.Current;
        private string userEmail;
        private string userId;
        private string userName;
        private MemberStatus userStatus;
        private MemberType userType;
        private UserLevel userLevel;

        public string UserEmail { get { return userEmail; } }
        public string UserId { get { return userId; } }
        public string UserName { get { return userName; } }
        public MemberStatus UserStatus { get { return userStatus; } }
        public MemberType UserType { get { return userType; } }
        public UserLevel UserLevel { get { return userLevel; } }

        public ShopIdentity(FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
            string[] ud = ticket.UserData.Split(':');

            userId = ticket.Name;
            userEmail = ud[0];
            userName = ud[1];
            userStatus = (MemberStatus)(int.Parse(ud[2]));
            userType = (MemberType)(int.Parse(ud[3]));
            userLevel = (UserLevel)(int.Parse(ud[4]));
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get
            {
                return ticket.Name;
            }
        }

        public FormsAuthenticationTicket Ticket
        {
            get { return ticket; }
        }

    }
}
