using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����RuleModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class RuleModel
	{
		public RuleModel()
		{}
		#region Model
		private int _schemeid;
		private int _cateid;
		private string _rule;
		/// <summary>
		/// 
		/// </summary>
		public int SchemeId
		{
			set{ _schemeid=value;}
			get{return _schemeid;}
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
		public string Rule
		{
			set{ _rule=value;}
			get{return _rule;}
		}
		#endregion Model

	}
}

