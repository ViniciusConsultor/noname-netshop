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
	/// 数据访问类MessageModelDal。
	/// </summary>
	public class MessageModelDal
	{
		public MessageModelDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.MessageModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_imMessage_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "MsgId", DbType.Int32, model.MsgId);
			db.AddInParameter(dbCommand, "MsgType", DbType.Byte, model.MsgType);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "SenderId", DbType.Int32, model.SenderId);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ReadTime", DbType.DateTime, model.ReadTime);
			db.AddInParameter(dbCommand, "Status", DbType.Int32, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.MessageModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_imMessage_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "MsgId", DbType.Int32, model.MsgId);
			db.AddInParameter(dbCommand, "MsgType", DbType.Byte, model.MsgType);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "SenderId", DbType.Int32, model.SenderId);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ReadTime", DbType.DateTime, model.ReadTime);
			db.AddInParameter(dbCommand, "Status", DbType.Int32, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_imMessage_Delete");

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.MessageModel GetModel()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_imMessage_GetModel");

			NoName.NetShop.Model.MessageModel model=null;
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
			strSql.Append("select UserId,MsgId,MsgType,Subject,Content,SenderId,InsertTime,ReadTime,Status ");
			strSql.Append(" FROM imMessage ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "imMessage");
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
		public List<NoName.NetShop.Model.MessageModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,MsgId,MsgType,Subject,Content,SenderId,InsertTime,ReadTime,Status ");
			strSql.Append(" FROM imMessage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.MessageModel> list = new List<NoName.NetShop.Model.MessageModel>();
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
		public NoName.NetShop.Model.MessageModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.MessageModel model=new NoName.NetShop.Model.MessageModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["MsgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MsgId=(int)ojb;
			}
			ojb = dataReader["MsgType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MsgType=(int)ojb;
			}
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["SenderId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenderId=(int)ojb;
			}
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["ReadTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReadTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

