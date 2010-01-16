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
	public class ScenceBll
	{
		private readonly NoName.NetShop.Solution.DAL.ScenceDal dal=new NoName.NetShop.Solution.DAL.ScenceDal();
		public ScenceBll()
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
        public void Save(NoName.NetShop.Solution.Model.ScenceModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.Model.ScenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.Model.ScenceModel> GetModelList(string strWhere)
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
