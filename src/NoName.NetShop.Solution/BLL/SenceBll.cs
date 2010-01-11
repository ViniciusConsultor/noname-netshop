using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���Sence ��ժҪ˵����
	/// </summary>
	public class SenceBll
	{
		private readonly SenceDal dal=new SenceDal();
		public SenceBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ScenceId)
		{
			return dal.Exists(ScenceId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(SenceModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<SenceModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  ��Ա����
	}
}

