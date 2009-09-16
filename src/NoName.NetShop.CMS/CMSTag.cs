using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Web;
using NoName.Utility;
using NoName.NetShop.CMS.Model;
using System.Web.UI;

namespace NoName.NetShop.CMS
{

        public class CMSTag : Control
        {
            [Description("标签的类型识别编号")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            private int _tagID;
            public int TagID
            {
                get
                {
                    return _tagID;
                }
                set { _tagID = value; }
            }

            [Description("标签的描述")]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            private string _description;
            public string Description
            {
                get
                {
                    return _description;
                }
                set { _description = value; }
            }

            protected override void Render(HtmlTextWriter writer)
            {
                NameValueCollection paras = HttpUtil.GetRequestParameters(HttpContext.Current.Request, null);

                //writer.Write("start get tag content at "+DateTime.Now +"<br/>");

                int PageID = Convert.ToInt32(paras["pageid"]);
                PageInfo cmsPage = PageInfo.GetPageInfo(PageID);

                if (cmsPage != null)
                {
                    TagInfo cmsTag = new TagInfo(TagID, this.ID);

                    if (cmsTag.TagID != -1)
                    {
                        writer.Write(cmsTag.GetContent(cmsPage));
                    }
                }

                //writer.Write("finish get tag content at " + DateTime.Now + "<br/>");

                base.Render(writer);
            }



        
    }
}
