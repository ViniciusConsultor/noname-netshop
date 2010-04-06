using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.CMS.Model
{
    public class PageModel
    {
        private int _PageID;
        private string _PageName;
        private string _PageTitle;
        private DateTime _CreateTime;
        private DateTime _UpdateTime;
        private string _PhysicalPath;
        private string _Author;
        private string _LastModify;
        private int _Category;
        private int _SelfClassid;
        private string _ExtendPageInfo;
        private string _TempatePath;


        public int PageID
        {
            get { return _PageID; }
            set { _PageID=value; }
        }
        public string PageName
        {
            get { return _PageName; }
            set { _PageName=value; }
        }
        public string PageTitle
        {
            get { return _PageTitle; }
            set { _PageTitle=value; }
        }
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime=value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime=value; }
        }
        public string PhysicalPath
        {
            get { return _PhysicalPath; }
            set { _PhysicalPath=value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author=value; }
        }
        public string LastModify
        {
            get { return _LastModify; }
            set { _LastModify=value; }
        }
        public int Category
        {
            get { return _Category; }
            set { _Category=value; }
        }
        public int SelfClassid
        {
            get { return _SelfClassid; }
            set { _SelfClassid=value; }
        }
        public string ExtendPageInfo
        {
            get { return _ExtendPageInfo; }
            set { _ExtendPageInfo=value; }
        }
        public string TempatePath
        {
            get { return _TempatePath; }
            set { _TempatePath = value; }
        }
    }

    public enum PageCategory
    {
        HomePage=1,
        ChannelPage=2,
        MagicWorld=3,
        SalesPage=4,
        News=5,
    }
}
