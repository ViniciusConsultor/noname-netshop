using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.Security
{
    class UserExtProviderSection:ConfigurationSection
    {
            [ConfigurationProperty("providers")]
            public ProviderSettingsCollection Providers
            {
                get { return (ProviderSettingsCollection)base["providers"]; }
            }

            [StringValidator(MinLength = 1)]
            [ConfigurationProperty("defaultProvider",
               DefaultValue = "SqlUserExtProvider")]
            public string DefaultProvider
            {
                get { return (string)base["defaultProvider"]; }
                set { base["defaultProvider"] = value; }
            }

    }
}
