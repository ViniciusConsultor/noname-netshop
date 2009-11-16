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
	/// 数据访问类LoginLog。
	/// </summary>
	public class LoginLog
	{
		public LoginLog()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.LoginLog model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umLoginLog_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "LoginTime", DbType.DateTime, model.LoginTime);
			db.AddInParameter(dbCommand, "IP", DbType.AnsiString, model.IP);
			db.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.LoginLog GetModel(int UserId)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umLoginLog_GetModel");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			NoName.NetShop.Member.Model.LoginLog model=null;
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
			strSql.Append("select UserId,LoginTime,IP ");
			strSql.Append(" FROM umLoginLog ");
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
		public List<NoName.NetShop.Member.Model.LoginLog> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,LoginTime,IP ");
			strSql.Append(" FROM umLoginLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Member.Model.LoginLog> list = new List<NoName.NetShop.Member.Model.LoginLog>();
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
		public NoName.NetShop.Member.Model.LoginLog ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.LoginLog model=new NoName.NetShop.Member.Model.LoginLog();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["LoginTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginTime=(DateTime)ojb;
			}
			model.IP=dataReader["IP"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

