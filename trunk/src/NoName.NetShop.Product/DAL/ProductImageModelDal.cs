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
	/// 数据访问类ProductImageModelDal。
	/// </summary>
	public class ProductImageModelDal
    {
        private Database dbw = DBFacroty.DbWriter;
        private Database dbr = DBFacroty.DbReader;

		public ProductImageModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ImageId)+1 from pdProductImage";
			
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ImageId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductImage_Exists");
			dbr.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);
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
		///  增加一条数据
		/// </summary>
		public void Add(ProductImageModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductImage_ADD");
			dbw.AddInParameter(dbCommand, "ImageId", DbType.Int32, model.ImageId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			dbw.AddInParameter(dbCommand, "OriginImage", DbType.AnsiString, model.OriginImage);
			dbw.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(ProductImageModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductImage_Update");
			dbw.AddInParameter(dbCommand, "ImageId", DbType.Int32, model.ImageId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			dbw.AddInParameter(dbCommand, "OriginImage", DbType.AnsiString, model.OriginImage);
			dbw.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ImageId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductImage_Delete");
			dbw.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductImageModel GetModel(int ImageId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductImage_GetModel");
			dbr.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);

			ProductImageModel model=null;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ImageId,ProductId,SmallImage,LargeImage,OriginImage,Title ");
			strSql.Append(" FROM pdProductImage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProductImage");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<ProductImageModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ImageId,ProductId,SmallImage,LargeImage,OriginImage,Title ");
			strSql.Append(" FROM pdProductImage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ProductImageModel> list = new List<ProductImageModel>();
			
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
		/// 对象实体绑定数据
		/// </summary>
		public ProductImageModel ReaderBind(IDataReader dataReader)
		{
			ProductImageModel model=new ProductImageModel();
			object ojb; 
			ojb = dataReader["ImageId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageId=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			model.SmallImage=dataReader["SmallImage"].ToString();
			model.LargeImage=dataReader["LargeImage"].ToString();
			model.OriginImage=dataReader["OriginImage"].ToString();
			model.Title=dataReader["Title"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

