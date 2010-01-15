using System;
namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// 实体类CategoryCondition 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CategoryConditionModel
	{
		public CategoryConditionModel()
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
		/// 查询条件的前半部分，并且提供别名占位符，比如：{0}brandid，{0}merchantprice，{0}paraid=dd and {0}paravalue
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

        public string GetFilterExpress(string tableAlias)
        {
            tableAlias = String.IsNullOrEmpty(tableAlias) ? "" : tableAlias + ".";
            return String.Format(RuleName + " {1}", tableAlias, RuleValue);
        }

        public bool IsBrand
        {
            get { return RuleName.ToLower() == "{0}brandid"; }
        }

        public bool IsPrice
        {
            get { return RuleName.ToLower() == "{0}merchantprice"; }
        }

        public bool IsParameter
        {
            get { return RuleName.ToLower().StartsWith("{0}paraid"); }
        }

        public CategoryConditionModel(int scenceId,int cateId,int maxPrice, int minPrice)
        {
            _senceid = scenceId;
            _cateid = cateId;
            _rulename = "{0}merchantprice";
            _rulevalue = "between " + minPrice + " and " + maxPrice;
        }
        public CategoryConditionModel(int scenceId,int cateId,string brandIds)
        {
            _senceid = scenceId;
            _cateid = cateId;
            _rulename = "{0}brandid";
            _rulevalue = "in(" + brandIds + ")";
        }
        public CategoryConditionModel(int scenceId,int cateId,int paraId,string paraValues)
        {
            _senceid = scenceId;
            _cateid = cateId;
            _rulename = "{0}paraid=" + paraId + " and " + "{0}paravalue";
            _rulevalue = "in(" + paraValues + ")";
        }		
        #endregion Model

	}
}

