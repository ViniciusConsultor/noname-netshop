using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���VoteGroupModelBll ��ժҪ˵����
	/// </summary>
	public class VoteGroupModelBll
	{
		private readonly NoName.NetShop.DAL.VoteGroupModelDal dal=new NoName.NetShop.DAL.VoteGroupModelDal();
		public VoteGroupModelBll()
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
		public bool Exists(int VoteGroupId)
		{
			return dal.Exists(VoteGroupId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.VoteGroupModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteGroupModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int VoteGroupId)
		{
			
			dal.Delete(VoteGroupId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.VoteGroupModel GetModel(int VoteGroupId)
		{
			
			return dal.GetModel(VoteGroupId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.VoteGroupModel GetModelByCache(int VoteGroupId)
		{
			
			string CacheKey = "VoteGroupModelModel-" + VoteGroupId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VoteGroupId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.VoteGroupModel)objModel;
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
		public List<NoName.NetShop.Model.VoteGroupModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.VoteGroupModel> modelList = new List<NoName.NetShop.Model.VoteGroupModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.VoteGroupModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.VoteGroupModel();
					if(ds.Tables[0].Rows[n]["VoteGroupId"].ToString()!="")
					{
						model.VoteGroupId=int.Parse(ds.Tables[0].Rows[n]["VoteGroupId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["VoteId"].ToString()!="")
					{
						model.VoteId=int.Parse(ds.Tables[0].Rows[n]["VoteId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["GroupType"].ToString()!="")
					{
						model.GroupType=int.Parse(ds.Tables[0].Rows[n]["GroupType"].ToString());
					}
					model.Subject=ds.Tables[0].Rows[n]["Subject"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
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

