using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.News.Model
{
    public class NewsCategoryModel
    {        
        private int _CateID;
        private string _CateName;
        private int _Status;
        private bool _IsHide;
        private int _CateLevel;
        private int _ParentID;
        private int _ShowOrder;


        public int CateID
        {
            get { return _CateID; }
            set { _CateID = value; }
        }
        public string CateName
        {
            get { return _CateName; }
            set { _CateName = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public bool IsHide
        {
            get { return _IsHide; }
            set { _IsHide = value; }
        }
        public int CateLevel
        {
            get { return _CateLevel; }
            set { _CateLevel = value; }
        }
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        public int ShowOrder
        {
            get { return _ShowOrder; }
            set { _ShowOrder = value; }
        }
    }
}
