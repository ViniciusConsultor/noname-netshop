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
        /// �洢�û���չ��Ϣ
        /// </summary>
        public abstract bool Save(AspnetUserExtInfo user);
        /// <summary>
        /// ��ȡ�û���չ��Ϣ
        /// </summary>
        public abstract AspnetUserExtInfo GetModel(string username);
        /// <summary>
        /// ��ȡ�û���չ��Ϣ�б�
        /// </summary>
        public abstract List<AspnetUserExtInfo> GetList();
    }
}
