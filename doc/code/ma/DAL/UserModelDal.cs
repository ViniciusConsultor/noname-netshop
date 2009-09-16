using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Maticsoft.DBUtility;//请先添加引用
namespace NoName.NetShop.DAL
{
	/// <summary>
	/// 数据访问类UserModelDal。
	/// </summary>
	public class UserModelDal
	{
		public UserModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(UserId)+1 from maUser";
			Database db = DatabaseFactory.CreateDatabase();
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
		public bool Exists(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_maUser_Exists");
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
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.UserModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_maUser_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "LastLoginTime", DbType.DateTime, model.LastLoginTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.UserModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_maUser_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
			db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
			db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
			db.AddInParameter(dbCommand, "LastLoginTime", DbType.DateTime, model.LastLoginTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_maUser_Delete");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.UserModel GetModel(int UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_maUser_GetModel");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32,UserId);

			NoName.NetShop.Model.UserModel model=null;
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
			strSql.Append("select UserId,UserName,UserEmail,Password,LastLoginTime ");
			strSql.Append(" FROM maUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "maUser");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Model.UserModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,UserName,UserEmail,Password,LastLoginTime ");
			strSql.Append(" FROM maUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.UserModel> list = new List<NoName.NetShop.Model.UserModel>();
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
		/// 对象实体绑定数据
		/// </summary>
		public NoName.NetShop.Model.UserModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.UserModel model=new NoName.NetShop.Model.UserModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.UserEmail=dataReader["UserEmail"].ToString();
			model.Password=dataReader["Password"].ToString();
			ojb = dataReader["LastLoginTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LastLoginTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

