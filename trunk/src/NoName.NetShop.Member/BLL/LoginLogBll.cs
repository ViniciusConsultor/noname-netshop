using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.UserManager.Model;
namespace NoName.NetShop.UserManager.BLL
{
	/// <summary>
	/// ҵ���߼���LoginLog ��ժҪ˵����
	/// </summary>
	public class LoginLog
	{
		private readonly NoName.NetShop.UserManager.DAL.LoginLog dal=new NoName.NetShop.UserManager.DAL.LoginLog();
		public LoginLog()
		{}
		#region  ��Ա����

	

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.LoginLog model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.UserManager.Model.LoginLog GetModel(int UserId)
		{
			
			return dal.GetModel(UserId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.LoginLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.LoginLog> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.UserManager.Model.LoginLog> modelList = new List<NoName.NetShop.UserManager.Model.LoginLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.UserManager.Model.LoginLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.UserManager.Model.LoginLog();
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["LoginTime"].ToString()!="")
					{
						model.LoginTime=DateTime.Parse(dt.Rows[n]["LoginTime"].ToString());
					}
					model.IP=dt.Rows[n]["IP"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

