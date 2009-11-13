using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using log4net;
using NoName.NetShop.Publish.List;
using NoName.NetShop.Publish.Product;
using NoName.NetShop.Publish.News;

namespace NoName.NetShop.Publish
{
    public class PublishHanlder : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        
        //private ILog Logger = LogManager.GetLogger("PublishLogger");

        public void ProcessRequest(HttpContext context)
        {
            //ShopPublishHandler handler = new ShopPublishHandler(context.Request.RawUrl.ToLower());

            //context.Response.Write(handler.PageFileName);

            //context.Response.Write(context.Request.RawUrl);                


            string Url = context.Request.RawUrl.ToLower();
            string StaticUrl = String.Empty;

            //try
            //{
                IPublishHandler Handler = AcquierHandler(Url);

                if (Handler.HasStaticPage(out StaticUrl))
                {
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
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private IPublishHandler AcquierHandler(string Url)
        {
            IPublishHandler handler;

            string Suffix = Url.Split('.')[1].ToLower();

            switch (Suffix)
            {
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
