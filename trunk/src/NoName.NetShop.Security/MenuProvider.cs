using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;
using System.Data;

namespace NoName.Security
{
    public abstract class MenuProvider:ProviderBase
    {
        public abstract string ApplicationName { get; set; }

        public abstract bool IsAppRootPath { get;}
        /// <summary>
        /// 添加新菜单，及授权信息
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">是否强制覆盖具有相同基本URL菜单的授权</param>
        /// <returns></returns>
        public abstract int AddMenuItem(AspnetMenuItem menu, bool isForced);
        /// <summary>
        /// 更新菜单授权信息
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">是否强制覆盖具有相同基本URL菜单的授权</param>
        /// <returns></returns>
        public abstract int UpdateMenuItem(AspnetMenuItem menu, bool isForced);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="isForced">是否同时强制删除子目录</param>
        /// <returns></returns>
        public abstract bool DeleteMenuItem(int menuId, bool isForced);

        /// <summary>
        /// 判断菜单是否存在
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public abstract bool IsExistsMenudItem(int menuId);

        /// <summary>
        /// 获得菜单项
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public abstract AspnetMenuItem GetMenuItem(int menuId);

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
        public abstract int ChangeMenusOfRole(string rolename, string menus);

       /// <summary>
        /// 更该某个管理员的授权
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ：授权所有菜单（类型为3）给角色
        ///  为空：取消角色所有授权
        /// '1,2,3'： 授权所提供的菜单给角色，菜单类型授权类型为3
        /// </param>
        /// <returns></returns>
        public abstract int ChangeMenusOfAdmin(string username, string menus);


        /// <summary>
        /// 获得所有的菜单项:用于管理和维护
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetMenusForManager();


        /// <summary>
        /// 移动某个菜单到目标菜单下
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public abstract int MoveMenu(int sourceId, int destinationId);


        /// <summary>
        /// 获得菜单授权验证数据
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, string> GetAllMenuRoleMaps();
         
        /// <summary>
        /// 重置菜单提供程序所依赖的缓存数据
        /// </summary>
        public abstract void ResetCache();

        /// <summary>
        /// 获得角色所拥有的菜单权限，仅限于授权类型为3的菜单
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public abstract string[] GetMenusOfRole(string rolename);

        /// <summary>
        /// 获得菜单数据
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetMenusForSitemap();

        /// <summary>
        /// 获得某个管理员可以分配的菜单
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public abstract string[] GetMenusOfAdmin(string adminID);

        /// <summary>
        /// 获得用户管理的角色
        /// </summary>
        /// <param name="amindID"></param>
        /// <returns></returns>
        public abstract string[] GetRolesOfAdmin(string amindID);

        /// <summary>
        /// 更改用户管理的角色
        /// </summary>
        /// <param name="username"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public abstract int ChangeRolesOfAdmin(string username, string roles);

    }
}
