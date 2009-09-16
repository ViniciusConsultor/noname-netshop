using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace NoName.NetShop.CMS.Model
{
    public class TagParameterInfo
    {
        private int _PageID;
        private int _TagID;
        private string _ServerID;
        private bool _IsUseDefault;
        private NameValueCollection _Parameters;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
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
        public bool IsUseDefault
        {
            get { return _IsUseDefault; }
            set { _IsUseDefault = value; }
        }
        public NameValueCollection Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; }
        }
    }
}
