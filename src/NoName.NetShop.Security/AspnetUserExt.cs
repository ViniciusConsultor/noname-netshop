using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

namespace NoName.Security
{
    public class AspnetUserExt
    {
        private static UserExtProvider _provider = null;
        private static UserExtProviderCollection _providers = null;
        private static object _lock = new object();

        static AspnetUserExt()
        {
            LoadProviders();
        }

        public UserExtProvider Provider
        {
            get { return _provider; }
        }

        public UserExtProviderCollection Providers
        {
            get { return _providers; }
        }

        private static void LoadProviders()
        {
            if (_provider == null)
            {
                lock (_lock)
                {
                    if (_provider == null)
                    {
                        UserExtProviderSection section = (UserExtProviderSection)ConfigurationManager.GetSection("UserExtProvider");
                        if (section == null)
                            throw new ConfigurationErrorsException("�������ļ���û�ҵ���MenuProvider���ڵ�");

                        _providers = new UserExtProviderCollection();
                        ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(UserExtProvider));
                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("û���ҵ���Ӧ�� MenuProvider");

                    }
                }
            }
        }


        public static AspnetUserExtInfo GetUserExt(string username)
        {
            return _provider.GetModel(username);
        }

        public static bool SaveUserExt(AspnetUserExtInfo user)
        {
            return _provider.Save(user);
        }

        public static List<AspnetUserExtInfo> GetAllUserExt()
        {
            return _provider.GetList();
        }

    }
}
