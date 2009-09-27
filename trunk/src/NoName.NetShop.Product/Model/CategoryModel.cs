using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// 实体类CategoryModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CategoryModel
	{
		public CategoryModel()
		{}
		#region Model
		private int _cateid;
		private string _catename;
		private string _catepath;
		private int _status;
		private string _pricerange;
		private bool _ishide;
		private int _catelevel;
        private int _parentid;
        private string _remark;
        private int _showorder;

		/// <summary>
		/// 
		/// </summary>
		public int CateId
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CateName
		{
			set{ _catename=value;}
			get{return _catename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CatePath
		{
			set{ _catepath=value;}
			get{return _catepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PriceRange
		{
			set{ _pricerange=value;}
			get{return _pricerange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsHide
		{
			set{ _ishide=value;}
			get{return _ishide;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CateLevel
		{
			set{ _catelevel=value;}
			get{return _catelevel;}
		}

        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        public int ShowOrder
        {
            get { return _showorder; }
            set { _showorder = value; }
        }

		#endregion Model

	}

    public enum CategoryStatus
    {
        状态1 = 1,
        状态2 = 0,
    }
}

