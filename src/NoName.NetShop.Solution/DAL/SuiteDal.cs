using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Common;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ���ݷ�����Suite��
	/// </summary>
	public class SuiteDal
	{
		public SuiteDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SuiteId)+1 from slSuite";
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
		public bool Exists(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Exists");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
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
		public void Save(NoName.NetShop.Solution.SuiteModel model)
		{
            if (model.SuiteId == 0)
                model.SuiteId = CommDataHelper.GetNewSerialNum(AppType.Solution);
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Save");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			db.AddInParameter(dbCommand, "SuiteName", DbType.AnsiString, model.SuiteName);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			db.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Delete");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SuiteModel GetModel(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_GetModel");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);

			NoName.NetShop.Solution.SuiteModel model=null;
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
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<NoName.NetShop.Solution.SuiteModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SuiteId,ScenceId,SuiteName,SmallImage,MediumImage,Price,Remark,Score ");
			strSql.Append(" FROM slSuite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SuiteModel> list = new List<NoName.NetShop.Solution.SuiteModel>();
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
		public NoName.NetShop.Solution.SuiteModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SuiteModel model=new NoName.NetShop.Solution.SuiteModel();
			object ojb; 
			ojb = dataReader["SuiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuiteId=(int)ojb;
			}
			ojb = dataReader["ScenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ScenceId=(int)ojb;
			}
			model.SuiteName=dataReader["SuiteName"].ToString();
			model.SmallImage=dataReader["SmallImage"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
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

