using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace NoName.NetShop.Product.DAL
{
    /// <summary>
    /// 数据访问类pdGift。
    /// </summary>
    public class GiftDal
    {
        public GiftDal()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Save(NoName.NetShop.Product.Model.GiftModel model)
        {
            Database db = Common.CommDataAccess.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_pdGift_Save");
            if (model.ProductId == 0)
                model.ProductId = Common.CommDataHelper.GetNewSerialNum(Common.AppType.Product);

            db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
            db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
            db.AddInParameter(dbCommand, "Stock", DbType.Int32, model.Stock);
            db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
            db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
            db.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
            db.AddInParameter(dbCommand, "Keywords", DbType.AnsiString, model.Keywords);
            db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
            db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
            db.AddInParameter(dbCommand, "Decription", DbType.AnsiString, model.Decription);
            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int productId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "delete from pdgift where productid=" + productId;
            db.ExecuteNonQuery(CommandType.Text,sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.Product.Model.GiftModel GetModel(int ProductId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_pdGift_GetModel");
            db.AddInParameter(dbCommand, "ProductId", DbType.Int32, ProductId);

            NoName.NetShop.Product.Model.GiftModel model = null;
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
        public NoName.NetShop.Product.Model.GiftModel ReaderBind(IDataReader dataReader)
        {
            NoName.NetShop.Product.Model.GiftModel model = new NoName.NetShop.Product.Model.GiftModel();
            object ojb;
            ojb = dataReader["ProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductId = (int)ojb;
            }
            model.ProductName = dataReader["ProductName"].ToString();
            ojb = dataReader["Stock"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Stock = (int)ojb;
            }
            model.SmallImage = dataReader["SmallImage"].ToString();
            model.MediumImage = dataReader["MediumImage"].ToString();
            model.LargeImage = dataReader["LargeImage"].ToString();
            model.Keywords = dataReader["Keywords"].ToString();
            model.Brief = dataReader["Brief"].ToString();
            ojb = dataReader["PageView"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PageView = (int)ojb;
            }
            ojb = dataReader["InsertTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InsertTime = (DateTime)ojb;
            }
            ojb = dataReader["ChangeTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ChangeTime = (DateTime)ojb;
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["SortValue"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SortValue = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = (int)ojb;
            }
            model.Decription = dataReader["Decription"].ToString();
            return model;
        }

        #endregion  成员方法
    }
}

