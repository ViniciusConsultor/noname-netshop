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
        /// ����²˵�������Ȩ��Ϣ
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="isForced">�Ƿ�ǿ�Ƹ��Ǿ�����ͬ����URL�˵�����Ȩ</param>
        /// <returns>
        /// 0�� ��������
        /// 1�� ��ǰӦ�õĸ����಻����
        /// 2�� ��ǰӦ���е�URL�Ѿ������
        /// 3��  ��Ȩ��ͻ���Ѵ�����Ӧ����URL����Ȩ
        /// 4�� ��Ȩ���Ͳ���ȷ
        /// 5�� �����URL�д���
        /// 6��  ��ǰӦ�ò����� 
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
        /// ����˵���url��Ҫ�����趨�Ĳ˵�·����ʽ��Ӧ�����·�����߾���·�����������url��ַ
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
            else  // ʹ�þ���·��
            {
                result = result.Replace("\\", "/");
                result = Regex.Replace(result, "/+", "/");

                // ת�����·��Ϊ����·��
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
        /// ���²˵���Ȩ��Ϣ
        /// </summary>
        /// <param name="menu"></param>
        /// <returns>
        /// 0�� ��������
        /// 1�� ��ǰӦ�õĸ����಻����
        /// 2�� ��ǰӦ���е�URL�Ѿ������
        /// 3��  ��Ȩ��ͻ���Ѵ�����Ӧ����URL����Ȩ
        /// 4�� ��Ȩ���Ͳ���ȷ
        /// 5�� �����URL�д���
        /// 6��  ��ǰӦ�ò����� 
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
        /// ɾ���˵�
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="isForced">�Ƿ�ͬʱǿ��ɾ����Ŀ¼</param>
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
        /// �жϲ˵��Ƿ����
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
        /// ���ý�ɫ����Ȩ
        /// </summary>
        /// <param name="rolename"></param>
        /// <param name="menus">
        ///  'all' ����Ȩ���в˵�������Ϊ3������ɫ
        ///  Ϊ�գ�ȡ����ɫ������Ȩ
        /// '1,2,3'�� ��Ȩ���ṩ�Ĳ˵�����ɫ���˵�������Ȩ����Ϊ3
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
        /// ������еĲ˵���:���ڹ����ά��
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
        /// �ƶ�ĳ���˵���Ŀ��˵���
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
        /// ��ý�ɫ��ӵ�еĲ˵�Ȩ�ޣ���������Ȩ����Ϊ3�Ĳ˵�
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
        /// ��ò˵���Ȩ��֤����
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
        /// ������еĲ˵���:������֤�û�Ȩ����ʹ�ã��������õķǽڵ�˵�
        /// ��Ȩ���ͣ�AuthType 0:δ���� 1�������û����Է��� 2������ע���û� 3���ض��û���ɫ 
        /// 4���ܾ�����
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
        /// ��ò˵�����
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
        /// �õ�һ������ʵ��
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

        // �ͷ���صĻ���
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

    }
}
