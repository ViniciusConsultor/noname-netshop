using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���SupplyDemandModelBll ��ժҪ˵����
	/// </summary>
	public class SupplyDemandModelBll
	{
		private readonly NoName.NetShop.DAL.SupplyDemandModelDal dal=new NoName.NetShop.DAL.SupplyDemandModelDal();
		public SupplyDemandModelBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int sdId)
		{
			return dal.Exists(sdId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.SupplyDemandModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.SupplyDemandModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int sdId)
		{
			
			dal.Delete(sdId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.SupplyDemandModel GetModel(int sdId)
		{
			
			return dal.GetModel(sdId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.SupplyDemandModel GetModelByCache(int sdId)
		{
			
			string CacheKey = "SupplyDemandModelModel-" + sdId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sdId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.SupplyDemandModel)objModel;
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
		public List<NoName.NetShop.Model.SupplyDemandModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.SupplyDemandModel> modelList = new List<NoName.NetShop.Model.SupplyDemandModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.SupplyDemandModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.SupplyDemandModel();
					if(ds.Tables[0].Rows[n]["sdId"].ToString()!="")
					{
						model.sdId=int.Parse(ds.Tables[0].Rows[n]["sdId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["sdType"].ToString()!="")
					{
						model.sdType=int.Parse(ds.Tables[0].Rows[n]["sdType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["userId"].ToString()!="")
					{
						model.userId=int.Parse(ds.Tables[0].Rows[n]["userId"].ToString());
					}
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(ds.Tables[0].Rows[n]["ModifyTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
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

