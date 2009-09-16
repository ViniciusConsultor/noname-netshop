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
	/// 数据访问类AddressModelDal。
	/// </summary>
	public class AddressModelDal
	{
		public AddressModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AddressId)+1 from umAddress";
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
		public bool Exists(int AddressId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Exists");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);
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
		public void Add(NoName.NetShop.Model.AddressModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
			db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
			db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
			db.AddInParameter(dbCommand, "AddressDetail", DbType.AnsiString, model.AddressDetail);
			db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "Telephone", DbType.AnsiString, model.Telephone);
			db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
			db.AddInParameter(dbCommand, "IsDefault", DbType.Boolean, model.IsDefault);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AddressModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
			db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
			db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
			db.AddInParameter(dbCommand, "AddressDetail", DbType.AnsiString, model.AddressDetail);
			db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "Telephone", DbType.AnsiString, model.Telephone);
			db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
			db.AddInParameter(dbCommand, "IsDefault", DbType.Boolean, model.IsDefault);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AddressId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Delete");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.AddressModel GetModel(int AddressId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_GetModel");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			NoName.NetShop.Model.AddressModel model=null;
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
			strSql.Append("select UserId,AddressId,Province,City,AddressDetail,RecieverName,Mobile,Telephone,Postalcode,IsDefault,InsertTime,ModifyTime ");
			strSql.Append(" FROM umAddress ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "umAddress");
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
		public List<NoName.NetShop.Model.AddressModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,AddressId,Province,City,AddressDetail,RecieverName,Mobile,Telephone,Postalcode,IsDefault,InsertTime,ModifyTime ");
			strSql.Append(" FROM umAddress ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.AddressModel> list = new List<NoName.NetShop.Model.AddressModel>();
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
		public NoName.NetShop.Model.AddressModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.AddressModel model=new NoName.NetShop.Model.AddressModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["AddressId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddressId=(int)ojb;
			}
			model.Province=dataReader["Province"].ToString();
			model.City=dataReader["City"].ToString();
			model.AddressDetail=dataReader["AddressDetail"].ToString();
			model.RecieverName=dataReader["RecieverName"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.Telephone=dataReader["Telephone"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			ojb = dataReader["IsDefault"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDefault=(bool)ojb;
			}
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["ModifyTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ModifyTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

