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


        private int userId;
        private string nickName;
        private MemberStatus userStatus;
        private MemberType userType;

        public string UserEmail { get { return userEmail; } }
        public int UserId { get { return userId; } }
        public string NickName { get { return nickName; } }
        public MemberStatus UserStatus { get { return userStatus; } }
        public MemberType UserType { get { return userType; } }

        public ShopIdentity(FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
            string[] ud = ticket.UserData.Split(':');

            userEmail = ticket.Name;
            userId = int.Parse(ud[0]);
            nickName = ud[1];
            userStatus = (MemberStatus)(int.Parse(ud[2]));
            userType = (MemberType)(int.Parse(ud[3]));
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
