using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Specialized;

namespace NoName.NetShop.CMS.Data
{
    public interface IDataAcquirer
    {
        XmlDocument GetData(NameValueCollection Parameter);
    }
}