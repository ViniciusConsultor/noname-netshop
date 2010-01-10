using System;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 实体类CategoryCondition 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SSCategoryConditionModel
	{
		public SSCategoryConditionModel()
		{}
		#region Model
		private int _cateid;
		private int _senceid;
		private string _rulename;
		private string _rulevalue;
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
		public int SenceId
		{
			set{ _senceid=value;}
			get{return _senceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RuleName
		{
			set{ _rulename=value;}
			get{return _rulename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RuleValue
		{
			set{ _rulevalue=value;}
			get{return _rulevalue;}
		}
		#endregion Model

	}
}

