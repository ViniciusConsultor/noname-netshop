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
        /// 添加新的菜单项
        /// </summary>
        public static int AddMenuItem(AspnetMenuItem menu,bool isForced)
        {
            return  _provider.AddMenuItem(menu, isForced);
        }
        /// <summary>
        /// 保存菜单项
        /// </summary>
        public static int UpdateMenuItem(AspnetMenuItem menu, bool isForced)
        {
            return _provider.UpdateMenuItem(menu, isForced);
        }

        /// <summary>
        /// 删除菜单项
        /// </summary>
        public static bool DeleteMenuItem(int menuId,bool isForced)
        {
            return _provider.DeleteMenuItem(menuId,isForced);
       }

        /// <summary>
        /// 获得菜单项
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static AspnetMenuItem GetMenuItem(int menuId)
        {
            return _provider.GetMenuItem(menuId);
        }

        /// <summary>
        /// 更该角色的授权
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ：授权所有菜单（类型为3）给角色
        ///  为空：取消角色所有授权
        /// '1,2,3'： 授权所提供的菜单给角色，菜单类型授权类型为3
        /// </param>
        /// <returns></returns>
        public static int ChangeMenusOfRole(string rolename, string menus)
        {
            return _provider.ChangeMenusOfRole(rolename, menus);
        }

        /// <summary>
        /// 获得所有的菜单项:用于管理和维护
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMenusForManager()
        {
            return _provider.GetMenusForManager();
        }


        /// <summary>
        /// 移动菜单
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public static int MoveMenu(int sourceId, int destinationId)
        {
            return _provider.MoveMenu(sourceId, destinationId);
        }

        /// <summary>
        /// 获得所有的菜单授权信息
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllMenuRoleMaps()
        {
            return _provider.GetAllMenuRoleMaps();
        }

        /// <summary>
        /// 重置缓存，其实为移除缓存，访问时重新加载
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
        /// 获得菜单数据
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
                            throw new ConfigurationErrorsException("在配置文件中没找到“MenuProvider”节点");

                        SqlMenuProvider pro = new SqlMenuProvider();

                        _providers = new MenuProviderCollection();
                            ProvidersHelper.InstantiateProviders(section.Providers, _providers, typeof(MenuProvider));

                        _provider = _providers[section.DefaultProvider];

                        if (_provider == null)
                            throw new ProviderException
                                ("没有找到对应的 MenuProvider");

                    }
                }
            }
        }

    }
}
