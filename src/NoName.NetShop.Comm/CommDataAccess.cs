﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.Common
{
    public class CommDataAccess
    {
        /// <summary>
        /// 数据库读连接
        /// </summary>
        protected static Database DbReader = DatabaseFactory.CreateDatabase("PostcardDbReaderConn");
        /// <summary>
        /// 数据库写链接
        /// </summary>
        protected static Database DbWriter = DatabaseFactory.CreateDatabase("PostcardDbWriterConn");
    }
}
