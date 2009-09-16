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
	/// ���ݷ�����BrandModelDal��
	/// </summary>
	public class BrandModelDal
	{
		public BrandModelDal()
		{}

		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(BrandId)+1 from pdBrand";
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
		public bool Exists(int BrandId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdBrand_Exists");
			db.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);
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
		public void Add(BrandModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdBrand_ADD");
			db.AddInParameter(dbCommand, "BrandId", DbType.Int32, model.BrandId);
			db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, model.BrandName);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "BrandLogo", DbType.AnsiString, model.BrandLogo);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(BrandModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdBrand_Update");
			db.AddInParameter(dbCommand, "BrandId", DbType.Int32, model.BrandId);
			db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, model.BrandName);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "BrandLogo", DbType.AnsiString, model.BrandLogo);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int BrandId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdBrand_Delete");
			db.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public BrandModel GetModel(int BrandId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdBrand_GetModel");
			db.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);

			BrandModel model=null;
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
			strSql.Append("select BrandId,BrandName,CateId,CatePath,BrandLogo,Brief ");
			strSql.Append(" FROM pdBrand ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdBrand");
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
		public List<BrandModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BrandId,BrandName,CateId,CatePath,BrandLogo,Brief ");
			strSql.Append(" FROM pdBrand ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<BrandModel> list = new List<BrandModel>();
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
		public BrandModel ReaderBind(IDataReader dataReader)
		{
			BrandModel model=new BrandModel();
			object ojb; 
			ojb = dataReader["BrandId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BrandId=(int)ojb;
			}
			model.BrandName=dataReader["BrandName"].ToString();
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.CatePath=dataReader["CatePath"].ToString();
			model.BrandLogo=dataReader["BrandLogo"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

