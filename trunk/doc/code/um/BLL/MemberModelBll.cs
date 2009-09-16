using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类MemberModelBll 的摘要说明。
	/// </summary>
	public class MemberModelBll
	{
		private readonly NoName.NetShop.DAL.MemberModelDal dal=new NoName.NetShop.DAL.MemberModelDal();
		public MemberModelBll()
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
		public bool Exists(int UserId)
		{
			return dal.Exists(UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.MemberModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.MemberModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserId)
		{
			
			dal.Delete(UserId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.MemberModel GetModel(int UserId)
		{
			
			return dal.GetModel(UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.MemberModel GetModelByCache(int UserId)
		{
			
			string CacheKey = "MemberModelModel-" + UserId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.MemberModel)objModel;
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
		public List<NoName.NetShop.Model.MemberModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.MemberModel> modelList = new List<NoName.NetShop.Model.MemberModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.MemberModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.MemberModel();
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					model.UserEmail=ds.Tables[0].Rows[n]["UserEmail"].ToString();
					model.Password=ds.Tables[0].Rows[n]["Password"].ToString();
					model.NickName=ds.Tables[0].Rows[n]["NickName"].ToString();
					if(ds.Tables[0].Rows[n]["AllScore"].ToString()!="")
					{
						model.AllScore=int.Parse(ds.Tables[0].Rows[n]["AllScore"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CurScore"].ToString()!="")
					{
						model.CurScore=int.Parse(ds.Tables[0].Rows[n]["CurScore"].ToString());
					}
					if(ds.Tables[0].Rows[n]["LastLogin"].ToString()!="")
					{
						model.LastLogin=DateTime.Parse(ds.Tables[0].Rows[n]["LastLogin"].ToString());
					}
					model.LoginIP=ds.Tables[0].Rows[n]["LoginIP"].ToString();
					if(ds.Tables[0].Rows[n]["RegisterTime"].ToString()!="")
					{
						model.RegisterTime=DateTime.Parse(ds.Tables[0].Rows[n]["RegisterTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(ds.Tables[0].Rows[n]["ModifyTime"].ToString());
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

