using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    public class CommOrderDal
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommOrderModel GetModel(string OrderId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,DerateFee,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCity,RecieverProvince,AddressDetial,ChangeTime,PayTime,OrderId,CreateTime,OrderType,ServerIp,ClientIp,InvoiceTitle,IsNeedInvoice,UserNotes,RecieverCountry,RecieverCounty,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,payorderId,IsTotalFeeAdjust,suitId from spOrder ");
            strSql.Append(" where OrderId=@OrderId ");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, OrderId);

            CommOrderModel model = null;
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
        public CommOrderModel GetModel(string OrderId,string userId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,DerateFee,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCity,RecieverProvince,AddressDetial,ChangeTime,PayTime,OrderId,CreateTime,OrderType,ServerIp,ClientIp,InvoiceTitle,IsNeedInvoice,UserNotes,RecieverCountry,RecieverCounty,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,payorderId,IsTotalFeeAdjust,suitId from spOrder ");
            strSql.Append(" where OrderId=@OrderId and userId=@userId");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, OrderId);
            db.AddInParameter(dbCommand, "userId", DbType.AnsiString, userId);
            CommOrderModel model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        public bool ChangeOrderStatus(string orderId, OrderStatus ostatus)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update spOrder set changetime=getdate(),orderstatus=@ostatus from spOrder ");
            strSql.Append(" where OrderId=@OrderId ");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, orderId);
            db.AddInParameter(dbCommand, "ostatus", DbType.Int16,(int)ostatus);
            return db.ExecuteNonQuery(dbCommand) >0;
        }

        public bool ChangePayStatus(string orderId,PayStatus pstatus)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            StringBuilder strSql = new StringBuilder();

            if (pstatus == PayStatus.支付成功)
            {
                strSql.Append("update spOrder set changetime=getdate(),paytime=getdate(),paystatus=@paystatus from spOrder ");
            }
            else
            {
                strSql.Append("update spOrder set changetime=getdate(),paystatus=@paystatus from spOrder");
            }
            strSql.Append(" where OrderId=@OrderId and paystatus!=@paystatus");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, orderId);
            db.AddInParameter(dbCommand, "paystatus", DbType.Int16, (int)pstatus);
            return db.ExecuteNonQuery(dbCommand) > 0;
        }

        internal bool SetPayOrderId(string orderId, string payOrderId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update spOrder set payorderId=@payOrderId,changeTime=getdate() from spOrder ");
            strSql.Append(" where OrderId=@OrderId");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, orderId);
            db.AddInParameter(dbCommand, "payOrderId", DbType.String, payOrderId);
            return db.ExecuteNonQuery(dbCommand) > 0;
        }

        internal bool ModifyTotalFee(string orderId, decimal totalFee)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update spOrder set paysum=@paysum,IsTotalFeeAdjust=1,changeTime=getdate() from spOrder ");
            strSql.Append(" where OrderId=@OrderId");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, orderId);
            db.AddInParameter(dbCommand, "paysum", DbType.Single, totalFee);
            return db.ExecuteNonQuery(dbCommand) > 0;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        private CommOrderModel ReaderBind(IDataReader dataReader)
        {
            CommOrderModel model = new CommOrderModel();
            object ojb;
            model.UserId = dataReader["UserId"].ToString();
            model.OrderId = dataReader["OrderId"].ToString();
            ojb = dataReader["OrderStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderStatus = (OrderStatus)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["PayMethod"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayMethod = (PayMethType)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["ShipMethod"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShipMethod = (ShipMethodType)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["PayStatus"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayStatus = (PayStatus)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["Paysum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Paysum = (decimal)ojb;
            }
            ojb = dataReader["ShipFee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShipFee = (decimal)ojb;
            }
            ojb = dataReader["ProductFee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductFee = (decimal)ojb;
            }
            ojb = dataReader["DerateFee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.DerateFee = (decimal)ojb;
            }
            model.RecieverName = dataReader["RecieverName"].ToString();
            model.RecieverEmail = dataReader["RecieverEmail"].ToString();
            model.RecieverPhone = dataReader["RecieverPhone"].ToString();
            model.Postalcode = dataReader["Postalcode"].ToString();
            model.RecieverCity = dataReader["RecieverCity"].ToString();
            model.RecieverProvince = dataReader["RecieverProvince"].ToString();
            model.AddressDetial = dataReader["AddressDetial"].ToString();
            ojb = dataReader["ChangeTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ChangeTime = (DateTime)ojb;
            }
            ojb = dataReader["PayTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayTime = (DateTime)ojb;
            }
            ojb = dataReader["CreateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateTime = (DateTime)ojb;
            }
            ojb = dataReader["OrderType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderType = (OrderType)(Convert.ToInt32(ojb));
            }
            model.ServerIp = dataReader["ServerIp"].ToString();
            model.ClientIp = dataReader["ClientIp"].ToString();
            model.InvoiceTitle = dataReader["InvoiceTitle"].ToString();
            ojb = dataReader["IsNeedInvoice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsNeedInvoice = (bool)ojb;
            }
            model.UserNotes = dataReader["UserNotes"].ToString();
            model.RecieverCountry = dataReader["RecieverCountry"].ToString();
            model.RecieverCounty = dataReader["RecieverCounty"].ToString();
            model.PayorderId = dataReader["payorderId"].ToString();
            ojb = dataReader["IsTotalFeeAdjust"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsTotalFeeAdjust = (bool)ojb;
            }
            ojb = dataReader["suitId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SuitId = Convert.ToInt32(ojb);
            }
            return model;
        }


    }
}
