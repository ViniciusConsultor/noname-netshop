using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NoName.NetShop.Comment;
using System.Web.SessionState;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CommentHandler :AuthBasePage, IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int AppCode = Convert.ToInt32(context.Request["app"]);
            int TargetID = Convert.ToInt32(context.Request["tid"]);
            string Content = Convert.ToString(context.Request["cnt"]);
            string ValidateCode = Convert.ToString(context.Request["vld"]);
            string Message = String.Empty;

            AddComment(context,AppCode, TargetID, Content,ValidateCode);
        }

        public void AddComment(HttpContext CurrentContext,int AppCode, int TargetID, string Content,string ValidateCode)
        {
            string AppName = String.Empty;
            switch (AppCode)
            {
                case 1:
                    AppName = AppType.Member;
                    break;
                case 2:
                    AppName = AppType.News;
                    break;
                case 3:
                    AppName = AppType.Order;
                    break;
                case 4:
                    AppName = AppType.Address;
                    break;
                case 5:
                    AppName = AppType.Product;
                    break;
                case 6:
                    AppName = AppType.MagicWorld;
                    break;
                default:
                    break; 
            }

            try
            {
                if (CurrentContext.Session["ValidateCode"] != null && CurrentContext.Session["ValidateCode"].ToString() == ValidateCode)
                {
                    CommentBll bll = new CommentBll();


                    CommentModel Comment = new CommentModel();

                    Comment.CommentID = CommDataHelper.GetNewSerialNum(AppName);
                    Comment.AppType = AppName;
                    Comment.Content = Content;
                    Comment.CreateTime = DateTime.Now;
                    Comment.TargetID = TargetID;
                    Comment.UserID = GetUserID();

                    bll.Add(Comment);

                    CurrentContext.Response.Write(FormatResult(true, "添加成功"));
                }
                else
                {
                    CurrentContext.Response.Write(FormatResult(false, "添加失败，验证码错误"));
                }
            }
            catch(Exception e)
            {
                CurrentContext.Response.Write(FormatResult(false, "添加失败，内部程序错误"));
            }
        }

        public string FormatResult(bool Result, string Reason)
        {
            string Json = "{result:{0},msg='{1}'}";
            return String.Format(Json, Result, Reason);
        }

        public string GetUserID()
        {
            return "zhangfeng";
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
