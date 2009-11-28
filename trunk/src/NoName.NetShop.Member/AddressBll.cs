using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
using NoName.NetShop.Common;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// 业务逻辑类Address 的摘要说明。
	/// </summary>
	public class AddressBll
	{
		private readonly NoName.NetShop.Member.DAL.AddressDal dal=new NoName.NetShop.Member.DAL.AddressDal();
		public AddressBll()
		{}
		#region  成员方法

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
		/// 删除一条数据
		/// </summary>
		public void Delete(int AddressId)
		{
			dal.Delete(AddressId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.AddressModel GetModel(int AddressId)
		{
			return dal.GetModel(AddressId);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Member.Model.AddressModel> GetModelList(string userId)
		{
            return dal.GetListArray("userid='" + userId+"'");
		}

 		#endregion  成员方法
	}
}

