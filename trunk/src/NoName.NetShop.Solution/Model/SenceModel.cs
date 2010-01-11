using System;

namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// ʵ����Sence ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SenceModel
	{
		public SenceModel()
		{}
		#region Model
		private int _scenceid;
		private string _scencename;
		private string _remark;
		private string _senceimg;
		private int _sencetype;
		private bool _isactive;
		/// <summary>
		/// 
		/// </summary>
		public int ScenceId
		{
			set{ _scenceid=value;}
			get{return _scenceid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string ScenceName
		{
			set{ _scencename=value;}
			get{return _scencename;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// ����ͼƬ
		/// </summary>
		public string SenceImg
		{
			set{ _senceimg=value;}
			get{return _senceimg;}
		}
		/// <summary>
		/// �������ͣ�0 �Ƽ� 1 ����
		/// </summary>
		public int SenceType
		{
			set{ _sencetype=value;}
			get{return _sencetype;}
		}
		/// <summary>
		/// �Ƿ񼤻�
		/// </summary>
		public bool IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		#endregion Model

	}
}

