using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace NoName.NetShop.Common
{
    public class Loggers
    {
        public static ILog PublishLogger
        {
            get { return LogManager.GetLogger("PublishLogger"); }
        }


        public static ILog SearchLogger
        {
            get { return LogManager.GetLogger("SearchLogger"); }
        }
    }
}