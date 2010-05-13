using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// ���ݷ�����ProductModelDal��
	/// </summary>
	public class ProductModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public ProductModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdProduct";
			
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProduct_Exists");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			int result;
			object obj = dbr.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// �Ƿ����ͬ����Ʒ
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public bool Exists(string ProductName)
        {
            string sql = String.Format("select count(0) from pdproduct where productname = '{0}'", ProductName);
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sql)) > 0;
        }

        /// <summary>
        /// ĳ�������Ƿ������Ʒ
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool CategoryExistsProduct(int CategoryID)
        {
            string sql = "select Count(0) from pdproduct where catepath like( select catepath+'%' from pdcategory where cateid="+CategoryID+")";
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,sql)) > 0;
        }

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Add(ProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProduct_ADD");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			dbw.AddInParameter(dbCommand, "ProductCode", DbType.AnsiString, model.ProductCode);
			dbw.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			dbw.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			dbw.AddInParameter(dbCommand, "ReducePrice", DbType.Decimal, model.ReducePrice);
			dbw.AddInParameter(dbCommand, "Stock", DbType.Int32, model.Stock);
			dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			dbw.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			dbw.AddInParameter(dbCommand, "Keywords", DbType.AnsiString, model.Keywords);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "PageView", DbType.Int32, model.PageView);
			dbw.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			dbw.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
            dbw.AddInParameter(dbCommand, "brandid", DbType.Int32, model.BrandID);
            dbw.AddInParameter(dbCommand, "specifications", DbType.AnsiString, model.Specifications);
            dbw.AddInParameter(dbCommand, "packinglist", DbType.AnsiString, model.PackingList);
            dbw.AddInParameter(dbCommand, "aftersaleservice", DbType.AnsiString, model.AfterSaleService);
            dbw.AddInParameter(dbCommand, "offerset", DbType.AnsiString, model.OfferSet);
            dbw.AddInParameter(dbCommand, "weight", DbType.Decimal, model.Weight);
            dbw.AddInParameter(dbCommand, "StockTip", DbType.AnsiString, model.StockTip);
            dbw.AddInParameter(dbCommand, "RelateProducts", DbType.AnsiString, model.RelateProducts);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(ProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProduct_Update");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			dbw.AddInParameter(dbCommand, "ProductCode", DbType.AnsiString, model.ProductCode);
			dbw.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			dbw.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			dbw.AddInParameter(dbCommand, "ReducePrice", DbType.Decimal, model.ReducePrice);
			dbw.AddInParameter(dbCommand, "Stock", DbType.Int32, model.Stock);
			dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			dbw.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			dbw.AddInParameter(dbCommand, "Keywords", DbType.AnsiString, model.Keywords);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "PageView", DbType.Int32, model.PageView);
			dbw.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			dbw.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
            dbw.AddInParameter(dbCommand, "brandid", DbType.Int32, model.BrandID);
            dbw.AddInParameter(dbCommand, "specifications", DbType.AnsiString, model.Specifications);
            dbw.AddInParameter(dbCommand, "packinglist", DbType.AnsiString, model.PackingList);
            dbw.AddInParameter(dbCommand, "aftersaleservice", DbType.AnsiString, model.AfterSaleService);
            dbw.AddInParameter(dbCommand, "offerset", DbType.AnsiString, model.OfferSet);
            dbw.AddInParameter(dbCommand, "weight", DbType.Decimal, model.Weight);
            dbw.AddInParameter(dbCommand, "StockTip", DbType.AnsiString, model.StockTip);
            dbw.AddInParameter(dbCommand, "RelateProducts", DbType.AnsiString, model.RelateProducts);


			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProduct_Delete");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			dbw.ExecuteNonQuery(dbCommand);
		}

        public void UpdateStatus(int ProductID, ProductStatus status)
        {
            string sql = String.Format("update pdproduct set status = {0} where productid={1}",(int)status,ProductID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void UpdateProductMainImage(int ProductID, string[] ProductImages)
        {
            string sql = "update pdproduct set smallimage=@smallimage,mediumimage=@mediumimage,largeimage=@largeimage where productid=@productid";
            DbCommand Command = dbw.GetSqlStringCommand(sql);

            dbw.AddInParameter(Command, "@smallimage", DbType.String, ProductImages[0]);
            dbw.AddInParameter(Command, "@mediumimage", DbType.String, ProductImages[1]);
            dbw.AddInParameter(Command, "@largeimage", DbType.String, ProductImages[2]);
            dbw.AddInParameter(Command, "@productid", DbType.Int32, ProductID);

            dbw.ExecuteNonQuery(Command);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductModel GetModel(int ProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProduct_GetModel");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			ProductModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM pdProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProduct");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<ProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM pdProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ProductModel> list = new List<ProductModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public ProductModel ReaderBind(IDataReader dataReader)
		{
			ProductModel model=new ProductModel();
			object ojb; 
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			model.ProductCode=dataReader["ProductCode"].ToString();
			model.CatePath=dataReader["CatePath"].ToString();
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			ojb = dataReader["TradePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TradePrice=(decimal)ojb;
			}
			ojb = dataReader["MerchantPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MerchantPrice=(decimal)ojb;
			}
			ojb = dataReader["ReducePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReducePrice=(decimal)ojb;
			}
			ojb = dataReader["Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Stock=(int)ojb;
			}
			model.SmallImage=dataReader["SmallImage"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
			model.LargeImage=dataReader["LargeImage"].ToString();
			model.Keywords=dataReader["Keywords"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			ojb = dataReader["PageView"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PageView=(int)ojb;
			}
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["ChangeTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChangeTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["SortValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SortValue=(int)ojb;
			}
			ojb = dataReader["Score"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Score=(int)ojb;
            }
            ojb = dataReader["brandid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.BrandID = Convert.ToInt32(ojb);
            }

            model.Specifications = Convert.ToString(dataReader["Specifications"]);
            model.PackingList = Convert.ToString(dataReader["PackingList"]);
            model.AfterSaleService = Convert.ToString(dataReader["AfterSaleService"]);
            model.OfferSet = Convert.ToString(dataReader["OfferSet"]);
            model.Weight = Convert.ToDecimal(dataReader["weight"]);
            model.StockTip = Convert.ToString(dataReader["stocktip"]);
            model.RelateProducts = Convert.ToString(dataReader["RelateProducts"]);
			return model;
		}

		#endregion  ��Ա����
	}
}

