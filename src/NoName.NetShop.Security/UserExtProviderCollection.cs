using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

namespace NoName.Security
{
    public class UserExtProviderCollection : ProviderCollection
    {
        public new UserExtProvider this[string name]
        {
            get { return (UserExtProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is UserExtProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }
}
