using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����PagesModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PagesModel
	{
		public PagesModel()
		{}
		#region Model
		private int? _pageid;
		private string _templatefile;
		private string _pageurl;
		private string _pagephypath;
		private int? _status;
		private DateTime? _lastpubtime;
		/// <summary>
		/// 
		/// </summary>
		public int? PageId
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TemplateFile
		{
			set{ _templatefile=value;}
			get{return _templatefile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageUrl
		{
			set{ _pageurl=value;}
			get{return _pageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PagePhyPath
		{
			set{ _pagephypath=value;}
			get{return _pagephypath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastPubTime
		{
			set{ _lastpubtime=value;}
			get{return _lastpubtime;}
		}
		#endregion Model

	}
}

