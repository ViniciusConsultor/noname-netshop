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
	/// ���ݷ�����VoteTopicModelDal��
	/// </summary>
	public class VoteTopicModelDal
	{
		public VoteTopicModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(VoteId)+1 from voVoteTopic";
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
		public bool Exists(int VoteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_Exists");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);
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
		public void Add(NoName.NetShop.Model.VoteTopicModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_ADD");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.AddInParameter(dbCommand, "Topic", DbType.AnsiString, model.Topic);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "IsRegUser", DbType.Boolean, model.IsRegUser);
			db.AddInParameter(dbCommand, "VoteUserNum", DbType.Int32, model.VoteUserNum);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteTopicModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_Update");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.AddInParameter(dbCommand, "Topic", DbType.AnsiString, model.Topic);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "IsRegUser", DbType.Boolean, model.IsRegUser);
			db.AddInParameter(dbCommand, "VoteUserNum", DbType.Int32, model.VoteUserNum);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int VoteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_Delete");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.VoteTopicModel GetModel(int VoteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_GetModel");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);

			NoName.NetShop.Model.VoteTopicModel model=null;
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
			strSql.Append("select VoteId,ContentId,ContentType,Topic,Remark,StartTime,EndTime,IsRegUser,VoteUserNum ");
			strSql.Append(" FROM voVoteTopic ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "voVoteTopic");
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
		public List<NoName.NetShop.Model.VoteTopicModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VoteId,ContentId,ContentType,Topic,Remark,StartTime,EndTime,IsRegUser,VoteUserNum ");
			strSql.Append(" FROM voVoteTopic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.VoteTopicModel> list = new List<NoName.NetShop.Model.VoteTopicModel>();
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
		public NoName.NetShop.Model.VoteTopicModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.VoteTopicModel model=new NoName.NetShop.Model.VoteTopicModel();
			object ojb; 
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			ojb = dataReader["ContentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentId=(int)ojb;
			}
			ojb = dataReader["ContentType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentType=(int)ojb;
			}
			model.Topic=dataReader["Topic"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["StartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartTime=(DateTime)ojb;
			}
			ojb = dataReader["EndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndTime=(DateTime)ojb;
			}
			ojb = dataReader["IsRegUser"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRegUser=(bool)ojb;
			}
			ojb = dataReader["VoteUserNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteUserNum=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

