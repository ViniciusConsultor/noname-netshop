using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.Specialized;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.CMS.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.CMS.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class TagContentHandler : IHttpHandler
    {
        private int TagID
        {
            get;
            set;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["tagid"])) TagID = Convert.ToInt32(context.Request["tagid"]);

            NameValueCollection Parameter = TagControler.GetTagParameter(TagID, context.Request);

            context.Response.Write(TagControler.GenerateDefaultCode(TagID, Parameter));

            TagParameterModel tagParameter = new TagParameterModel();

            tagParameter.PageID = Convert.ToInt32(context.Request["pageid"]);
            tagParameter.ServerID = Convert.ToString(context.Request["sid"]);
            tagParameter.TagID = TagID;
            tagParameter.Parameter = HttpUtil.GetParameterString(Parameter);

            TagControler.TagParameterImport(tagParameter);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
