using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Configuration.Provider;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Text.RegularExpressions;

namespace NoName.Security
{
    class SqlMenuProvider:MenuProvider
    {
        private string _applicationName;
        private string _connectionStringName;
        private string _connectionString;
        private bool _isAppRootPath;

        private string _cacheKeyPrefix;
        private static ICacheManager _cache = CacheFactory.GetCacheManager();
        private static List<string> cachekeys = new List<string>();

        public override string Description
        {
            get
            {
                return base.Description;
            }
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

        public override bool IsAppRootPath
        {
            get
            {
                return _isAppRootPath;
            }
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
                name = "SqlMenuProvider";

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description",
                    "SQL Menu provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
                _applicationName = "/";

            config.Remove("applicationName");

            try
            {
                _isAppRootPath = bool.Parse(config["isapprootpath"]);
            }
            catch
            {
                _isAppRootPath = false;
            }
            config.Remove("isapprootpath");

            _cacheKeyPrefix = config["cachekeyprefix"];
            if (String.IsNullOrEmpty(_cacheKeyPrefix))
                _cacheKeyPrefix = _applicationName + "AspnetMenu";
            config.Remove("cachekeyprefix");

            // Initialize _connectionString
            _connectionStringName = config["connectionStringName"];

            if (String.IsNullOrEmpty(_connectionStringName))
                throw new ProviderException
                    ("Empty or missing connectionStringName");

            config.Remove("connectionStringName");

            if (WebConfigurationManager.ConnectionStrings[_connectionStringName] == null)
                throw new System.Configuration.Provider.ProviderException("Missing connection string");

            _connectionString = WebConfigurationManager.ConnectionStrings
                [_connectionStringName].ConnectionString;

            if (String.IsNullOrEmpty(_connectionString))
                throw new ProviderException("Empty connection string");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException
                        ("Unrecognized attribute: " + attr);
            }

        }


        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public string ConnectionStringName
        {
            get { return _connectionStringName; }
            set { _connectionStringName = value; }
        }

        /// <summary>
        /// 添加新菜单，及授权信息
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">是否强制覆盖具有相同基本URL菜单的授权</param>
        /// <returns>
        /// 0： 正常操作
        /// 1： 当前应用的父分类不存在
        /// 2： 当前应用中的URL已经被添加
        /// 3：  授权冲突，已存在相应基本URL的授权
        /// 4： 授权类型不正确
        /// 5： 输入的URL有错误
        /// 6：  当前应用不存在 
        ///</returns>
        public override int AddMenuItem(AspnetMenuItem menu,bool isForced)
        {
            string spname = "aspnet_Menu_Add";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
                String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@Url", DbType.String, menu.Url);
            db.AddInParameter(comm, "@Title", DbType.String, menu.Title);
            db.AddInParameter(comm, "@FatherId", DbType.String, menu.FatherId);
            db.AddInParameter(comm, "@ItemType", DbType.String, menu.ItemType);
            db.AddInParameter(comm, "@Description", DbType.String, menu.Description);
            db.AddInParameter(comm, "@Keywords", DbType.String, menu.Keywords);
            db.AddInParameter(comm,"@AuthType",DbType.Int16,menu.AuthType);
            db.AddInParameter(comm,"@Roles",DbType.String,String.Join(",",menu.Roles));
            db.AddInParameter(comm,"@IsForced",DbType.Int16,isForced?1:0);
            db.AddOutParameter(comm, "@MenuId", DbType.Int32, 4);
            db.ExecuteNonQuery(comm);
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            if (result == 0)
            {
                menu.MenuId = (int)db.GetParameterValue(comm, "@MenuId");
            }
            return result;
        }

        /// <summary>
        /// 处理菜单的url，要根据设定的菜单路径方式（应用相对路径或者绝对路径）处理传入的url地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string ProcessMenuUrl(string url,bool isUseAppPath)
        {
            if (url == null || url.Trim() == "")
                return null;

            string result  = url.Trim();

            if (isUseAppPath)
            {
                result = result.Replace("\\", "/");
                result = Regex.Replace(result, "/+", "/");
                if (result.StartsWith("/"))
                    result = "~" + result;
                if (!result.StartsWith("~/"))
                    result = "~/" + result;
            }
            else  // 使用绝对路径
            {
                result = result.Replace("\\", "/");
                result = Regex.Replace(result, "/+", "/");

                // 转换相对路径为绝对路径
                if (result.StartsWith("~/"))
                {
                    string apppath = System.Web.HttpContext.Current.Request.ApplicationPath;
                    if (!apppath.EndsWith("/"))
                        apppath += "/";
                    result = result.Replace("~/",apppath);
                }
                if (!result.StartsWith("/"))
                    result = "/" + result;
            }
            return result;
        }

