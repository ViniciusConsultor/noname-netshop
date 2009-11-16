using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// ҵ���߼���MemberCompany ��ժҪ˵����
	/// </summary>
	public class MemberCompany
	{
		private readonly NoName.NetShop.Member.DAL.MemberCompany dal=new NoName.NetShop.Member.DAL.MemberCompany();
		public MemberCompany()
		{}
		#region  ��Ա����

 

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.MemberCompany model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// ���һ������
        /// </summary>
        public NoName.NetShop.Member.Model.MemberCompany GetModel(int userId)
        {
            return dal.GetModel(userId);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberCompany model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int userid)
		{
			
			dal.Delete(userid);
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
		public List<NoName.NetShop.Member.Model.MemberCompany> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Member.Model.MemberCompany> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Member.Model.MemberCompany> modelList = new List<NoName.NetShop.Member.Model.MemberCompany>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Member.Model.MemberCompany model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Member.Model.MemberCompany();
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

