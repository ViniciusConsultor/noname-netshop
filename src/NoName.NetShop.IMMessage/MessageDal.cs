using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Common;
using System.Text.RegularExpressions;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// 数据访问类MessageModelDal。
	/// </summary>
	public class MessageDal
	{
		public MessageDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(MessageModel model)
		{
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_imMessage_ADD");
            if (model.MsgId == 0)
                model.MsgId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Message);

			db.AddInParameter(dbCommand, "UserId", DbType.String, model.UserId);
			db.AddInParameter(dbCommand, "MsgId", DbType.Int32, model.MsgId);
			db.AddInParameter(dbCommand, "MsgType", DbType.Byte, model.MsgType);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "SenderId", DbType.AnsiString, model.SenderId);
            db.AddInParameter(dbCommand, "UserType", DbType.Int32, model.UserType);
			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// 设置消息为已读状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="msgId"></param>
        public void SetIsReaded(int msgId)
        {
            string sql = "update imMessage set status=1,readtime=getdate() from immessage where msgId=@msgId";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "msgId", DbType.Int32, msgId);
            db.ExecuteNonQuery(dbCommand);
        }


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string userId,int msgId,int userType)
		{
            string sql = "delete imMessage from immessage where userid=@userId and msgId=@msgId and usertype=@userType";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "msgId", DbType.Int32, msgId);
            db.AddInParameter(dbCommand, "usertype", DbType.Int32, userType);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string userId,string msgIds,int usertype )
        {
            if (Regex.IsMatch(msgIds, @"^(\d+,)*\d+$"))
            {
                string sql = "delete imMessage from immessage where userid=@userId and usertype=@userType and msgId in (" + msgIds + ")";
                Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                db.AddInParameter(dbCommand, "userId", DbType.String, userId);
                db.AddInParameter(dbCommand, "usertype", DbType.Int32, usertype);
                db.ExecuteNonQuery(dbCommand);
            }
            else
            {
                throw new ShopException("输入有误", true);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MessageModel GetModel(int msgId)
        {
            string sql = "SELECT UserId,MsgId,MsgType,usertype,Subject,Content,SenderId,InsertTime,ReadTime,Status from imMessage where msgId=@msgId";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "msgId", DbType.Int32, msgId);
            MessageModel model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MessageModel GetModel(string userId,int msgId,int usertype)
		{
            string sql = "SELECT UserId,MsgId,MsgType,usertype,Subject,Content,SenderId,InsertTime,ReadTime,Status from imMessage where userId=@userId and msgId=@msgId and usertype=@userType";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "msgId", DbType.Int32, msgId);
            db.AddInParameter(dbCommand, "usertype", DbType.Int32, usertype);
            MessageModel model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public MessageModel ReaderBind(IDataReader dataReader)
		{
			MessageModel model=new MessageModel();
			object ojb;
            model.UserId = dataReader["UserId"].ToString();
			ojb = dataReader["MsgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MsgId=(int)ojb;
			}
			ojb = dataReader["MsgType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MsgType=Convert.ToInt32(ojb);
			}
            ojb = dataReader["usertype"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserType = Convert.ToInt32(ojb);
            }
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
            model.SenderId = dataReader["SenderId"].ToString();
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
				model.Status=(bool)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

