using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NoName.NetShop.Common
{
    public class ActionResult
    {
        public bool Result { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }

        public string ToJson()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(this);
        }
    }
}
