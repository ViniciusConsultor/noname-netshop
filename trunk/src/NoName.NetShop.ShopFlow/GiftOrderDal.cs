using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    class GiftOrderDal
    {
        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GiftOrderModel GetModel(string OrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,OrderId,OrderStatus,ShipMethod,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCountry,RecieverCity,RecieverProvince,RecieverCounty,AddressDetial,ChangeTime,CreateTime,OrderType,ServerIp,ClientIp,UserNotes,TotalScore from spGiftOrder ");
            strSql.Append(" where OrderId=@OrderId ");
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, OrderId);
            GiftOrderModel model = null;
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
        public GiftOrderModel GetModel(string OrderId,string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,OrderId,OrderStatus,ShipMethod,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCountry,RecieverCity,RecieverProvince,RecieverCounty,AddressDetial,ChangeTime,CreateTime,OrderType,ServerIp,ClientIp,UserNotes,TotalScore from spGiftOrder ");
            strSql.Append(" where OrderId=@OrderId and userId=@userId ");
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, OrderId);
            db.AddInParameter(dbCommand, "userId", DbType.AnsiString, userId);
            GiftOrderModel model = null;
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
        public GiftOrderModel ReaderBind(IDataReader dataReader)
        {
            GiftOrderModel model = new GiftOrderModel();
            object ojb;
            model.UserId = dataReader["UserId"].ToString();
            model.OrderId = dataReader["OrderId"].ToString();
            ojb = dataReader["OrderStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderStatus = (OrderStatus)Convert.ToInt16(ojb);
            }
            ojb = dataReader["ShipMethod"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShipMethod = (ShipMethodType)Convert.ToInt16(ojb);
            }
            model.RecieverName = dataReader["RecieverName"].ToString();
            model.RecieverEmail = dataReader["RecieverEmail"].ToString();
            model.RecieverPhone = dataReader["RecieverPhone"].ToString();
            model.Postalcode = dataReader["Postalcode"].ToString();
            model.RecieverCountry = dataReader["RecieverCountry"].ToString();
            model.RecieverCity = dataReader["RecieverCity"].ToString();
            model.RecieverProvince = dataReader["RecieverProvince"].ToString();
            model.RecieverCounty = dataReader["RecieverCounty"].ToString();
            model.AddressDetial = dataReader["AddressDetial"].ToString();
            ojb = dataReader["ChangeTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ChangeTime = (DateTime)ojb;
            }
            ojb = dataReader["CreateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateTime = (DateTime)ojb;
            }
            ojb = dataReader["OrderType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderType =(OrderType)Convert.ToInt16(ojb);
            }
            model.ServerIp = dataReader["ServerIp"].ToString();
            model.ClientIp = dataReader["ClientIp"].ToString();
            model.UserNotes = dataReader["UserNotes"].ToString();
            ojb = dataReader["TotalScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TotalScore = (int)ojb;
            }
            return model;
        }

        #endregion  成员方法

        internal bool ChangeOrderStatus(string orderId, OrderStatus ostatus)
        {
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update spGiftOrder set changetime=getdate(),status=@ostatus from spGiftOrder ");
            strSql.Append(" where OrderId=@OrderId ");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, orderId);
            db.AddInParameter(dbCommand, "ostatus", DbType.Int16, (int)ostatus);
            return db.ExecuteNonQuery(dbCommand) > 0;
        }
    }
}
