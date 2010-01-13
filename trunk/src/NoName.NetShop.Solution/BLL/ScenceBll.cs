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
		private readonly ScenceDal dal=new ScenceDal();
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
		public void Save(ScenceModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ScenceModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  成员方法
	}
}

