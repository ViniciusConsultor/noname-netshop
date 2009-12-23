using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Model;
using System.Data;
using NoName.NetShop.CMS.DataAccess;
using System.Collections.Specialized;
using NoName.Utility;
using System.Web;
using System.Xml;
using NoName.NetShop.CMS.Data;
using NoName.NetShop.CMS.Utility;

namespace NoName.NetShop.CMS.Controler
{
    public class TagControler
    {
        public static TagModel GetModel(int TagID)
        {
            TagModel model = null;

            DataTable dt = TagDataAccess.Get(TagID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model = new TagModel();

                model.TagID = Convert.ToInt32(row["tagid"]);
                model.TagName = Convert.ToString(row["tagname"]);
                model.XsltTemplate = Convert.ToString(row["xslttemplate"]);
                model.DataProvider = Convert.ToString(row["dataprovider"]);
                model.DefaultParameter = Convert.ToString(row["defaultparameter"]);
                model.EditControl = Convert.ToString(row["editcontrol"]);
                model.ExamplePicture = Convert.ToString(row["examplepicture"]);
                model.IsPublic = Convert.ToBoolean(row["ispublic"]);
            }


            return model;
        }


        public static void Insert(TagModel tag)
        {
            TagDataAccess.Insert(tag);
        }

        public static void Update(TagModel tag)
        {
            TagDataAccess.Update(tag);
        }

        public static DataTable Get(int TagID)
        {
            return TagDataAccess.Get(TagID);
        }

        public static void TagContentImport(TagContentModel tagContent)
        {
            TagDataAccess.TagContentImport(tagContent);
        }

        public static void TagParameterImport(TagParameterModel tagParameter)
        {
            TagDataAccess.TagParameterImport(tagParameter);
        }

        public static string TagContentGet(int PageID, int TagID, string ServerID)
        {
            return TagDataAccess.TagContentGet(PageID, TagID, ServerID);
        }

        public static string TagParameterGet(int PageID, int TagID, string ServerID)
        {
            return TagDataAccess.TagParameterGet(PageID, TagID, ServerID);
        }

        public static NameValueCollection GetTagParameter(int TagID, HttpRequest Request)
        {
            TagModel tag = GetModel(TagID);

            NameValueCollection OriginalParameter = HttpUtil.GetRequestParameters(Request, Encoding.UTF8);
            NameValueCollection DefaultParameter = HttpUtil.GetParameters(tag.DefaultParameter);
            NameValueCollection FinalParameter = new NameValueCollection();

            foreach (string key in DefaultParameter.Keys)
            {
                bool has = false;
                foreach (string ok in OriginalParameter.AllKeys)
                {
                    if (ok == key)
                    {
                        has = true;
                        break;
                    }
                }
                if (has)
                {
                    FinalParameter.Add(key, OriginalParameter[key]);
                }
            }

            return FinalParameter;
        }


        public static string GenerateDefaultCode(int TagID, NameValueCollection Parameter)
        {
            TagModel Tag = GetModel(TagID);

            ITagDataProvider dataProvider = String.IsNullOrEmpty(Tag.DataProvider) ? null : (ITagDataProvider)Activator.CreateInstance(Type.GetType(Tag.DataProvider));

            XmlDocument xdoc = dataProvider.GetData(Parameter);

            string html = XsltHelper.TransformToHtml(HttpContext.Current.Server.MapPath(Tag.XsltTemplate), xdoc, Encoding.UTF8);
            string htmlBody = RegUtil.GetBodyContent(html);

            return htmlBody;
        }

    }
}
