using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.UserManager.Model;
namespace NoName.NetShop.UserManager.BLL
{
	/// <summary>
	/// 业务逻辑类Favorite 的摘要说明。
	/// </summary>
	public class Favorite
	{
		private readonly NoName.NetShop.UserManager.DAL.Favorite dal=new NoName.NetShop.UserManager.DAL.Favorite();
		public Favorite()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.Favorite model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.Favorite model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.UserManager.Model.Favorite GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
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
		public List<NoName.NetShop.UserManager.Model.Favorite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.Favorite> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.UserManager.Model.Favorite> modelList = new List<NoName.NetShop.UserManager.Model.Favorite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.UserManager.Model.Favorite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.UserManager.Model.Favorite();
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["FavoriteId"].ToString()!="")
					{
						model.FavoriteId=int.Parse(dt.Rows[n]["FavoriteId"].ToString());
					}
					model.FavoriteUrl=dt.Rows[n]["FavoriteUrl"].ToString();
					model.FavoriteName=dt.Rows[n]["FavoriteName"].ToString();
					if(dt.Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(dt.Rows[n]["InsertTime"].ToString());
					}
					if(dt.Rows[n]["ContentId"].ToString()!="")
					{
						model.ContentId=int.Parse(dt.Rows[n]["ContentId"].ToString());
					}
					if(dt.Rows[n]["ContentType"].ToString()!="")
					{
						model.ContentType=int.Parse(dt.Rows[n]["ContentType"].ToString());
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

