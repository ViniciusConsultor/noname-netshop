using System;
using System.Collections.Generic;
using System.Text;
using System.Data.ProviderBase;
using System.Web.Configuration;
using System.Data;
using System.Configuration.Provider;
using System.Configuration;

namespace NoName.Security
{
    public class AspnetMenu
    {
        private static MenuProvider _provider = null;
        private static MenuProviderCollection _providers = null;
        private static object _lock = new object();

        static AspnetMenu()
        {
            LoadProviders();
        }

        public MenuProvider Provider
        {
            get { return _provider; }
        }

        public MenuProviderCollection Providers
        {
            get { return _providers; }
        }

        public static bool IsAppRootPath
        {
            get { return _provider.IsAppRootPath; }
        }

        /// <summary>
        /// ����µĲ˵���
        /// </summary>
        public static int AddMenuItem(AspnetMenuItem menu,bool isForced)
        {
            return  _provider.AddMenuItem(menu, isForced);
        }
        /// <summary>
        /// ����˵���
        /// </summary>
        public static int UpdateMenuItem(AspnetMenuItem menu, bool isForced)
        {
            return _provider.UpdateMenuItem(menu, isForced);
        }

        /// <summary>
        /// ɾ���˵���
        /// </summary>
        public static bool DeleteMenuItem(int menuId,bool isForced)
        {
            return _provider.DeleteMenuItem(menuId,isForced);
       }

        /// <summary>
        /// ��ò˵���
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static AspnetMenuItem GetMenuItem(int menuId)
        {
            return _provider.GetMenuItem(menuId);
        }

        /// <summary>
        /// ���ý�ɫ����Ȩ
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ����Ȩ���в˵�������Ϊ3������ɫ
        ///  Ϊ�գ�ȡ����ɫ������Ȩ
        /// '1,2,3'�� ��Ȩ���ṩ�Ĳ˵�����ɫ���˵�������Ȩ����Ϊ3
        /// </param>
        /// <returns></returns>
        public static int ChangeMenusOfRole(string rolename, string menus)
        {
            return _provider.ChangeMenusOfRole(rolename, menus);
        }

        /// <summary>
        /// ���ù���Ա��ӵ�еĲ˵�
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ����Ȩ���в˵�������Ϊ3������ɫ
        ///  Ϊ�գ�ȡ����ɫ������Ȩ
        /// '1,2,3'�� ��Ȩ���ṩ�Ĳ˵�����ɫ���˵�������Ȩ����Ϊ3
        /// </param>
        /// <returns></returns>
        public static int ChangeMenusOfAdmin(string username, string menus)
        {
            return _provider.ChangeMenusOfAdmin(username, menus);
        }

        /// <summary>
        /// ������еĲ˵���:���ڹ����ά��
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMenusForManager()
        {
            return _provider.GetMenusForManager();
        }


        /// <summary>
        /// �ƶ��˵�
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public static int MoveMenu(int sourceId, int destinationId)
        {
            return _provider.MoveMenu(sourceId, destinationId);
        }

        /// <summary>
        /// ������еĲ˵���Ȩ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllMenuRoleMaps()
        {
            return _provider.GetAllMenuRoleMaps();
        }

        /// <summary>
        /// ���û��棬��ʵΪ�Ƴ����棬����ʱ���¼���
        /// </summary>
        public static void ResetCache()
        {
            _provider.ResetCache();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] GetMenusOfRole(string rolename)
        {
            return _provider.GetMenusOfRole(rolename);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] GetMenusOfAdmin(string userID)
        {
            return _provider.GetMenusOfAdmin(userID);
        }

        public static string[] GetRolesOfAdmin(string userID)
        {
            return _provider.GetRolesOfAdmin(userID);
        }

        public static int ChangeRolesOfAdmin(string userID, string roles)
        {
            return _provider.ChangeRolesOfAdmin(userID, roles);
        }

        /// <summary>
        /// ��ò˵�����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMenusForSitemap()
        {
            return _provider.GetMenusForSitemap();
        }

        private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        MenuProviderSection section = (MenuProviderSection)ConfigurationManager.GetSection("MenuProvider");
                        if (section == null)
                            throw new ConfigurationErrorsException("�������ļ���û�ҵ���MenuProvider���ڵ�");

                        SqlMenuProvider pro = new SqlMenuProvider();

                        _providers = new MenuProviderCollection();
                            ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(MenuProvider));

                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("û���ҵ���Ӧ�� MenuProvider");

                    }
                }
            }
        }

    }
}
