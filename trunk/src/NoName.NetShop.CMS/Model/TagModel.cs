using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.CMS.Model
{
    public class TagModel
    {
        private int _TagID;
        private string _TagName;
        private string _XsltTemplate;
        private string _DefaultParameter;
        private string _DataProvider;
        private string _EditControl;
        private string _ExamplePicture;
        private bool _IsPublic;
        private int _TagType;


        public int TagID
        {
            get { return _TagID; }
            set { _TagID=value; }
        }
        public string TagName
        {
            get { return _TagName; }
            set { _TagName=value; }
        }
        public string XsltTemplate
        {
            get { return _XsltTemplate; }
            set { _XsltTemplate=value; }
        }
        public string DefaultParameter
        {
            get { return _DefaultParameter; }
            set { _DefaultParameter=value; }
        }
        public string DataProvider
        {
            get { return _DataProvider; }
            set { _DataProvider=value; }
        }
        public string EditControl
        {
            get { return _EditControl; }
            set { _EditControl=value; }
        }
        public string ExamplePicture
        {
            get { return _ExamplePicture; }
            set { _ExamplePicture=value; }
        }
        public bool IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic=value; }
        }
        public int TagType
        {
            get { return _TagType; }
            set { _TagType = value; }
        }

    }
}
