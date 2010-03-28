using System;
using System.Text.RegularExpressions;
namespace NoName.NetShop.Member.Model
{
	/// <summary>
	/// 实体类Address 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AddressModel
	{
		public AddressModel()
		{}
		#region Model
		private string _userid;
		private int _addressid;
        private string _regionPath;
        private string _country;
		private string _province;
		private string _city;
        private string _county;
		private string _addressdetail;
		private string _recievername;
		private string _mobile;
		private string _telephone;
		private string _postalcode;
		private bool _isdefault;
		private DateTime _inserttime;
		private DateTime _modifytime;
        public string Email { get; set; }

        public string FullAddress
        {
            get
            {
                return String.Format("{0}{1}{2} {3} 邮编：{4} 收货人：{5}", Province, City, County, AddressDetail, Postalcode, RecieverName);
            }
        }

        /// <summary>
		/// 
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AddressId
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}

        public string County
        {
            get { return _county;}
            set { _county = value; }
        }

        public string RegionPath
        {
            get { return _regionPath; }
            set
            {
                _regionPath = value;
            }
        }

        public int RegionId
        {
            get
            {
                int regionId = 0;
                if (!String.IsNullOrEmpty(_regionPath))
                {
                    Match ma = Regex.Match(_regionPath,"/(?<rid>\\d+)/$");
                    if (ma.Success && ma.Groups["rid"].Success)
                    {
                        regionId = int.Parse(ma.Groups["rid"].Value);
                    }
                }
                return regionId;
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public string AddressDetail
		{
			set{ _addressdetail=value;}
			get{return _addressdetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecieverName
		{
			set{ _recievername=value;}
			get{return _recievername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Postalcode
		{
			set{ _postalcode=value;}
			get{return _postalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		#endregion Model

	}
}

