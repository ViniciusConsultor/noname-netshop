using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace NoName.NetShop.Member.DAL
{
	/// <summary>
	/// 数据访问类MemberFamly。
	/// </summary>
	public class MemberFamly
	{
		public MemberFamly()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(userId)+1 from umMemberFamly";
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;

			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userId)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberFamly_Exists");
			db.AddInParameter(dbCommand, "userId", DbType.Int32,userId);
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
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.MemberFamly model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberFamly_ADD");
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "idcard", DbType.AnsiString, model.idcard);
			db.AddInParameter(dbCommand, "Address", DbType.AnsiString, model.Address);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberFamly model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberFamly_Update");
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "idcard", DbType.AnsiString, model.idcard);
			db.AddInParameter(dbCommand, "Address", DbType.AnsiString, model.Address);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userId)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberFamly_Delete");
			db.AddInParameter(dbCommand, "userId", DbType.Int32,userId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.MemberFamly GetModel(int userId)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberFamly_GetModel");
			db.AddInParameter(dbCommand, "userId", DbType.Int32,userId);

			NoName.NetShop.Member.Model.MemberFamly model=null;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userId,truename,idcard,Address,province,city,county,Mobile,TelePhone,Email ");
			strSql.Append(" FROM umMemberFamly ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Member.Model.MemberFamly> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userId,truename,idcard,Address,province,city,county,Mobile,TelePhone,Email ");
			strSql.Append(" FROM umMemberFamly ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Member.Model.MemberFamly> list = new List<NoName.NetShop.Member.Model.MemberFamly>();
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
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
		/// 对象实体绑定数据
		/// </summary>
		public NoName.NetShop.Member.Model.MemberFamly ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.MemberFamly model=new NoName.NetShop.Member.Model.MemberFamly();
			object ojb; 
			ojb = dataReader["userId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userId=(int)ojb;
			}
			model.truename=dataReader["truename"].ToString();
			model.idcard=dataReader["idcard"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.province=dataReader["province"].ToString();
			model.city=dataReader["city"].ToString();
			model.county=dataReader["county"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.TelePhone=dataReader["TelePhone"].ToString();
			model.Email=dataReader["Email"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