        /// <summary>
        /// 更新菜单授权信息
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>
        /// 0： 正常操作
        /// 1： 当前应用的父分类不存在
        /// 2： 当前应用中的URL已经被添加
        /// 3：  授权冲突，已存在相应基本URL的授权
        /// 4： 授权类型不正确
        /// 5： 输入的URL有错误
        /// 6：  当前应用不存在 
        ///</returns>
        public override int UpdateMenuItem(AspnetMenuItem menu,bool isForced)
        {
            string spname = "aspnet_Menu_Update";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
               String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@MenuId", DbType.Int32, menu.MenuId);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@Url", DbType.String, menu.Url);
            db.AddInParameter(comm, "@Title", DbType.String, menu.Title);
            db.AddInParameter(comm, "@ItemType", DbType.String, menu.ItemType);
            db.AddInParameter(comm, "@Description", DbType.String, menu.Description);
            db.AddInParameter(comm, "@Keywords", DbType.String, menu.Keywords);
            db.AddInParameter(comm, "@AuthType", DbType.Int16, menu.AuthType);
            db.AddInParameter(comm, "@Roles", DbType.String, String.Join(",", menu.Roles));
            db.AddInParameter(comm, "@IsForced", DbType.Int16, isForced ? 1 : 0);
            db.ExecuteNonQuery(comm);
            return (int)db.GetParameterValue(comm, "@ReturnValue");
        }


        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="isForced">是否同时强制删除子目录</param>
        /// <returns></returns>
        public override bool DeleteMenuItem(int menuId,bool isForced)
        {
            string spname = "aspnet_Menu_Delete";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
               String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@MenuId", DbType.Int32, menuId);
             db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
             db.AddInParameter(comm, "@IsForced", DbType.Int16, isForced ? 1 : 0);
          db.ExecuteNonQuery(comm);
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            return result == 0;
        }

