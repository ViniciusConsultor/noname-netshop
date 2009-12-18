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
	/// 数据访问类Address。
	/// </summary>
	public class AddressDal
	{
		public AddressDal()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AddressId)
		{
            string sql = "SELECT count(1) FROM umAddress WHERE AddressId=" + AddressId;
            int retval = Convert.ToInt32(NoName.NetShop.Common.DBFacotry.DbReader.ExecuteScalar(CommandType.Text, sql));
            return retval > 0;
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.AddressModel model)
		{
			Database db = NoName.NetShop.Common.DBFacotry.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.String, model.UserId);
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
			db.AddInParameter(dbCommand, "regionPath", DbType.AnsiString, model.RegionPath);
			db.AddInParameter(dbCommand, "Country", DbType.AnsiString, model.Country);
			db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
			db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.County);
			db.AddInParameter(dbCommand, "AddressDetail", DbType.AnsiString, model.AddressDetail);
			db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "Telephone", DbType.AnsiString, model.Telephone);
			db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.AddressModel model)
		{
			Database db = NoName.NetShop.Common.DBFacotry.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Update");
            db.AddInParameter(dbCommand, "UserId", DbType.String, model.UserId);
            db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
            db.AddInParameter(dbCommand, "regionPath", DbType.AnsiString, model.RegionPath);
            db.AddInParameter(dbCommand, "Country", DbType.AnsiString, model.Country);
            db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
            db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
            db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.County);
            db.AddInParameter(dbCommand, "AddressDetail", DbType.AnsiString, model.AddressDetail);
            db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
            db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
            db.AddInParameter(dbCommand, "Telephone", DbType.AnsiString, model.Telephone);
            db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
            db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
            db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AddressId)
		{
			Database db = NoName.NetShop.Common.DBFacotry.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Delete");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.AddressModel GetModel(int AddressId)
		{
			Database db = NoName.NetShop.Common.DBFacotry.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_GetModel");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			NoName.NetShop.Member.Model.AddressModel model=null;
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
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Member.Model.AddressModel> GetListArray(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,AddressId,regionPath,Country,Province,City,county,AddressDetail,RecieverName,Mobile,Telephone,Postalcode,IsDefault,InsertTime,ModifyTime,Email ");
            strSql.Append(" FROM umAddress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<NoName.NetShop.Member.Model.AddressModel> list = new List<NoName.NetShop.Member.Model.AddressModel>();
            Database db = NoName.NetShop.Common.DBFacotry.DbReader;
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
		public NoName.NetShop.Member.Model.AddressModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.AddressModel model=new NoName.NetShop.Member.Model.AddressModel();
            object ojb;
            model.UserId = dataReader["userId"].ToString();
            ojb = dataReader["AddressId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddressId = (int)ojb;
            }
            model.RegionPath = dataReader["regionPath"].ToString();
            model.Country = dataReader["Country"].ToString();
            model.Province = dataReader["Province"].ToString();
            model.City = dataReader["City"].ToString();
            model.County = dataReader["county"].ToString();
            model.AddressDetail = dataReader["AddressDetail"].ToString();
            model.RecieverName = dataReader["RecieverName"].ToString();
            model.Mobile = dataReader["Mobile"].ToString();
            model.Telephone = dataReader["Telephone"].ToString();
            model.Postalcode = dataReader["Postalcode"].ToString();
            ojb = dataReader["IsDefault"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsDefault = (bool)ojb;
            }
            ojb = dataReader["InsertTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InsertTime = (DateTime)ojb;
            }
            ojb = dataReader["ModifyTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ModifyTime = (DateTime)ojb;
            }
            model.Email = dataReader["Email"].ToString();
            return model;
        }

		#endregion  成员方法
	}
}

