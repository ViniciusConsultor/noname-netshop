using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����ProductParaModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ProductParaModel
	{
		public ProductParaModel()
		{}
		#region Model
		private int _productid;
		private int _paraid;
		private string _paravalue;
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
		public int ParaId
		{
			set{ _paraid=value;}
			get{return _paraid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParaValue
		{
			set{ _paravalue=value;}
			get{return _paravalue;}
		}
		#endregion Model

	}
}

