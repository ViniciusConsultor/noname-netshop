using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat
{
    public class AuthBasePage : BasePage
    {
        public ShopIdentity CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated && User.Identity is ShopIdentity)
                {
                    return User.Identity as ShopIdentity;
                }
                else 
                    return null;
            }

        }
    }
}