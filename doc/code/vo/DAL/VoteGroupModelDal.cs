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
	/// ���ݷ�����VoteGroupModelDal��
	/// </summary>
	public class VoteGroupModelDal
	{
		public VoteGroupModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(VoteGroupId)+1 from voVoteGroup";
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
		public bool Exists(int VoteGroupId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteGroup_Exists");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32,VoteGroupId);
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
		public void Add(NoName.NetShop.Model.VoteGroupModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteGroup_ADD");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32, model.VoteGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "GroupType", DbType.Byte, model.GroupType);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteGroupModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteGroup_Update");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32, model.VoteGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "GroupType", DbType.Byte, model.GroupType);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int VoteGroupId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteGroup_Delete");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32,VoteGroupId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.VoteGroupModel GetModel(int VoteGroupId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteGroup_GetModel");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32,VoteGroupId);

			NoName.NetShop.Model.VoteGroupModel model=null;
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
			strSql.Append("select VoteGroupId,VoteId,GroupType,Subject,Content ");
			strSql.Append(" FROM voVoteGroup ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "voVoteGroup");
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
		public List<NoName.NetShop.Model.VoteGroupModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VoteGroupId,VoteId,GroupType,Subject,Content ");
			strSql.Append(" FROM voVoteGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.VoteGroupModel> list = new List<NoName.NetShop.Model.VoteGroupModel>();
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
		public NoName.NetShop.Model.VoteGroupModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.VoteGroupModel model=new NoName.NetShop.Model.VoteGroupModel();
			object ojb; 
			ojb = dataReader["VoteGroupId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteGroupId=(int)ojb;
			}
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			ojb = dataReader["GroupType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupType=(int)ojb;
			}
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

