using System;
namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// ʵ����Category ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SolutionCategoryModel
	{
		public SolutionCategoryModel()
		{}
		#region Model
		private int _senceid;
		private int _cateid;
		private string _cateimage;
		private string _remark;
		private string _position;
		private bool _isshow;
		/// <summary>
		/// 
		/// </summary>
		public int SenceId
		{
			set{ _senceid=value;}
			get{return _senceid;}
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
		public string CateImage
		{
			set{ _cateimage=value;}
			get{return _cateimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// �Ƿ���ʾ�ڳ����У��������ʾ����remark��cateImage��position����Ϊ��
		/// </summary>
		public bool IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		#endregion Model

	}
}

