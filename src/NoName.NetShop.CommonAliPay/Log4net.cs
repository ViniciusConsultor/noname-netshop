using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;
using log4net.Config;
using System.IO;
/// <summary>
/// 配置Log4net
/// </summary>
internal class Log4net
{
    public static readonly ILog log = LogManager.GetLogger("MeetingProxy");
    static Log4net()
    {
        string path;
        if (HttpContext.Current != null)
        {
            path = HttpContext.Current.Server.MapPath("log4net.config");
        }
        else
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
        }
        DOMConfigurator.Configure(new FileInfo(path));

    }
}
