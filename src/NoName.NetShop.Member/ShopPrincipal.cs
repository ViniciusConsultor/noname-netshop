using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace NoName.NetShop.Member
{
    public class ShopPrincipal:IPrincipal
    {
        private ShopIdentity identity;
        private List<string> roles;
        #region IPrincipal 成员

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return roles.Exists(c => c == role);
        }

        public ShopPrincipal(ShopIdentity id)
        {
            identity = id;
        }

        #endregion
    }
}
