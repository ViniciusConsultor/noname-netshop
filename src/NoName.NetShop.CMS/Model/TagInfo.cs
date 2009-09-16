using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Data;
using System.Web;
using System.Xml;
using NoName.Utility;

namespace NoName.NetShop.CMS.Model
{
    public class TagInfo
    {        
        #region Private Fields
        private int _TagID;
        private string _ServerID;
        private string _Template;
        private TagType _Type;
        private string _DefaultParameters;
        private IDataAcquirer _DataProvider;
        private string _EditControl;
        private string _ExamplePicture;
        #endregion

        #region Properities
        public int TagID
        {
            get { return _TagID; }
            set { _TagID = value; }
        }
        public string ServerID
        {
            get { return _ServerID; }
            set { _ServerID = value; }
        }
        public string Template
        {
            get { return _Template; }
            set { _Template = value; }
        }
        public TagType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string DefaultParameters
        {
            get { return _DefaultParameters; }
            set { _DefaultParameters = value; }
        }
        public IDataAcquirer DataProvider 
        {
            get { return _DataProvider; }
            set { _DataProvider = value; }
        }
        public string EditControl
        {
            get { return _EditControl; }
            set { _EditControl = value; }
        }
        public string ExamplePicture
        {
            get { return _ExamplePicture; }
            set { _ExamplePicture = value; }
        }
        #endregion


        public TagInfo(int tagID,string serverID)
        {
            DataTable dt = DataAccess.GetTagByID(tagID).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow reader = dt.Rows[0];

                _DataProvider = GetDataProvider(Convert.ToString(reader["dataprovider"]));
                _DefaultParameters = Convert.ToString(reader["defaultpara"]);
                _TagID = Convert.ToInt32(reader["id"]);
                _Template = HttpContext.Current.Server.MapPath(Convert.ToString(reader["template"]));
                _Type = Convert.ToInt32(reader["tagtype"]) == 1 ? TagType.Static : TagType.Dynamic;
                _ServerID = serverID;
                _EditControl = Convert.ToString(reader["editcontrol"]);
                _ExamplePicture = Convert.ToString(reader["examplepicture"]);
            }
            else
            {
                _TagID=-1;
            }
        }

        public string GetContent(PageInfo page)
        {
            return DataAccess.TagContentGet(page.PageID, TagID,ServerID);
        }

        public bool SaveContent(PageInfo page, TagParameterInfo parm, string Content)
        {
            if (this.Type == TagType.Static)
            {
                return DataAccess.TagContentImport(page.PageID, TagID, ServerID, Content);
            }
            else
            {
                if (parm != null && parm.IsUseDefault)
                {
                    return DataAccess.TagContentImport(page.PageID, TagID, ServerID, Content);
                }
                else
                {
                    //存储para
                    DataAccess.TagParameterImport(parm);
                    //生成内容
                    XmlDocument xdoc = DataProvider.GetData(parm.Parameters);

                    string html = XsltUtil.TransformToHtml(Template, xdoc, Encoding.UTF8);
                    string htmlBody = HtmlHelper.GetBodyContent(html);
                    //存储内容
                    return DataAccess.TagContentImport(page.PageID, TagID, ServerID, htmlBody);
                }
            }
        }

        #region Private Methods
        private string GetDynamicContent(PageInfo page)
        {
            //先获取该标签的参数
            TagParameterInfo para = DataAccess.TagParameterGet(page.PageID,TagID,ServerID);

            if (para.IsUseDefault) //是否使用默认内容，如果是则直接取数据
            {
                return DataAccess.TagContentGet(page.PageID, TagID,ServerID);
            }
            else //else则从IGetData获取XML，转换，保存[?]
            {
                XmlDocument xdoc = DataProvider.GetData(para.Parameters);

                string html = XsltUtil.TransformToHtml(Template, xdoc, Encoding.UTF8);
                string htmlBody = HtmlHelper.GetBodyContent(html);
                //保存数据[?]
                //DataAccess.TagContentImport(page.PageID, TagID, ServerID, htmlBody);
                //SaveTagContent(page, htmlBody);

                return htmlBody;
            }
        }

        private IDataAcquirer GetDataProvider(string ProviderString)
        {
            if (ProviderString == String.Empty) return null;
            else
            {
                Type type = System.Type.GetType(ProviderString);

                IDataAcquirer provider = (IDataAcquirer)Activator.CreateInstance(type);

                return provider;
            }
        } 
        #endregion
    }

    public enum TagType
    {
        Static = 1,
        Dynamic = 2
    }
}
