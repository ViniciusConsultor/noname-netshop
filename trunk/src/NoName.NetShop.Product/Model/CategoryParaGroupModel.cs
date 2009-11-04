using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Product.Model
{
    public class CategoryParaGroupModel
    {
        private int _GroupID;
        private string _GroupName;
        private int _OrderValue;
        private int _CategoryID;


        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        public int OrderValue
        {
            get { return _OrderValue; }
            set { _OrderValue = value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
    }
}
