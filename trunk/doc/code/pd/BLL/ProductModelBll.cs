using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���ProductModelBll ��ժҪ˵����
	/// </summary>
	public class ProductModelBll
	{
		private readonly NoName.NetShop.DAL.ProductModelDal dal=new NoName.NetShop.DAL.ProductModelDal();
		public ProductModelBll()
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
		public bool Exists(int ProductId)
		{
			return dal.Exists(ProductId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.ProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.ProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId)
		{
			
			dal.Delete(ProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.ProductModel GetModel(int ProductId)
		{
			
			return dal.GetModel(ProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.ProductModel GetModelByCache(int ProductId)
		{
			
			string CacheKey = "ProductModelModel-" + ProductId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.ProductModel)objModel;
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
		public List<NoName.NetShop.Model.ProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.ProductModel> modelList = new List<NoName.NetShop.Model.ProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.ProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.ProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					model.ProductName=ds.Tables[0].Rows[n]["ProductName"].ToString();
					model.ProductCode=ds.Tables[0].Rows[n]["ProductCode"].ToString();
					model.CatePath=ds.Tables[0].Rows[n]["CatePath"].ToString();
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["TradePrice"].ToString()!="")
					{
						model.TradePrice=decimal.Parse(ds.Tables[0].Rows[n]["TradePrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["MerchantPrice"].ToString()!="")
					{
						model.MerchantPrice=decimal.Parse(ds.Tables[0].Rows[n]["MerchantPrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ReducePrice"].ToString()!="")
					{
						model.ReducePrice=decimal.Parse(ds.Tables[0].Rows[n]["ReducePrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Stock"].ToString()!="")
					{
						model.Stock=int.Parse(ds.Tables[0].Rows[n]["Stock"].ToString());
					}
					model.SmallImage=ds.Tables[0].Rows[n]["SmallImage"].ToString();
					model.MediumImage=ds.Tables[0].Rows[n]["MediumImage"].ToString();
					model.LargeImage=ds.Tables[0].Rows[n]["LargeImage"].ToString();
					model.Keywords=ds.Tables[0].Rows[n]["Keywords"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					if(ds.Tables[0].Rows[n]["PageView"].ToString()!="")
					{
						model.PageView=int.Parse(ds.Tables[0].Rows[n]["PageView"].ToString());
					}
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ChangeTime"].ToString()!="")
					{
						model.ChangeTime=DateTime.Parse(ds.Tables[0].Rows[n]["ChangeTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SortValue"].ToString()!="")
					{
						model.SortValue=int.Parse(ds.Tables[0].Rows[n]["SortValue"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Score"].ToString()!="")
					{
						model.Score=int.Parse(ds.Tables[0].Rows[n]["Score"].ToString());
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

