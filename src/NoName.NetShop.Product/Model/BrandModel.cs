using System;

namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// ʵ����BrandModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class BrandModel
	{
		public BrandModel()
		{}


		#region Model
		private int _brandid;
		private string _brandname;
		private int _cateid;
		private string _catepath;
		private string _brandlogo;
        private string _brief;
        private int _showorder;
		/// <summary>
		/// 
		/// </summary>
		public int BrandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BrandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
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
		public string CatePath
		{
			set{ _catepath=value;}
			get{return _catepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BrandLogo
		{
			set{ _brandlogo=value;}
			get{return _brandlogo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
        }

        /// <summary>
        /// 
        /// </summary>
        public int ShowOrder
        {
            get { return _showorder; }
            set { _showorder = value; }
        }

		#endregion Model

	}
}

