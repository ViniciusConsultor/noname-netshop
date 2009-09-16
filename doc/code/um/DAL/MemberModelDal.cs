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
	/// ���ݷ�����MemberModelDal��
	/// </summary>
	public class MemberModelDal
	{
		public MemberModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(UserId)+1 from umMember";
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
		public bool Exists(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Exists");
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
		public void Add(NoName.NetShop.Model.MemberModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "NickName", DbType.AnsiString, model.NickName);
			db.AddInParameter(dbCommand, "AllScore", DbType.Int32, model.AllScore);
			db.AddInParameter(dbCommand, "CurScore", DbType.Int32, model.CurScore);
			db.AddInParameter(dbCommand, "LastLogin", DbType.DateTime, model.LastLogin);
			db.AddInParameter(dbCommand, "LoginIP", DbType.AnsiString, model.LoginIP);
			db.AddInParameter(dbCommand, "RegisterTime", DbType.DateTime, model.RegisterTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.MemberModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "NickName", DbType.AnsiString, model.NickName);
			db.AddInParameter(dbCommand, "AllScore", DbType.Int32, model.AllScore);
			db.AddInParameter(dbCommand, "CurScore", DbType.Int32, model.CurScore);
			db.AddInParameter(dbCommand, "LastLogin", DbType.DateTime, model.LastLogin);
			db.AddInParameter(dbCommand, "LoginIP", DbType.AnsiString, model.LoginIP);
			db.AddInParameter(dbCommand, "RegisterTime", DbType.DateTime, model.RegisterTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Delete");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.MemberModel GetModel(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_GetModel");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			NoName.NetShop.Model.MemberModel model=null;
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
			strSql.Append("select UserId,UserEmail,Password,NickName,AllScore,CurScore,LastLogin,LoginIP,RegisterTime,ModifyTime ");
			strSql.Append(" FROM umMember ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "umMember");
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
		public List<NoName.NetShop.Model.MemberModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,UserEmail,Password,NickName,AllScore,CurScore,LastLogin,LoginIP,RegisterTime,ModifyTime ");
			strSql.Append(" FROM umMember ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.MemberModel> list = new List<NoName.NetShop.Model.MemberModel>();
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
		public NoName.NetShop.Model.MemberModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.MemberModel model=new NoName.NetShop.Model.MemberModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			model.UserEmail=dataReader["UserEmail"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.NickName=dataReader["NickName"].ToString();
			ojb = dataReader["AllScore"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AllScore=(int)ojb;
			}
			ojb = dataReader["CurScore"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CurScore=(int)ojb;
			}
			ojb = dataReader["LastLogin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LastLogin=(DateTime)ojb;
			}
			model.LoginIP=dataReader["LoginIP"].ToString();
			ojb = dataReader["RegisterTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RegisterTime=(DateTime)ojb;
			}
			ojb = dataReader["ModifyTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ModifyTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

