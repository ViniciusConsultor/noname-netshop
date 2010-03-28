using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.Specialized;
using NoName.NetShop.Common;
using NoName.NetShop.IMMessage;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.SessionState;
using System.Web.Security;

namespace NoName.NetShop.BackFlat.commapi
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ImMessage : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string result = String.Empty;

            NameValueCollection nv = GetParas(context);

            string action = String.IsNullOrEmpty(nv["action"]) ? "" : nv["action"].ToLower();
            string prefix = String.IsNullOrEmpty(nv["varname"]) ? "" : nv["varname"] + "=";

            switch (action)
            {
                case "getmsglist":
                    result = GetMsgList(context);
                    break;
                case "getmessage":
                    result = GetMessage(context);
                    break;

            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(prefix + result);
        }

        private string GetMessage(HttpContext context)
        {
            int msgId;
            string result = String.Empty;
            if (!int.TryParse(context.Request["msgId"],out msgId))
            {
                msgId = 0;
            }
            MessageBll mbll = new MessageBll();
            MessageModel model = mbll.GetModel(msgId);
            if (model != null &&  model.UserType==1
                && ((model.UserId == context.User.Identity.Name && model.MsgType==0)
                || (context.User.IsInRole(model.UserId) && model.MsgType==2)
                || model.MsgType==1))
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                result = jss.Serialize(model);
                if (model.MsgType == 0)
                    mbll.SetIsReaded(model.MsgId);
            }
            return result;
        }

        private string GetMsgList(HttpContext context)
        {
            MessageBll mbll = new MessageBll();
            string[] roles = Roles.GetRolesForUser();
            List<MessageModel> list = mbll.GetAllList(context.User.Identity.Name,roles,1);

            StringBuilder result = new StringBuilder();
            StringWriter sw = new StringWriter(result);
            JsonWriter writer = new JsonWriter(sw);

            writer.Formatting = Formatting.None;
            //writer.WriteStartObject();
            writer.WriteStartArray();
            foreach (MessageModel item in list)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("msgid");
                writer.WriteValue(item.MsgId);
                writer.WritePropertyName("subject");
                writer.WriteValue(item.Subject);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            //writer.WriteEndObject();
            writer.Close();
            return result.ToString();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 辅助方法

        private NameValueCollection GetParas(HttpContext context)
        {
            NameValueCollection nv = null;
            if (context.Request.RequestType == "GET")
            {
                nv = context.Request.QueryString;
            }
            else
            {
                nv = context.Request.Form;
            }
            return nv;
        }

        /// <summary>
        /// 获取部分command执行结果的json数据
        /// 格式为：{'result':'true','code':'001','msg':'false'}
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorcode"></param>
        /// <param name="errormessage"></param>
        /// <returns></returns>
        private string GetJsonResult(bool result, string code, string message)
        {
            ActionResult retval = new ActionResult();
            retval.Result = result;
            retval.Code = code;
            retval.Message = message;
            return retval.ToJson();
        }
        #endregion
    }
}
