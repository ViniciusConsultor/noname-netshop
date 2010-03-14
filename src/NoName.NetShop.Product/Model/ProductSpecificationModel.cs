using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NoName.NetShop.Product.Model
{
    public class ProductSpecificationModel
    {
        public ProductSpecificationModel() { }
        public ProductSpecificationModel(DataRow row) 
        {
            _specificationid = Convert.ToInt32(row["specificationid"]);
            _createtime = Convert.ToDateTime(row["createtime"]);
            _title = Convert.ToString(row["title"]);
            _content = Convert.ToString(row["content"]);
            _categorypath = Convert.ToString(row["categorypath"]);
            _categoryid = Convert.ToInt32(row["categoryid"]);
            _type = Convert.ToInt16(row["type"]);
        }

        private int _specificationid;
        private string _title;
        private string _content;
        private int _categoryid;
        private string _categorypath;
        private DateTime _createtime;
        private int _type;
        
        /// <summary>
        /// 
        /// </summary>
        public int SpecificationID
        {
            set { _specificationid = value; }
            get { return _specificationid; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CategoryPath
        {
            set { _categorypath = value; }
            get { return _categorypath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }

    public enum SpecificationType
    {
        包装清单=1,
        优惠套装=2,
        售后服务=3
    }
}
