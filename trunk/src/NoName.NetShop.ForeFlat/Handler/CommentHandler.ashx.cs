using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NoName.NetShop.Comment.Model;
using NoName.NetShop.Comment.BLL;
using System.Web.SessionState;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CommentHandler : IHttpHandler, IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int AppCode = Convert.ToInt32(context.Request["app"]);
            int TargetID = Convert.ToInt32(context.Request["tid"]);
            string Content = Convert.ToString(context.Request["cnt"]);

            context.Response.Write(AddComment(AppCode, TargetID, Content));
        }

        public bool AddComment(int AppCode, int TargetID, string Content)
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
                CommentBll bll = new CommentBll();


                CommentModel Comment = new CommentModel();

                Comment.CommentID = CommDataHelper.GetNewSerialNum(AppName) ;
                Comment.AppType = AppName;
                Comment.Content = Content;
                Comment.CreateTime = DateTime.Now;
                Comment.TargetID = TargetID;
                Comment.UserID = GetUserID();

                bll.Add(Comment);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
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
