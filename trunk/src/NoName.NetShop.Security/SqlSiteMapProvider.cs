using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Configuration.Provider;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System.Security.Permissions;
using System.Data.Common;


namespace NoName.Security
{
    public class SqlSiteMapProvider : StaticSiteMapProvider
    {

        private SiteMapNode rootNode = null;
        private string connectionStringName;
        private bool initialized = false;
        private string applicationName;

        public SqlSiteMapProvider() { }

        public virtual bool IsInitialized
        {
            get
            {
                return initialized;
            }
        }

        public override SiteMapNode RootNode
        {
            get
            {
                if (rootNode == null)
                    rootNode = BuildSiteMap();
                return rootNode;
            }
        }
        protected override SiteMapNode GetRootNodeCore()
        {
            if (rootNode == null)
                rootNode = BuildSiteMap();
            return rootNode;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (IsInitialized)
                return;

            base.Initialize(name, config);

            connectionStringName = config["connectionStringName"];

            if (null == connectionStringName || connectionStringName.Length == 0)
                throw new Exception("The connection string was not found.");
            config.Remove("connectionStringName");

            applicationName = config["applicationName"];
            if (null == applicationName || applicationName.Length == 0)
                applicationName = "/";
            config.Remove("applicationName");

            // SiteMapProvider processes the securityTrimmingEnabled
            // attribute but fails to remove it. Remove it now so we can
            // check for unrecognized configuration attributes.
            if (config["securityTrimmingEnabled"] != null)
            {
                config.Remove("securityTrimmingEnabled");
            }

            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException
                        ("Unrecognized attribute: " + attr);
            }

            initialized = true;
        }

        protected override void Clear()
        {
            lock (this)
            {
                rootNode = null;
                base.Clear();
            }
        }

        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {

                if (!IsInitialized)
                {
                    throw new Exception("BuildSiteMap called incorrectly.");
                }

                if (null == rootNode)
                {
                    // Start with a clean slate
                    Clear();

                    // Select the root node of the site map from Microsoft Access.


                    DataTable table = GetMenuDataSource();

                    if (table.Rows.Count > 0)
                    {
                        rootNode = new SiteMapNode(this, "0");
                        // 下面一行非常重要，否则不能够正确显示菜单
                         AddNode(rootNode,null);
                        BuildSonMenuNode(table, rootNode);
                    }
                    else
                    {
                        return null;
                    }
                }

                return rootNode;
            }

        }

        private void BuildSonMenuNode(DataTable table, SiteMapNode fatherNode)
        {
            DataRow[] rows = table.Select("fatherId=" + fatherNode.Key,"menuid desc");
            for(int i=0;i<rows.Length;i++)
            {
                SiteMapNode node = new SiteMapNode(this, rows[i]["MenuId"].ToString());
                node.Description = rows[i]["Description"].ToString();
                node.Roles = rows[i]["Roles"].ToString().Split(',');
                node.Title = rows[i]["Title"].ToString();
                node.Url = rows[i]["Url"].ToString();
                AddNode(node,fatherNode);
                BuildSonMenuNode(table, node);
            }

        }

        /// <summary>
        /// 获得菜单数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetMenuDataSource()
        {
            string spname = "aspnet_menu_GetMenusForSitemap";
            Database db = DatabaseFactory.CreateDatabase(connectionStringName);
            DbCommand comm = db.GetStoredProcCommand(spname);
            db.AddInParameter(comm, "@ApplicationName", DbType.String, applicationName);
            DataTable table = db.ExecuteDataSet(comm).Tables[0];
            return table;
        }

    }

}
