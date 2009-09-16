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
	/// ���ݷ�����VoteRemarkModelDal��
	/// </summary>
	public class VoteRemarkModelDal
	{
		public VoteRemarkModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(VoteId)+1 from voVoteRemark";
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
		public bool Exists(int VoteId,int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_Exists");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);
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
		public void Add(NoName.NetShop.Model.VoteRemarkModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_ADD");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "VoteTime", DbType.DateTime, model.VoteTime);
			db.AddInParameter(dbCommand, "VoteIP", DbType.AnsiString, model.VoteIP);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteRemarkModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_Update");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "VoteTime", DbType.DateTime, model.VoteTime);
			db.AddInParameter(dbCommand, "VoteIP", DbType.AnsiString, model.VoteIP);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int VoteId,int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_Delete");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.VoteRemarkModel GetModel(int VoteId,int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_GetModel");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			NoName.NetShop.Model.VoteRemarkModel model=null;
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
			strSql.Append("select VoteId,UserId,Remark,VoteTime,VoteIP ");
			strSql.Append(" FROM voVoteRemark ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "voVoteRemark");
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
		public List<NoName.NetShop.Model.VoteRemarkModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VoteId,UserId,Remark,VoteTime,VoteIP ");
			strSql.Append(" FROM voVoteRemark ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.VoteRemarkModel> list = new List<NoName.NetShop.Model.VoteRemarkModel>();
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
		public NoName.NetShop.Model.VoteRemarkModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.VoteRemarkModel model=new NoName.NetShop.Model.VoteRemarkModel();
			object ojb; 
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["VoteTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteTime=(DateTime)ojb;
			}
			model.VoteIP=dataReader["VoteIP"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

