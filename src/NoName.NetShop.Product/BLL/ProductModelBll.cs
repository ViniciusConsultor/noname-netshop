using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类ProductModelBll 的摘要说明。
	/// </summary>
	public class ProductModelBll
	{
		private readonly ProductModelDal dal=new ProductModelDal();
		public ProductModelBll()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductId)
		{
			return dal.Exists(ProductId);
		}


        public bool Exists(string ProductName)
        {
            return dal.Exists(ProductName);
        }

        public bool CategoryExistsProduct(int CategoryID)
        {
            return dal.CategoryExistsProduct(CategoryID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId)
		{			
			dal.Delete(ProductId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductModel GetModel(int ProductId)
		{
			
			return dal.GetModel(ProductId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ProductModel> modelList = new List<ProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ProductModel();
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        public DataSet GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = " productid desc";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "productid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 "+Condition;
            info.TableName = "pdproduct";
            info.TotalFieldStr = "";

            DataSet ds = CommDataHelper.GetDataFromSingleTableByPage(info);

            RecordCount = info.TotalItem;

            return ds;
        }


        public void UpdateStatus(int ProductID, ProductStatus status)
        {
            dal.UpdateStatus(ProductID, status);
        }


        public void UpdateProductMainImage(int ProductID, string[] ProductImages)
        {
            dal.UpdateProductMainImage(ProductID,ProductImages);
        }

        

		#endregion  成员方法
	}
}

