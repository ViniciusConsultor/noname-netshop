using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Product.Model
{
    public class ProductNewsModel
    {
        private int _ProdutID;
        private int _NewsID;

        public int ProdutID
        {
            get { return _ProdutID; }
            set { _ProdutID = value; }
        }
        public int NewsID
        {
            get { return _NewsID; }
            set { _NewsID = value; }
        }
    }
}
