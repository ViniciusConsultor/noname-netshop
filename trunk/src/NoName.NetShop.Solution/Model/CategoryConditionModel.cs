using System;
namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// ʵ����CategoryCondition ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��ѯ������ǰ�벿�֣������ṩ����ռλ�������磺{0}brandid��{0}merchantprice��{0}paraid=dd and {0}paravalue
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

        public bool IsSubCategory
        {
            get { return RuleName.ToLower() == "{0}cateid"; }
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
        public CategoryConditionModel(int scenceId,int cateId,int paraId,string paraValues)
        {
            _senceid = scenceId;
            _cateid = cateId;
            _rulename = "{0}paraid=" + paraId + " and " + "{0}paravalue";
            _rulevalue = "in(" + paraValues + ")";
        }

        public CategoryConditionModel(int scenceId, int cateId,string type, string invals)
        {
            _senceid = scenceId;
            _cateid = cateId;
            _rulename = "{0}"+type;
            _rulevalue = "in(" + invals + ")";
        }
        #endregion Model

	}
}

