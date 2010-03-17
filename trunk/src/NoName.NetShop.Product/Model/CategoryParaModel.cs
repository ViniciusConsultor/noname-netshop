using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// 实体类CategoryParaModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CategoryParaModel
	{
		public CategoryParaModel()
		{}

		#region Model
		private int _paraid;
		private int _cateid;
		private string _paraname;
		private int _paratype;
		private int _status;
		private int _paragroupid;
		private string _paravalues;
		private string _defaultvalue;
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
		public int CateId
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParaName
		{
			set{ _paraname=value;}
			get{return _paraname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParaType
		{
			set{ _paratype=value;}
			get{return _paratype;}
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
		public int ParaGroupId
		{
			set{ _paragroupid=value;}
			get{return _paragroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParaValues
		{
			set{ _paravalues=value;}
			get{return _paravalues;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultValue
		{
			set{ _defaultvalue=value;}
			get{return _defaultvalue;}
		}
		#endregion Model

	}



    public enum CategoryParameterType
    {
        检索属性 = 1,
        规格参数 = 2,
    }
}

