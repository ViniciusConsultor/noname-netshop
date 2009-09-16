using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类OrderChangeLogModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class OrderChangeLogModel
	{
		public OrderChangeLogModel()
		{}
		#region Model
		private int? _orderid;
		private DateTime? _changetime;
		private string _remark;
		private string _operator;
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
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
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		#endregion Model

	}
}

