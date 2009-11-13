using System;
namespace NoName.NetShop.News.Model
{
	/// <summary>
	/// 实体类NewsModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class NewsModel
	{
		public NewsModel()
		{}
		#region Model
		private int _newsid;
		private int _newstype;
		private int _status;
		private string _title;
		private string _subtitle;
		private string _brief;
		private string _content;
		private string _smallimageurl;
		private string _author;
		private string _from;
		private string _videourl;
		private string _imageurl;
		private string _productid;
		private DateTime _inserttime;
		private DateTime _modifytime;
		private string _tags;
        private int _categoryid;
		/// <summary>
		/// 
		/// </summary>
		public int NewsId
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NewsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubTitle
		{
			set{ _subtitle=value;}
			get{return _subtitle;}
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
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmallImageUrl
		{
			set{ _smallimageurl=value;}
			get{return _smallimageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string From
		{
			set{ _from=value;}
			get{return _from;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoUrl
		{
			set{ _videourl=value;}
			get{return _videourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		/// <summary>
		/// 
		/// </summary>
		public string Tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}


        public int CategoryID
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }
		#endregion Model

	}
}

