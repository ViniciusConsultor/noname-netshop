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
	/// ���ݷ�����Address��
	/// </summary>
	public class Address
	{
		public Address()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int AddressId)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		///  ����һ������
		/// </summary>
		public void Add(NoName.NetShop.UserManager.Model.Address model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.UserManager.Model.Address model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AddressId)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_Delete");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.UserManager.Model.Address GetModel(int AddressId)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umAddress_GetModel");
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32,AddressId);

			NoName.NetShop.UserManager.Model.Address model=null;
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
			strSql.Append("select UserId,AddressId,Province,City,AddressDetail,RecieverName,Mobile,Telephone,Postalcode,IsDefault,InsertTime,ModifyTime ");
			strSql.Append(" FROM umAddress ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<NoName.NetShop.UserManager.Model.Address> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,AddressId,Province,City,AddressDetail,RecieverName,Mobile,Telephone,Postalcode,IsDefault,InsertTime,ModifyTime ");
			strSql.Append(" FROM umAddress ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.UserManager.Model.Address> list = new List<NoName.NetShop.UserManager.Model.Address>();
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
		/// ����ʵ�������
		/// </summary>
		public NoName.NetShop.UserManager.Model.Address ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.UserManager.Model.Address model=new NoName.NetShop.UserManager.Model.Address();
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

		#endregion  ��Ա����
	}
}

