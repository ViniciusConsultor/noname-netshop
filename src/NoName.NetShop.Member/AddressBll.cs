using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
using NoName.NetShop.Common;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// ҵ���߼���Address ��ժҪ˵����
	/// </summary>
	public class AddressBll
	{
		private readonly NoName.NetShop.Member.DAL.AddressDal dal=new NoName.NetShop.Member.DAL.AddressDal();
		public AddressBll()
		{}
		#region  ��Ա����

        public void Save(NoName.NetShop.Member.Model.AddressModel model)
        {
            if (model.AddressId == 0)
            {
                model.AddressId = Common.CommDataHelper.GetNewSerialNum(AppType.Address);
            }
            if (dal.Exists(model.AddressId))
            {
                dal.Update(model);
            }
            else
            {
                dal.Add(model);
            }
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AddressId)
		{
			dal.Delete(AddressId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Member.Model.AddressModel GetModel(int AddressId)
		{
			return dal.GetModel(AddressId);
		}

 
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Member.Model.AddressModel> GetModelList(string userId)
		{
            return dal.GetListArray("userid='" + userId+"'");
		}

 		#endregion  ��Ա����
	}
}

