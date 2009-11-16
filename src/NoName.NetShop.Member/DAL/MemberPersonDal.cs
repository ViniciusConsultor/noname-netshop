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
	/// 数据访问类MemberPerson。
	/// </summary>
	public class MemberPerson
	{
		public MemberPerson()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(userid)+1 from umMemberPerson";
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
		public bool Exists(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberPerson_Exists");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);
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
		public void Add(NoName.NetShop.Member.Model.MemberPerson model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberPerson_ADD");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "IdCard", DbType.AnsiString, model.IdCard);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.AddInParameter(dbCommand, "UserLevel", DbType.Int32, model.UserLevel);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberPerson model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberPerson_Update");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "IdCard", DbType.AnsiString, model.IdCard);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.AddInParameter(dbCommand, "UserLevel", DbType.Int32, model.UserLevel);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberPerson_Delete");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.MemberPerson GetModel(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberPerson_GetModel");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			NoName.NetShop.Member.Model.MemberPerson model=null;
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
			strSql.Append("select userid,truename,IdCard,Mobile,TelePhone,Email,UserLevel ");
			strSql.Append(" FROM umMemberPerson ");
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
		public List<NoName.NetShop.Member.Model.MemberPerson> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,truename,IdCard,Mobile,TelePhone,Email,UserLevel ");
			strSql.Append(" FROM umMemberPerson ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Member.Model.MemberPerson> list = new List<NoName.NetShop.Member.Model.MemberPerson>();
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
		public NoName.NetShop.Member.Model.MemberPerson ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.MemberPerson model=new NoName.NetShop.Member.Model.MemberPerson();
			object ojb; 
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			model.truename=dataReader["truename"].ToString();
			model.IdCard=dataReader["IdCard"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.TelePhone=dataReader["TelePhone"].ToString();
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["UserLevel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

