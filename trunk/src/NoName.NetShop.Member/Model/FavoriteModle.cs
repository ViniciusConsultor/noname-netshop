using System;
namespace NoName.NetShop.UserManager.Model
{
	/// <summary>
	/// 实体类Favorite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Favorite
	{
		public Favorite()
		{}
		#region Model
		private int? _userid;
		private int? _favoriteid;
		private string _favoriteurl;
		private string _favoritename;
		private DateTime? _inserttime;
		private int? _contentid;
		private int? _contenttype;
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FavoriteId
		{
			set{ _favoriteid=value;}
			get{return _favoriteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FavoriteUrl
		{
			set{ _favoriteurl=value;}
			get{return _favoriteurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FavoriteName
		{
			set{ _favoritename=value;}
			get{return _favoritename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ContentId
		{
			set{ _contentid=value;}
			get{return _contentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ContentType
		{
			set{ _contenttype=value;}
			get{return _contenttype;}
		}
		#endregion Model

	}
}

