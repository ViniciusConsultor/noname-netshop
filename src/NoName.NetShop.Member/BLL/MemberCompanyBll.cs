using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.UserManager.Model;
namespace NoName.NetShop.UserManager.BLL
{
	/// <summary>
	/// 业务逻辑类MemberCompany 的摘要说明。
	/// </summary>
	public class MemberCompany
	{
		private readonly NoName.NetShop.UserManager.DAL.MemberCompany dal=new NoName.NetShop.UserManager.DAL.MemberCompany();
		public MemberCompany()
		{}
		#region  成员方法

 

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.MemberCompany model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// 获得一条数据
        /// </summary>
        public NoName.NetShop.UserManager.Model.MemberCompany GetModel(int userId)
        {
            return dal.GetModel(userId);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.MemberCompany model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			
			dal.Delete(userid);
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
		public List<NoName.NetShop.UserManager.Model.MemberCompany> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.MemberCompany> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.UserManager.Model.MemberCompany> modelList = new List<NoName.NetShop.UserManager.Model.MemberCompany>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.UserManager.Model.MemberCompany model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.UserManager.Model.MemberCompany();
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					model.truename=dt.Rows[n]["truename"].ToString();
					model.idcard=dt.Rows[n]["idcard"].ToString();
					model.companyname=dt.Rows[n]["companyname"].ToString();
					model.province=dt.Rows[n]["province"].ToString();
					model.city=dt.Rows[n]["city"].ToString();
					model.county=dt.Rows[n]["county"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.TelePhone=dt.Rows[n]["TelePhone"].ToString();
					model.Fax=dt.Rows[n]["Fax"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
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

