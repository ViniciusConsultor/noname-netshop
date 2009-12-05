using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Product.Model
{
    /// <summary>
    /// 实体类pdGift 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GiftModel
    {
        public GiftModel()
        { }
        #region Model
        private int _productid;
        private string _productname;
        private int _stock;
        private string _smallimage;
        private string _mediumimage;
        private string _largeimage;
        private string _keywords;
        private string _brief;
        private int _pageview;
        private DateTime _inserttime;
        private DateTime _changetime;
        private int _status;
        private int _sortvalue;
        private int _score;
        private string _decription;
        /// <summary>
        /// 
        /// </summary>
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Stock
        {
            set { _stock = value; }
            get { return _stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallImage
        {
            set { _smallimage = value; }
            get { return _smallimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MediumImage
        {
            set { _mediumimage = value; }
            get { return _mediumimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LargeImage
        {
            set { _largeimage = value; }
            get { return _largeimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brief
        {
            set { _brief = value; }
            get { return _brief; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PageView
        {
            set { _pageview = value; }
            get { return _pageview; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortValue
        {
            set { _sortvalue = value; }
            get { return _sortvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Decription
        {
            set { _decription = value; }
            get { return _decription; }
        }
        #endregion Model

    }

}
