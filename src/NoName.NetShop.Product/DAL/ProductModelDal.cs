using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// ���ݷ�����ProductModelDal��
	/// </summary>
	public class ProductModelDal
	{
		public ProductModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdProduct";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
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
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProduct_Exists");
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
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
		///  ����һ������
		/// </summary>
		public void Add(ProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProduct_ADD");
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "ProductCode", DbType.AnsiString, model.ProductCode);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			db.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			db.AddInParameter(dbCommand, "ReducePrice", DbType.Decimal, model.ReducePrice);
			db.AddInParameter(dbCommand, "Stock", DbType.Int32, model.Stock);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			db.AddInParameter(dbCommand, "Keywords", DbType.AnsiString, model.Keywords);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "PageView", DbType.Int32, model.PageView);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(ProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProduct_Update");
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "ProductCode", DbType.AnsiString, model.ProductCode);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			db.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			db.AddInParameter(dbCommand, "ReducePrice", DbType.Decimal, model.ReducePrice);
			db.AddInParameter(dbCommand, "Stock", DbType.Int32, model.Stock);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			db.AddInParameter(dbCommand, "Keywords", DbType.AnsiString, model.Keywords);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "PageView", DbType.Int32, model.PageView);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProduct_Delete");
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductModel GetModel(int ProductId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProduct_GetModel");
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			ProductModel model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
			strSql.Append("select ProductId,ProductName,ProductCode,CatePath,CateId,TradePrice,MerchantPrice,ReducePrice,Stock,SmallImage,MediumImage,LargeImage,Keywords,Brief,PageView,InsertTime,ChangeTime,Status,SortValue,Score ");
			strSql.Append(" FROM pdProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProduct");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<ProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,ProductName,ProductCode,CatePath,CateId,TradePrice,MerchantPrice,ReducePrice,Stock,SmallImage,MediumImage,LargeImage,Keywords,Brief,PageView,InsertTime,ChangeTime,Status,SortValue,Score ");
			strSql.Append(" FROM pdProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ProductModel> list = new List<ProductModel>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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
				model.Status=(int)ojb;
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
			return model;
		}

		#endregion  ��Ա����
	}
}

