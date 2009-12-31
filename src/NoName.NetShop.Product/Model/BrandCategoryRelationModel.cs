using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Product.Model
{
    public class BrandCategoryRelationModel
    {
        private int _BrandID;
        private int _CategoryID;
        private string _CategoryPath;


        public int BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string CategoryPath
        {
            get { return _CategoryPath; }
            set { _CategoryPath = value; }
        }
    }
}
