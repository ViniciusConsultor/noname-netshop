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
	/// ���ݷ�����ProductImageModelDal��
	/// </summary>
	public class ProductImageModelDal
	{
		public ProductImageModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ImageId)+1 from pdProductImage";
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
		public bool Exists(int ImageId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProductImage_Exists");
			db.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);
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
		public void Add(ProductImageModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProductImage_ADD");
			db.AddInParameter(dbCommand, "ImageId", DbType.Int32, model.ImageId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			db.AddInParameter(dbCommand, "OriginImage", DbType.AnsiString, model.OriginImage);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(ProductImageModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProductImage_Update");
			db.AddInParameter(dbCommand, "ImageId", DbType.Int32, model.ImageId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
			db.AddInParameter(dbCommand, "OriginImage", DbType.AnsiString, model.OriginImage);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ImageId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProductImage_Delete");
			db.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductImageModel GetModel(int ImageId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdProductImage_GetModel");
			db.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);

			ProductImageModel model=null;
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
			strSql.Append("select ImageId,ProductId,SmallImage,LargeImage,OriginImage,Title ");
			strSql.Append(" FROM pdProductImage ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProductImage");
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

		#endregion  ��Ա����
	}
}

