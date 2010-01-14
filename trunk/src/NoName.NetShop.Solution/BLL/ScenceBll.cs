using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// 业务逻辑类Sence 的摘要说明。
	/// </summary>
	public class ScenceBll
	{
		private readonly NoName.NetShop.Solution.ScenceDal dal=new NoName.NetShop.Solution.SenceDal();
		public ScenceBll()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ScenceId)
		{
			return dal.Exists(ScenceId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SenceModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        public void ToggleStatus(int senceId)
        {
            dal.ToggleStatus(senceId);
        }
		#endregion  成员方法
	}
}

