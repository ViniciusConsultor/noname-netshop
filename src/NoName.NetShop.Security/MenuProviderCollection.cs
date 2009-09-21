using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

namespace NoName.Security
{
    public class MenuProviderCollection :ProviderCollection
    {
        public new MenuProvider this[string name]
        {
            get { return (MenuProvider)base[name]; }
        }

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (!(provider is MenuProvider))
                throw new ArgumentException
                    ("Invalid provider type", "provider");

            base.Add(provider);
        }
    }



}
