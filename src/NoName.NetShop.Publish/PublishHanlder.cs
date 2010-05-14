using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using log4net;
using NoName.NetShop.Publish.List;
using NoName.NetShop.Publish.Product;
using NoName.NetShop.Publish.News;
using NoName.NetShop.Publish.Brand;
using NoName.NetShop.Common;
using System.Text.RegularExpressions;

namespace NoName.NetShop.Publish
{
    public class PublishHanlder : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        private ILog Logger = Common.Loggers.PublishLogger;

        public void ProcessRequest(HttpContext context)
        {
            string Url = context.Request.RawUrl.ToLower();
            string StaticUrl = String.Empty;

            #region 日志记录-基本信息区域
            PublishLogInfo LogInfo = new PublishLogInfo();

            LogInfo.RequestStartTime = DateTime.Now;
            LogInfo.IP = context.Request.UserHostAddress;
            LogInfo.RequtstUrl = Url;
            LogInfo.RemoteName = context.Request.ServerVariables["Server_Name"];
            LogInfo.UserAgent = context.Request.ServerVariables["Http_User_Agent"];
            LogInfo.Referer = context.Request.ServerVariables["Http_Referer"];
            LogInfo.Server = context.Server.MachineName;
            #endregion

            #region 日志记录-初始化信息
            LogInfo.IsRedirect = false;
            LogInfo.IsPageFileValidate = true;
            #endregion

            try
            {
                IPublishHandler Handler = AcquierHandler(Url);

                if (Handler.HasStaticPage(out StaticUrl))
                {
                    #region 日志记录-转向信息
                    LogInfo.IsRedirect = true;
                    LogInfo.RedirectUrl = StaticUrl;
                    //LogBuilder.Append(String.Format(" static url mapped:{0}.", StaticUrl));
                    #endregion
                    context.Response.Redirect(StaticUrl);
                }
                else
                {
                    string PageFileName = Handler.PageFileName;
                    bool validate = true;

                    if (!Handler.ValidatePageFile())
                    {
                        Handler.CreatePageFile();
                        validate = false;
                    }

                    context.Response.WriteFile(PageFileName);

                    #region 日志记录-页面文件及有效性区域
                    LogInfo.PageFile = PageFileName;
                    LogInfo.IsPageFileValidate = validate;
                    #endregion
                    #region 日志记录-页面生成效率区域
                    LogInfo.RequestEndTime = DateTime.Now;
                    LogInfo.ProcessTime = LogInfo.RequestEndTime - LogInfo.RequestStartTime;

                    LogInfo.IsSuccess = true;
                    LogInfo.ErrorMessage = "";
                    LogInfo.Extend = "";
                    #endregion
                }
                Logger.Info(LogInfo.ToString());
            }
            catch (Exception ex)
            {
                #region 日志记录-页面生成效率区域
                LogInfo.RequestEndTime = DateTime.Now;
                LogInfo.ProcessTime = LogInfo.RequestEndTime - LogInfo.RequestStartTime;

                LogInfo.IsSuccess = false;
                LogInfo.ErrorMessage = Regex.Replace(ex.ToString(), "(\r\n)|(\r)|{\n}", "");
                LogInfo.Extend = "";
                #endregion

                Logger.Info(LogInfo.ToString());

                throw ex;
            }
        }

        private IPublishHandler AcquierHandler(string Url)
        {
            IPublishHandler handler;

            string Suffix = Url.Split('.')[1].ToLower();

            switch (Suffix)
            {
                case "brand":
                    handler = (IPublishHandler)(new BrandPublishHandler(Url));
                    break;
                case "list":
                    handler = (IPublishHandler)(new ListPublishHandler(Url));
                    break;
                case "product":
                    handler = (IPublishHandler)(new ProductPublishHandler(Url));
                    break;
                case "news":
                    handler = (IPublishHandler)(new NewsPublishHandler(Url));
                    break;
                case "newslist":
                    handler = (IPublishHandler)(new NewsPublishHandler(Url));
                    break;
                default:
                    handler = null;
                    break;
            }

            return handler;
        }
    }



    public interface IPublishHandler
    {
        string PageFileName
        {
            get;
            set;
        }

        bool HasStaticPage(out string StaticUrl);

        string GetPageFileName();

        bool ValidatePageFile();

        void CreatePageFile();

        bool DeletePageFile();
    }
}
