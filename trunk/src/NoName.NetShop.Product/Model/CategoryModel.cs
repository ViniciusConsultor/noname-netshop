using System;
using NoName.Utility;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// ʵ����CategoryModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        private string _SearchPriceRange;

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
        public string PinYinName
        {
            get { return ChineseToPinYin.Convert(_catename); }
        }
        public string SearchPriceRange
        {
            get { return _SearchPriceRange; }
            set { _SearchPriceRange = value; }
        }

		#endregion Model

	}

    public enum CategoryStatus
    {
        ״̬1 = 1,
        ״̬2 = 0,
    }
}

