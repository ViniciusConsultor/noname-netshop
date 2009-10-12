using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.UserManager.Model;
using NoName.NetShop.Member.Model;
namespace NoName.NetShop.UserManager.BLL
{
	/// <summary>
	/// 业务逻辑类Member 的摘要说明。
	/// </summary>
	public class Member
	{
		private readonly NoName.NetShop.UserManager.DAL.Member dal=new NoName.NetShop.UserManager.DAL.Member();
		public Member()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.MemberModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.MemberModel model)
		{
			dal.Update(model);
		}

        public void SetStatus(int userId, MemberStatus status)
        {
            dal.SetStatus(userId, status);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userId)
		{
			
			dal.Delete(userId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.UserManager.Model.MemberModel GetModel(int userId)
		{
			
			return dal.GetModel(userId);
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
		public List<NoName.NetShop.UserManager.Model.MemberModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.MemberModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.UserManager.Model.MemberModel> modelList = new List<NoName.NetShop.UserManager.Model.MemberModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.UserManager.Model.MemberModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.UserManager.Model.MemberModel();
					if(dt.Rows[n]["userId"].ToString()!="")
					{
						model.userId=int.Parse(dt.Rows[n]["userId"].ToString());
					}
					model.UserEmail=dt.Rows[n]["UserEmail"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.NickName=dt.Rows[n]["NickName"].ToString();
					if(dt.Rows[n]["AllScore"].ToString()!="")
					{
						model.AllScore=int.Parse(dt.Rows[n]["AllScore"].ToString());
					}
					if(dt.Rows[n]["CurScore"].ToString()!="")
					{
						model.CurScore=int.Parse(dt.Rows[n]["CurScore"].ToString());
					}
					if(dt.Rows[n]["LastLogin"].ToString()!="")
					{
						model.LastLogin=DateTime.Parse(dt.Rows[n]["LastLogin"].ToString());
					}
					model.LoginIP=dt.Rows[n]["LoginIP"].ToString();
					if(dt.Rows[n]["RegisterTime"].ToString()!="")
					{
						model.RegisterTime=DateTime.Parse(dt.Rows[n]["RegisterTime"].ToString());
					}
					if(dt.Rows[n]["UserType"].ToString()!="")
					{
						model.UserType=(MemberType)int.Parse(dt.Rows[n]["UserType"].ToString());
					}
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.Status=(MemberStatus)int.Parse(dt.Rows[n]["status"].ToString());
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

