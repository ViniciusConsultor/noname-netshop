using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.MagicWorld.Model
{
    public class MagicCategoryModel
    {
        private int _CategoryID;
        private string _CategoryName;
        private string _CategoryPath;
        private int _Status;
        private bool _IsHide;
        private int _CategoryLevel;
        private int _ParentID;
        private int _ShowOrder;


        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID =value; }
        }
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        public string CategoryPath
        {
            get { return _CategoryPath; }
            set { _CategoryPath = value; }
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
        public int CategoryLevel
        {
            get { return _CategoryLevel; }
            set { _CategoryLevel = value; }
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
