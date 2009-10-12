using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.UserManager.Model;
namespace NoName.NetShop.UserManager.BLL
{
	/// <summary>
	/// 业务逻辑类Address 的摘要说明。
	/// </summary>
	public class Address
	{
		private readonly NoName.NetShop.UserManager.DAL.Address dal=new NoName.NetShop.UserManager.DAL.Address();
		public Address()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AddressId)
		{
			return dal.Exists(AddressId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.Address model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.Address model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AddressId)
		{
			
			dal.Delete(AddressId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.UserManager.Model.Address GetModel(int AddressId)
		{
			
			return dal.GetModel(AddressId);
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
		public List<NoName.NetShop.UserManager.Model.Address> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.Address> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.UserManager.Model.Address> modelList = new List<NoName.NetShop.UserManager.Model.Address>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.UserManager.Model.Address model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.UserManager.Model.Address();
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["AddressId"].ToString()!="")
					{
						model.AddressId=int.Parse(dt.Rows[n]["AddressId"].ToString());
					}
					model.Province=dt.Rows[n]["Province"].ToString();
					model.City=dt.Rows[n]["City"].ToString();
					model.AddressDetail=dt.Rows[n]["AddressDetail"].ToString();
					model.RecieverName=dt.Rows[n]["RecieverName"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.Telephone=dt.Rows[n]["Telephone"].ToString();
					model.Postalcode=dt.Rows[n]["Postalcode"].ToString();
					if(dt.Rows[n]["IsDefault"].ToString()!="")
					{
						if((dt.Rows[n]["IsDefault"].ToString()=="1")||(dt.Rows[n]["IsDefault"].ToString().ToLower()=="true"))
						{
						model.IsDefault=true;
						}
						else
						{
							model.IsDefault=false;
						}
					}
					if(dt.Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(dt.Rows[n]["InsertTime"].ToString());
					}
					if(dt.Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
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

