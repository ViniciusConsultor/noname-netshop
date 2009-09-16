using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���OrderChangeLogModelBll ��ժҪ˵����
	/// </summary>
	public class OrderChangeLogModelBll
	{
		private readonly NoName.NetShop.DAL.OrderChangeLogModelDal dal=new NoName.NetShop.DAL.OrderChangeLogModelDal();
		public OrderChangeLogModelBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.OrderChangeLogModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.OrderChangeLogModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			dal.Delete();
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.OrderChangeLogModel GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel();
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.OrderChangeLogModel GetModelByCache()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			string CacheKey = "OrderChangeLogModelModel-" ;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.OrderChangeLogModel)objModel;
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
		public List<NoName.NetShop.Model.OrderChangeLogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.OrderChangeLogModel> modelList = new List<NoName.NetShop.Model.OrderChangeLogModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.OrderChangeLogModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.OrderChangeLogModel();
					if(ds.Tables[0].Rows[n]["OrderId"].ToString()!="")
					{
						model.OrderId=int.Parse(ds.Tables[0].Rows[n]["OrderId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ChangeTime"].ToString()!="")
					{
						model.ChangeTime=DateTime.Parse(ds.Tables[0].Rows[n]["ChangeTime"].ToString());
					}
					model.Remark=ds.Tables[0].Rows[n]["Remark"].ToString();
					model.Operator=ds.Tables[0].Rows[n]["Operator"].ToString();
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

