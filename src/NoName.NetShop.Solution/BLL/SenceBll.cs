using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���Sence ��ժҪ˵����
	/// </summary>
	public class SenceBll
	{
		private readonly NoName.NetShop.Solution.SenceDal dal=new NoName.NetShop.Solution.SenceDal();
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
		public void Save(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SenceModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        public void ToggleStatus(int senceId)
        {
            dal.ToggleStatus(senceId);
        }
		#endregion  ��Ա����
    }
}

