using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace NoName.NetShop.UserManager.DAL
{
	/// <summary>
	/// 数据访问类MemberCompany。
	/// </summary>
	public class MemberCompany
	{
		public MemberCompany()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberCompany_Exists");
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
		public void Add(NoName.NetShop.UserManager.Model.MemberCompany model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberCompany_ADD");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "idcard", DbType.AnsiString, model.idcard);
			db.AddInParameter(dbCommand, "companyname", DbType.AnsiString, model.companyname);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Fax", DbType.AnsiString, model.Fax);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.MemberCompany model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberCompany_Update");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "idcard", DbType.AnsiString, model.idcard);
			db.AddInParameter(dbCommand, "companyname", DbType.AnsiString, model.companyname);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Fax", DbType.AnsiString, model.Fax);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberCompany_Delete");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.UserManager.Model.MemberCompany GetModel(int userid)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberCompany_GetModel");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			NoName.NetShop.UserManager.Model.MemberCompany model=null;
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
			strSql.Append("select userid,truename,idcard,companyname,province,city,county,Mobile,TelePhone,Fax,Email ");
			strSql.Append(" FROM umMemberCompany ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.MemberCompany> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,truename,idcard,companyname,province,city,county,Mobile,TelePhone,Fax,Email ");
			strSql.Append(" FROM umMemberCompany ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.UserManager.Model.MemberCompany> list = new List<NoName.NetShop.UserManager.Model.MemberCompany>();
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		public NoName.NetShop.UserManager.Model.MemberCompany ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.UserManager.Model.MemberCompany model=new NoName.NetShop.UserManager.Model.MemberCompany();
			object ojb; 
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			model.truename=dataReader["truename"].ToString();
			model.idcard=dataReader["idcard"].ToString();
			model.companyname=dataReader["companyname"].ToString();
			model.province=dataReader["province"].ToString();
			model.city=dataReader["city"].ToString();
			model.county=dataReader["county"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.TelePhone=dataReader["TelePhone"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Email=dataReader["Email"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