        /// <summary>
        /// 判断菜单是否存在
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public override bool IsExistsMenudItem(int menuId)
        {
            string spname = "aspnet_Menu_Exists";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
               String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@MenuId", DbType.Int32, menuId);
            db.ExecuteNonQuery(comm);
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            return result == 0;
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
        public override int ChangeMenusOfRole(string rolename, string menus)
        {
            string spname = "Aspnet_menu_GrantMenusToRole";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
                String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@RoleName", DbType.String, rolename);
            db.AddInParameter(comm, "@Menus", DbType.String, menus);
            db.ExecuteNonQuery(comm);
            return (int)db.GetParameterValue(comm, "@ReturnValue");
        }

        /// <summary>
        /// 更该管理员拥有的授权
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ：授权所有菜单（类型为3）给角色
        ///  为空：取消角色所有授权
        /// '1,2,3'： 授权所提供的菜单给角色，菜单类型授权类型为3
        /// </param>
        /// <returns></returns>
        public override int ChangeMenusOfAdmin(string userName, string menus)
        {
            string spname = "maAdminMenu_GrantMenusToUser";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
                String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@UserName", DbType.String, userName);
            db.AddInParameter(comm, "@Menus", DbType.String, menus);
            db.ExecuteNonQuery(comm);
            return (int)db.GetParameterValue(comm, "@ReturnValue");
        }
        /// <summary>
        /// 获得所有的菜单项:用于管理和维护
        /// </summary>
        /// <returns></returns>
        public override DataTable GetMenusForManager()
        {
            string spname = "aspnet_menu_GetMenusForManager";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            return db.ExecuteDataSet(comm).Tables[0];
        }

        /// <summary>
        /// 移动某个菜单到目标菜单下
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public override int MoveMenu(int sourceId, int destinationId)
        {
            string spname = "aspnet_Menu_Move";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@SourceId", DbType.Int32, sourceId);
            db.AddInParameter(comm, "@DestinationId", DbType.Int32, destinationId);
            db.ExecuteNonQuery(comm);
            return (int)db.GetParameterValue(comm, "@ReturnValue");
        }


        /// <summary>
        /// 获得角色所拥有的菜单权限，仅限于授权类型为3的菜单
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public override string[] GetMenusOfRole(string rolename)
        {
            string spname = "aspnet_Menu_GetMenusOfRoleSp";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@RoleName", DbType.String, rolename);
            db.AddOutParameter(comm,"@Menus",DbType.String,2000);
            db.ExecuteNonQuery(comm);
            string[] menus = null;
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            if (result == 0)
            {
                try
                {
                    string menustr = (string)db.GetParameterValue(comm, "@Menus");
                    if (!String.IsNullOrEmpty(menustr))
                    {
                        menus = menustr.Split(',');
                    }
                }
                catch { }
            }
            return menus;
        }

        /// <summary>
        /// 获得某个管理员可以分配的菜单
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public override string[] GetMenusOfAdmin(string adminID)
        {
            string spname = "maAdminMenu_GetMenusOfUser";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@UserName", DbType.String, adminID);
            db.AddOutParameter(comm, "@Menus", DbType.String, 2000);
            db.ExecuteNonQuery(comm);
            string[] menus = null;
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            if (result == 0)
            {
                try
                {
                    string menustr = (string)db.GetParameterValue(comm, "@Menus");
                    if (!String.IsNullOrEmpty(menustr))
                    {
                        menus = menustr.Split(',');
                    }
                }
                catch { }
            }
            return menus;

        }

        /// <summary>
        /// 获得菜单授权验证数据
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string,string> GetAllMenuRoleMaps()
        {
            string key = _cacheKeyPrefix + "_MenuRoleMaps";
            string apppath = System.Web.HttpContext.Current.Request.ApplicationPath;
            if (!apppath.EndsWith("/"))
                apppath += "/";

            ICacheManager cache = CacheFactory.GetCacheManager();
            Dictionary<string, string> maps = (Dictionary<string, string>)cache.GetData(key);

            if (maps == null)
            {
                maps = new Dictionary<string, string>();

                DataTable table = GetMenusForValidate();
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string baseurl = row["baseurl"].ToString().Trim().ToLower();
                        if (!_isAppRootPath)
                            baseurl = baseurl.Replace("~/",apppath);
                        maps.Add(baseurl, row["roles"].ToString());

                    }
                }
                SlidingTime slidingExpired = new SlidingTime(new TimeSpan(0, 2, 0, 0, 0));
                ICacheItemExpiration[] expiredList = { slidingExpired };
                if (!cachekeys.Contains(key))
                {
                    cachekeys.Add(key);
                }
                cache.Add(key, maps, CacheItemPriority.Normal, null, expiredList);
            }
            return maps;
        }

        /// <summary>
        /// 获得所有的菜单项:用于验证用户权限来使用，所有启用的非节点菜单
        /// 授权类型：AuthType 0:未启用 1：匿名用户可以访问 2：所有注册用户 3：特定用户角色 
        /// 4：拒绝访问
        /// </summary>
        /// <returns></returns>
        private DataTable GetMenusForValidate()
        {
            string spname = "aspnet_menu_GetMenusForValidate";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            return db.ExecuteDataSet(comm).Tables[0];
        }

        /// <summary>
        /// 获得菜单数据
        /// </summary>
        /// <returns></returns>
        public override DataTable GetMenusForSitemap()
        {
            string spname = "aspnet_menu_GetMenusForSitemap";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            DataTable table = db.ExecuteDataSet(comm).Tables[0];
            return table;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override AspnetMenuItem GetMenuItem(int MenuId)
        {
            string spname = "aspnet_Menu_GetModel";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
               String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@MenuId", DbType.Int32, MenuId);
            DataSet ds = db.ExecuteDataSet(comm);

            AspnetMenuItem model = new AspnetMenuItem();

            model.MenuId = MenuId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["FatherId"].ToString() != "")
                {
                    model.FatherId = int.Parse(ds.Tables[0].Rows[0]["FatherId"].ToString());
                }
                model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                if (ds.Tables[0].Rows[0]["ItemType"].ToString() != "")
                {
                    model.ItemType = int.Parse(ds.Tables[0].Rows[0]["ItemType"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                if (ds.Tables[0].Rows[0]["AuthType"].ToString() != "")
                {
                    model.AuthType = int.Parse(ds.Tables[0].Rows[0]["AuthType"].ToString());
                }
                model.Roles = ds.Tables[0].Rows[0]["Roles"].ToString().Split(',');
                return model;
            }
            else
            {
                return null;
            }
        }

        // 释放相关的缓存
        public override void ResetCache()
        {
            foreach (string key in cachekeys)
            {
                if (_cache.Contains(key))
                {
                    _cache.Remove(key);
                }
            }
        }

        /// <summary>
        /// 获得用户可管理的Roles
        /// </summary>
        /// <param name="amindID"></param>
        /// <returns></returns>
        public override string[] GetRolesOfAdmin(string amindID)
        {
            string spname = "maAdminRole_GetRoleOfUser";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@Username", DbType.String, amindID);
            db.AddOutParameter(comm, "@Roles", DbType.String, 2000);
            db.ExecuteNonQuery(comm);
            string[] roles = null;
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            if (result == 0)
            {
                try
                {
                    string rolestr = (string)db.GetParameterValue(comm, "@Roles");
                    if (!String.IsNullOrEmpty(rolestr))
                    {
                        roles = rolestr.Split(',');
                    }
                }
                catch { }
            }
            return roles;
        }

        public override int ChangeRolesOfAdmin(string username, string roles)
        {
            string spname = "maAdminRole_GrantRolesToUser";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
                String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@UserName", DbType.String, username);
            db.AddInParameter(comm, "@Roles", DbType.String, roles);
            db.ExecuteNonQuery(comm);
            return (int)db.GetParameterValue(comm, "@ReturnValue");
        }
    }
}
