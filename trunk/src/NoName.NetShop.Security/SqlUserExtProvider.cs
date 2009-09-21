using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System.Configuration.Provider;
using System.Web.Configuration;

namespace NoName.Security
{
    class SqlUserExtProvider:UserExtProvider
    {
        private string _applicationName;
        private string _connectionStringName;

        private string _cacheKeyPrefix;
        private static ICacheManager _cache = CacheFactory.GetCacheManager();

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

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (String.IsNullOrEmpty(name))
                name = "SqlUserExtProvider";

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description",
                    "SQL User ExtentInfo provider");
            }

            base.Initialize(name, config);

            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
                _applicationName = "/";

            config.Remove("applicationName");

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

        public override bool Save(AspnetUserExtInfo user)
        {
            string spname = "aspnet_UserExtentInfo_SaveUser";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@UserName", DbType.String, user.UserName);
            db.AddInParameter(comm,"@TrueName",DbType.String,user.TrueName);
            db.AddInParameter(comm,"@IdCard",DbType.String,user.IdCard);
            db.AddInParameter(comm,"@TelePhone",DbType.String,user.TelePhone);
            db.AddInParameter(comm,"@Mobile",DbType.String,user.Mobile);
            db.AddInParameter(comm,"@QQ",DbType.String,user.QQ);
            db.AddInParameter(comm,"@MSN",DbType.String,user.MSN);
            db.AddInParameter(comm,"@Email",DbType.String,user.Email);
            db.ExecuteNonQuery(comm);
            int result = (int)db.GetParameterValue(comm, "@ReturnValue");
            return result == 0;

        }

        public override AspnetUserExtInfo GetModel(string username)
        {
            string spname = "aspnet_UserExtentInfo_GetModel";
            Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
              String.Empty, DataRowVersion.Default, null);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
            db.AddInParameter(comm, "@UserName", DbType.String,username);
            DataSet ds = db.ExecuteDataSet(comm);
            AspnetUserExtInfo model = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = BuildUserExtInfo(ds.Tables[0].Rows[0]);
            }
            return model;
        }

        public override List<AspnetUserExtInfo> GetList()
        {
            string key = _cacheKeyPrefix + "_UserExtList";

            List<AspnetUserExtInfo> list = (List<AspnetUserExtInfo>)_cache.GetData(key);

            if (list == null)
            {
                list = new List<AspnetUserExtInfo>();
                string spname = "aspnet_UserExtentInfo_GetList";
                Database db = DatabaseFactory.CreateDatabase(_connectionStringName);
                DbCommand comm = db.GetStoredProcCommand(spname);
                db.AddParameter(comm, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue,
                  String.Empty, DataRowVersion.Default, null);
                db.AddInParameter(comm, "@ApplicationName", DbType.String, _applicationName);
                DataSet ds = db.ExecuteDataSet(comm);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(BuildUserExtInfo(row));
                }
                SlidingTime slidingExpired = new SlidingTime(new TimeSpan(0, 2, 0, 0, 0));
                ICacheItemExpiration[] expiredList = { slidingExpired };

                _cache.Add(key, list, CacheItemPriority.Normal, null, expiredList);
            }
            return list;
        }

        private AspnetUserExtInfo BuildUserExtInfo(DataRow row)
        {
            AspnetUserExtInfo model = new AspnetUserExtInfo();
            model.UserName = row["username"].ToString();
            model.TrueName = row["TrueName"].ToString();
            model.IdCard = row["IdCard"].ToString();
            model.TelePhone = row["TelePhone"].ToString();
            model.Mobile = row["Mobile"].ToString();
            model.QQ = row["QQ"].ToString();
            model.MSN = row["MSN"].ToString();
            model.Email = row["Email"].ToString();
            return model;
        }
    }
}
