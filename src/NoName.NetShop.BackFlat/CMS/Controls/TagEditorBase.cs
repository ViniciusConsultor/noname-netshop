using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoName.NetShop.BackFlat.CMS.Controls
{
    public class TagEditorBase : System.Web.UI.UserControl
    {
        public virtual string ServerID
        {
            get;
            set;
        }
        public virtual int TagID
        {
            get;
            set;
        }
        public virtual int PageID
        {
            get;
            set;
        }
        public virtual string TagTitle
        {
            get;
            set;
        }
    }
}
