using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类UserInRoleModelBll 的摘要说明。
	/// </summary>
	public class UserInRoleModelBll
	{
		private readonly NoName.NetShop.DAL.UserInRoleModelDal dal=new NoName.NetShop.DAL.UserInRoleModelDal();
		public UserInRoleModelBll()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId,int RoleId)
		{
			return dal.Exists(UserId,RoleId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.UserInRoleModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.UserInRoleModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserId,int RoleId)
		{
			
			dal.Delete(UserId,RoleId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.UserInRoleModel GetModel(int UserId,int RoleId)
		{
			
			return dal.GetModel(UserId,RoleId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.UserInRoleModel GetModelByCache(int UserId,int RoleId)
		{
			
			string CacheKey = "UserInRoleModelModel-" + UserId+RoleId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserId,RoleId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.UserInRoleModel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Model.UserInRoleModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.UserInRoleModel> modelList = new List<NoName.NetShop.Model.UserInRoleModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.UserInRoleModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.UserInRoleModel();
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RoleId"].ToString()!="")
					{
						model.RoleId=int.Parse(ds.Tables[0].Rows[n]["RoleId"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

