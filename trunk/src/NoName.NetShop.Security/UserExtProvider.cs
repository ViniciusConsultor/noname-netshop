using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;

namespace NoName.Security
{
    public abstract class UserExtProvider : ProviderBase
    {
        public abstract string ApplicationName { get; set; }
        /// <summary>
        /// 存储用户扩展信息
        /// </summary>
        public abstract bool Save(AspnetUserExtInfo user);
        /// <summary>
        /// 获取用户扩展信息
        /// </summary>
        public abstract AspnetUserExtInfo GetModel(string username);
        /// <summary>
        /// 获取用户扩展信息列表
        /// </summary>
        public abstract List<AspnetUserExtInfo> GetList();
    }
}
