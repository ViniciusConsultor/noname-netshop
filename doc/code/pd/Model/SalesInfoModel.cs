using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����SalesInfoModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SalesInfoModel
	{
		public SalesInfoModel()
		{}
		#region Model
		private int _salestype;
		private int _productid;
		private int _ruletype;
		private int? _sortvalue;
		/// <summary>
		/// 
		/// </summary>
		public int SalesType
		{
			set{ _salestype=value;}
			get{return _salestype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RuleType
		{
			set{ _ruletype=value;}
			get{return _ruletype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortValue
		{
			set{ _sortvalue=value;}
			get{return _sortvalue;}
		}
		#endregion Model

	}
}

