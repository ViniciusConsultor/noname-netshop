using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Data;
using NoName.NetShop.News.Model;
using NoName.NetShop.News.BLL;
using NoName.NetShop.Comment;
using NoName.NetShop.Common;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace NoName.NetShop.ForeFlat.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class NewsHandler : AuthBasePage, IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            if (String.IsNullOrEmpty(context.Request["action"]))
            {
                context.Response.Write(GetJsonResult(false, "参数不完整！"));
                return;
            }

            string Action = context.Request["action"];
            switch (Action)
            {
                case "commentlist":
                    GetCommentList(context);
                    break;
                case "getevaluation":
                    GetEvaluation(context);
                    break;
                case "addevaluation":
                    AddEvaluation(context);
                    break;
                default:
                    context.Response.Write(GetJsonResult(false, "参数不完整！"));
                    break;
            }
        }

        private void GetCommentList(HttpContext CurrentContext)
        {
            CommentBll bll = new CommentBll();
            int NewsID = Convert.ToInt32(CurrentContext.Request["nid"]);
            if (NewsID == 0)
            {
                CurrentContext.Response.Write(GetJsonResult(false, "参数错误！"));
                return;
            }

            DataTable dt = bll.GetList(AppType.News, NewsID);

            StringBuilder result = new StringBuilder();
            StringWriter sw = new StringWriter(result);
            JsonWriter writer = new JsonWriter(sw);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartArray();
            foreach (DataRow row in dt.Rows)
            {
                writer.WriteStartObject();

                WriteJsonKeyValue(writer, "userid", row["userid"].ToString());
                WriteJsonKeyValue(writer, "content", row["content"].ToString());
                WriteJsonKeyValue(writer, "createtime", Convert.ToDateTime(row["createtime"]).ToString("yyyy-MM-dd HH:mm:ss"));

                writer.WriteEndObject(); 
            }
            writer.WriteEndArray();
            writer.Close();

            CurrentContext.Response.Write("(" + result.ToString() + ")");
        }

        private void AddEvaluation(HttpContext CurrentContext)
        {
            if (CurrentUser == null)
            {
                CurrentContext.Response.Write(GetJsonResult(false, "请先登录！"));
                return;
            }

            NewsEvaluationModelBll bll = new NewsEvaluationModelBll();
            int NewsID = Convert.ToInt32(CurrentContext.Request["nid"]);
            int Value = Convert.ToInt32(CurrentContext.Request["val"]);

            if (NewsID == 0 || Value == 0)
            {
                CurrentContext.Response.Write(GetJsonResult(false, "参数错误！"));
                return;
            }
            if(bll.Exists(NewsID,GetUserID()))
            {
                CurrentContext.Response.Write(GetJsonResult(false, "您已经评价过了，谢谢！"));
                return;
            }

            try
            {
                NewsEvaluationModel model = new NewsEvaluationModel()
                {
                    NewsID = NewsID,
                    UserID = GetUserID(),
                    Evaluation = Value,
                    InsertTime = DateTime.Now
                };
                bll.Add(model);
                CurrentContext.Response.Write(GetJsonResult(true, String.Empty));
            }
            catch (Exception ex)
            {
                CurrentContext.Response.Write(GetJsonResult(false, ex.Message));
            }
        }

        private void GetEvaluation(HttpContext CurrentContext)
        {
            NewsEvaluationModelBll bll = new NewsEvaluationModelBll();
            int NewsID = Convert.ToInt32(CurrentContext.Request["nid"]);
            if (NewsID == 0)
            {
                CurrentContext.Response.Write(GetJsonResult(false, "参数错误！"));
                return;
            }

            DataTable dt = bll.StatisticList(NewsID);
            int Sum = 0;
            foreach (DataRow row in dt.Rows) Sum += Convert.ToInt32(row["evaluationcount"]);
            
            StringBuilder result = new StringBuilder();
            StringWriter sw = new StringWriter(result);
            JsonWriter writer = new JsonWriter(sw);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartObject();

            WriteJsonKeyValue(writer, "sum", Sum.ToString());

            writer.WritePropertyName("items");
            writer.WriteStartArray();
            foreach (DataRow row in dt.Rows)
            {
                writer.WriteStartObject();

                WriteJsonKeyValue(writer, "evaluation", row["evaluation"].ToString());
                WriteJsonKeyValue(writer, "count", row["evaluationcount"].ToString());
                WriteJsonKeyValue(writer, "percentage", Sum == 0 ? "0" : Convert.ToDouble((Convert.ToInt32(row["evaluationcount"]) * 100) / Sum).ToString("00"));

                writer.WriteEndObject(); 
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
            CurrentContext.Response.Write("("+result.ToString()+")");
        }

        private string GetJsonResult(bool Result, string Message)
        {
            string Json = "\"result\":\"{0}\",\"message\":\"{1}\"";
            return "({" + String.Format(Json, Result.ToString().ToLower(), Message) + "})";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public string GetUserID()
        {
            return CurrentUser.UserId;
        }



        private void WriteJsonKeyValue(JsonWriter writer, string key, string value)
        {
            writer.WritePropertyName(key);
            writer.WriteValue(value);
        }
    }
}
