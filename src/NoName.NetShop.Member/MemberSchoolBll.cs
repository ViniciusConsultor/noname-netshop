using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// ҵ���߼���MemberSchool ��ժҪ˵����
	/// </summary>
	public class MemberSchool
	{
		private readonly NoName.NetShop.Member.DAL.MemberSchool dal=new NoName.NetShop.Member.DAL.MemberSchool();
		public MemberSchool()
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
		public void Add(NoName.NetShop.Member.Model.MemberSchool model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberSchool model)
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
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Member.Model.MemberSchool GetModel(int userid)
		{
			
			return dal.GetModel(userid);
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
		public List<NoName.NetShop.Member.Model.MemberSchool> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		private List<NoName.NetShop.Member.Model.MemberSchool> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Member.Model.MemberSchool> modelList = new List<NoName.NetShop.Member.Model.MemberSchool>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Member.Model.MemberSchool model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Member.Model.MemberSchool();
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					model.truename=dt.Rows[n]["truename"].ToString();
					if(dt.Rows[n]["duty"].ToString()!="")
					{
						model.duty=int.Parse(dt.Rows[n]["duty"].ToString());
					}
					model.school=dt.Rows[n]["school"].ToString();
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



		#endregion  ��Ա����
	}
}

