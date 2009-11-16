using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.Common
{
    public static class DBFacroty
    {
        /// <summary>
        /// 数据库读连接
        /// </summary>
        public static Database DbReader = DatabaseFactory.CreateDatabase("NetShopDbReaderConn");
        /// <summary>
        /// 数据库写链接
        /// </summary>
        public static Database DbWriter = DatabaseFactory.CreateDatabase("NetShopDbWriterConn");

    }
}
