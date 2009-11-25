using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Secondhand.Model
{
    /// <summary>
    /// 实体类seSecondhandProduct 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SecondhandProductModel
    {
        public SecondhandProductModel()
        { }
        #region Model
        private int _seproductid;
        private string _seproductname;
        private int _userid;
        private decimal _price;
        private int _cateid;
        private string _catepath;
        private int _stock;
        private string _smallimage;
        private string _mediumimage;
        private string _largeimage;
        private string _keywords;
        private string _brief;
        private DateTime _inserttime;
        private DateTime _updatetime;
        private int _status;
        private int _sortvalue;
        /// <summary>
        /// 
        /// </summary>
        public int SecondhandProductID
        {
            set { _seproductid = value; }
            get { return _seproductid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondhandProductName
        {
            set { _seproductname = value; }
            get { return _seproductname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CateID
        {
            set { _cateid = value; }
            get { return _cateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CatePath
        {
            set { _catepath = value; }
            get { return _catepath; }
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
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
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
        #endregion Model

    }


    public enum SecondhandProductStatus
    {
        尚未审核=1,
        审核通过 = 2,
        审核未通过 = 3,
        冻结=4,
    }
}
