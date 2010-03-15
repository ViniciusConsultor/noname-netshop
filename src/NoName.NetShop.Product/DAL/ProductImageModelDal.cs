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
	/// ���ݷ�����ProductImageModelDal��
	/// </summary>
	public class ProductImageModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public ProductImageModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
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
		/// �Ƿ���ڸü�¼
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
		///  ����һ������
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
		///  ����һ������
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
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ImageId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductImage_Delete");
			dbw.AddInParameter(dbCommand, "ImageId", DbType.Int32,ImageId);

			dbw.ExecuteNonQuery(dbCommand);
		}

        public void SwitchOrder(int OrginalID, int SwitchedID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdProductImage_SwitchOrder");

            dbw.AddInParameter(Command, "@OriginalImageID", DbType.Int32, OrginalID);
            dbw.AddInParameter(Command, "@SwitchedImageID", DbType.Int32, SwitchedID);

            dbw.ExecuteDataSet(Command);
        }

		/// <summary>
		/// �õ�һ������ʵ��
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM pdProductImage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by ordervalue desc");
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<ProductImageModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
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

