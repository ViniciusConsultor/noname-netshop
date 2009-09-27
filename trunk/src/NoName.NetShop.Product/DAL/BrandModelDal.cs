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
	/// ���ݷ�����BrandModelDal��
	/// </summary>
	public class BrandModelDal
	{
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public BrandModelDal()
		{}

		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(BrandId)+1 from pdBrand";
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
		public bool Exists(int BrandId)
		{
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdBrand_Exists");
			dbr.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);
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
		public void Add(BrandModel model)
		{
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdBrand_ADD");
			dbw.AddInParameter(dbCommand, "BrandId", DbType.Int32, model.BrandId);
			dbw.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, model.BrandName);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			dbw.AddInParameter(dbCommand, "BrandLogo", DbType.AnsiString, model.BrandLogo);
            dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
            dbw.AddInParameter(dbCommand, "showorder", DbType.Int32, model.ShowOrder);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(BrandModel model)
		{
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdBrand_Update");
			dbw.AddInParameter(dbCommand, "BrandId", DbType.Int32, model.BrandId);
			dbw.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, model.BrandName);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			dbw.AddInParameter(dbCommand, "BrandLogo", DbType.AnsiString, model.BrandLogo);
            dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
            dbw.AddInParameter(dbCommand, "showorder", DbType.Int32, model.ShowOrder);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int BrandId)
		{
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdBrand_Delete");
			dbw.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public BrandModel GetModel(int BrandId)
		{
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdBrand_GetModel");
			dbr.AddInParameter(dbCommand, "BrandId", DbType.Int32,BrandId);

			BrandModel model=null;
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
            StringBuilder strSql = new StringBuilder();
			strSql.Append("select BrandId,BrandName,CateId,CatePath,BrandLogo,Brief ");
			strSql.Append(" FROM pdBrand ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdBrand");
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
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        public int SwitchOrder(int InitialBrandID,int ReplacedBrandID)
        {            
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdBrand_ChangeOrder");

            dbr.AddInParameter(dbCommand, "@initialbrandid", DbType.Int32, InitialBrandID);
            dbr.AddInParameter(dbCommand, "@replacedbrandid", DbType.Int32, ReplacedBrandID);

            return dbw.ExecuteNonQuery(dbCommand); 
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
            model.ShowOrder = int.Parse(dataReader["showorder"].ToString());
			return model;
		}

		#endregion  ��Ա����
	}
}

