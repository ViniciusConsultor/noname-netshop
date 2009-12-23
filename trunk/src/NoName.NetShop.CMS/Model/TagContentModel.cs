﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.CMS.Model
{
    public class TagContentModel
    {
        private int _PageID;
        private int _TagID;
        private string _ServerID;
        private string _Content;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID=value; }
        }
        public int TagID
        {
            get { return _TagID; }
            set { _TagID=value; }
        }
        public string ServerID
        {
            get { return _ServerID; }
            set { _ServerID=value; }
        }
        public string Content
        {
            get { return _Content; }
            set { _Content=value; }
        }
    }
}
