using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// ҵ���߼���Address ��ժҪ˵����
	/// </summary>
	public class Address
	{
		private readonly NoName.NetShop.Member.DAL.Address dal=new NoName.NetShop.Member.DAL.Address();
		public Address()
		{}
		#region  ��Ա����


		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int AddressId)
		{
			return dal.Exists(AddressId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.Address model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.Address model)
		{
			dal.Update(model);
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
		public NoName.NetShop.Member.Model.Address GetModel(int AddressId)
		{
			
			return dal.GetModel(AddressId);
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
		public List<NoName.NetShop.Member.Model.Address> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Member.Model.Address> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Member.Model.Address> modelList = new List<NoName.NetShop.Member.Model.Address>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Member.Model.Address model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Member.Model.Address();
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

