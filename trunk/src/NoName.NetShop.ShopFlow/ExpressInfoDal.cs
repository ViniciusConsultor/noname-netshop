using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace NoName.NetShop.ShopFlow
{
    /// <summary>
    /// 数据访问类unExpressInfo。
    /// </summary>
    public class ExpressInfoDal
    {
        public ExpressInfoDal()
        { }
        #region  成员方法
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(NoName.NetShop.ShopFlow.ExpressInfoModel model)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_unExpressInfo_Update");
            db.AddInParameter(dbCommand, "ShipRegion", DbType.Byte, model.ShipRegion);
            db.AddInParameter(dbCommand, "UserType", DbType.Byte, model.UserType);
            db.AddInParameter(dbCommand, "UserLevel", DbType.Byte, model.UserLevel);
            db.AddInParameter(dbCommand, "MarkMoney", DbType.Decimal, model.MarkMoney);
            db.AddInParameter(dbCommand, "LShipFee", DbType.Decimal, model.LShipFee);
            db.AddInParameter(dbCommand, "GShipFee", DbType.Decimal, model.GShipFee);
            db.AddInParameter(dbCommand, "RuleId", DbType.Int32, model.RuleId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.ShopFlow.ExpressInfoModel GetModel(int RuleId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ShipRegion,UserType,UserLevel,MarkMoney,LShipFee,GShipFee,RuleId ");
            strSql.Append(" FROM unExpressInfo where ruleId=" + RuleId);
            NoName.NetShop.ShopFlow.ExpressInfoModel model = null;
            using (IDataReader dataReader = NoName.NetShop.Common.CommDataAccess.DbReader.ExecuteReader(CommandType.Text,strSql.ToString()))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<NoName.NetShop.ShopFlow.ExpressInfoModel> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ShipRegion,UserType,UserLevel,MarkMoney,LShipFee,GShipFee,RuleId ");
            strSql.Append(" FROM unExpressInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<NoName.NetShop.ShopFlow.ExpressInfoModel> list = new List<NoName.NetShop.ShopFlow.ExpressInfoModel>();
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
        public NoName.NetShop.ShopFlow.ExpressInfoModel ReaderBind(IDataReader dataReader)
        {
            NoName.NetShop.ShopFlow.ExpressInfoModel model = new NoName.NetShop.ShopFlow.ExpressInfoModel();
            object ojb;
            ojb = dataReader["ShipRegion"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShipRegion = Convert.ToInt32(ojb);
            }
            ojb = dataReader["UserType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserType = Convert.ToInt32(ojb);
            }
            ojb = dataReader["UserLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserLevel = Convert.ToInt32(ojb);
            }
            ojb = dataReader["MarkMoney"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MarkMoney = (decimal)ojb;
            }
            ojb = dataReader["LShipFee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LShipFee = (decimal)ojb;
            }
            ojb = dataReader["GShipFee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.GShipFee = (decimal)ojb;
            }
            ojb = dataReader["RuleId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RuleId = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  成员方法
    }
}

