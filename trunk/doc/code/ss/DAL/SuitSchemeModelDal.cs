using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Maticsoft.DBUtility;//�����������
namespace NoName.NetShop.DAL
{
	/// <summary>
	/// ���ݷ�����SuitSchemeModelDal��
	/// </summary>
	public class SuitSchemeModelDal
	{
		public SuitSchemeModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SchemeId)+1 from ssSuitScheme";
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
		public bool Exists(int SchemeId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssSuitScheme_Exists");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);
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
		public void Add(NoName.NetShop.Model.SuitSchemeModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssSuitScheme_ADD");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32, model.SchemeId);
			db.AddInParameter(dbCommand, "SchemeName", DbType.AnsiString, model.SchemeName);
			db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "SchemeDesc", DbType.AnsiString, model.SchemeDesc);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.SuitSchemeModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssSuitScheme_Update");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32, model.SchemeId);
			db.AddInParameter(dbCommand, "SchemeName", DbType.AnsiString, model.SchemeName);
			db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "SchemeDesc", DbType.AnsiString, model.SchemeDesc);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SchemeId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssSuitScheme_Delete");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.SuitSchemeModel GetModel(int SchemeId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssSuitScheme_GetModel");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);

			NoName.NetShop.Model.SuitSchemeModel model=null;
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
			strSql.Append("select SchemeId,SchemeName,CreateTime,Status,SchemeDesc ");
			strSql.Append(" FROM ssSuitScheme ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ssSuitScheme");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<NoName.NetShop.Model.SuitSchemeModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SchemeId,SchemeName,CreateTime,Status,SchemeDesc ");
			strSql.Append(" FROM ssSuitScheme ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.SuitSchemeModel> list = new List<NoName.NetShop.Model.SuitSchemeModel>();
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
		public NoName.NetShop.Model.SuitSchemeModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.SuitSchemeModel model=new NoName.NetShop.Model.SuitSchemeModel();
			object ojb; 
			ojb = dataReader["SchemeId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SchemeId=(int)ojb;
			}
			model.SchemeName=dataReader["SchemeName"].ToString();
			ojb = dataReader["CreateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.SchemeDesc=dataReader["SchemeDesc"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

