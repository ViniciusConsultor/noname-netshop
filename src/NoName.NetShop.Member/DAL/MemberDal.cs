using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Member.Model;

namespace NoName.NetShop.UserManager.DAL
{
	/// <summary>
	/// 数据访问类Member。
	/// </summary>
	public class Member
	{
		public Member()
		{}
		#region  成员方法


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userEmail)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Exists");
            db.AddInParameter(dbCommand, "userEmail", DbType.Int32, userEmail);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            int.TryParse(obj.ToString(), out result);
            if (result == 1)
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
		public void Add(NoName.NetShop.UserManager.Model.MemberModel model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_ADD");
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "NickName", DbType.AnsiString, model.NickName);
			db.AddInParameter(dbCommand, "AllScore", DbType.Int32, model.AllScore);
			db.AddInParameter(dbCommand, "CurScore", DbType.Int32, model.CurScore);
			db.AddInParameter(dbCommand, "LastLogin", DbType.DateTime, model.LastLogin);
			db.AddInParameter(dbCommand, "LoginIP", DbType.AnsiString, model.LoginIP);
			db.AddInParameter(dbCommand, "RegisterTime", DbType.DateTime, model.RegisterTime);
			db.AddInParameter(dbCommand, "UserType", DbType.Byte, model.UserType);
			db.AddInParameter(dbCommand, "status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.MemberModel model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Update");
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "NickName", DbType.AnsiString, model.NickName);
			db.AddInParameter(dbCommand, "AllScore", DbType.Int32, model.AllScore);
			db.AddInParameter(dbCommand, "CurScore", DbType.Int32, model.CurScore);
			db.AddInParameter(dbCommand, "LastLogin", DbType.DateTime, model.LastLogin);
			db.AddInParameter(dbCommand, "LoginIP", DbType.AnsiString, model.LoginIP);
			db.AddInParameter(dbCommand, "RegisterTime", DbType.DateTime, model.RegisterTime);
			db.AddInParameter(dbCommand, "UserType", DbType.Byte, model.UserType);
			db.AddInParameter(dbCommand, "status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userId)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_Delete");
			db.AddInParameter(dbCommand, "userId", DbType.Int32,userId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.UserManager.Model.MemberModel GetModel(int userId)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_GetModel");
			db.AddInParameter(dbCommand, "userId", DbType.Int32,userId);

			NoName.NetShop.UserManager.Model.MemberModel model=null;
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
			strSql.Append("select userId,UserEmail,Password,NickName,AllScore,CurScore,LastLogin,LoginIP,RegisterTime,ModifyTime,UserType,status ");
			strSql.Append(" FROM umMember ");
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
		public List<NoName.NetShop.UserManager.Model.MemberModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userId,UserEmail,Password,NickName,AllScore,CurScore,LastLogin,LoginIP,RegisterTime,ModifyTime,UserType,status ");
			strSql.Append(" FROM umMember ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.UserManager.Model.MemberModel> list = new List<NoName.NetShop.UserManager.Model.MemberModel>();
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
		public NoName.NetShop.UserManager.Model.MemberModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.UserManager.Model.MemberModel model=new NoName.NetShop.UserManager.Model.MemberModel();
			object ojb; 
			ojb = dataReader["userId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userId=(int)ojb;
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

			ojb = dataReader["UserType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserType=(MemberType)ojb;
			}
			ojb = dataReader["status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(MemberStatus)ojb;
			}
			return model;
		}

		#endregion  成员方法

        internal void SetStatus(int userId, MemberStatus status)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_SetStatus");
            db.AddInParameter(dbCommand, "userId", DbType.Int32, userId);
            db.AddInParameter(dbCommand, "status", DbType.Int32, (int)status);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}

