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
	/// ���ݷ�����ActionProductModelDal��
	/// </summary>
	public class ActionProductModelDal
	{
		public ActionProductModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AuctionId)+1 from auActionProduct";
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
		public bool Exists(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Exists");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);
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
		public void Add(NoName.NetShop.Model.ActionProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_ADD");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "SmallIamge", DbType.AnsiString, model.SmallIamge);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			db.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			db.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			db.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.ActionProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Update");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "SmallIamge", DbType.AnsiString, model.SmallIamge);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			db.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			db.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			db.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Delete");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.ActionProductModel GetModel(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_GetModel");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			NoName.NetShop.Model.ActionProductModel model=null;
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
			strSql.Append("select AuctionId,ProductName,SmallIamge,MediumImage,OutLinkUrl,StartPrice,AddPrices,CurPrice,Brief,StartTime,EndTime,Status ");
			strSql.Append(" FROM auActionProduct ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "auActionProduct");
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
		public List<NoName.NetShop.Model.ActionProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AuctionId,ProductName,SmallIamge,MediumImage,OutLinkUrl,StartPrice,AddPrices,CurPrice,Brief,StartTime,EndTime,Status ");
			strSql.Append(" FROM auActionProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.ActionProductModel> list = new List<NoName.NetShop.Model.ActionProductModel>();
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
		public NoName.NetShop.Model.ActionProductModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.ActionProductModel model=new NoName.NetShop.Model.ActionProductModel();
			object ojb; 
			ojb = dataReader["AuctionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuctionId=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			model.SmallIamge=dataReader["SmallIamge"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
			model.OutLinkUrl=dataReader["OutLinkUrl"].ToString();
			ojb = dataReader["StartPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartPrice=(decimal)ojb;
			}
			ojb = dataReader["AddPrices"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddPrices=(decimal)ojb;
			}
			ojb = dataReader["CurPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CurPrice=(decimal)ojb;
			}
			model.Brief=dataReader["Brief"].ToString();
			ojb = dataReader["StartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartTime=(DateTime)ojb;
			}
			ojb = dataReader["EndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

