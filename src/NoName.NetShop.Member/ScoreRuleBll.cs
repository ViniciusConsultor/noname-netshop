using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Member
{
    public class ScoreRuleBll
    {
		private readonly ScoreRuleDal dal=new ScoreRuleDal();
		public ScoreRuleBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(ScoreRuleModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string actiontype)
		{
			
			dal.Delete(actiontype);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScoreRuleModel GetModel(string actiontype)
		{
			
			return dal.GetModel(actiontype);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ScoreRuleModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}
		#endregion  成员方法   
    }
}
