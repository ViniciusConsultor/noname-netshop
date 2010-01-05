using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Text.RegularExpressions;
using NoName.NetShop.Common;

namespace NoName.NetShop.Member
{
    /// <summary>
    /// 数据访问类FavoriteModel。
    /// </summary>
    public class FavoriteDal
    {
        public FavoriteDal()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(NoName.NetShop.Member.FavoriteModel model)
        {
            Database db = DBFactory.DbWriter;
            if (!this.Exists(model.UserId, model.ContentId, model.ContentType))
            {
                model.FavoriteId = CommDataHelper.GetNewSerialNum(AppType.Other);
                DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_ADD");
                db.AddInParameter(dbCommand, "UserId", DbType.AnsiString, model.UserId);
                db.AddInParameter(dbCommand, "FavoriteId", DbType.Int32, model.FavoriteId);
                db.AddInParameter(dbCommand, "FavoriteUrl", DbType.AnsiString, model.FavoriteUrl);
                db.AddInParameter(dbCommand, "FavoriteName", DbType.AnsiString, model.FavoriteName);
                db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
                db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
                db.ExecuteNonQuery(dbCommand);
            }
        }

        public bool Exists(string userId, int contentId, ContentType contentType)
        {
            Database db = DBFactory.DbReader;
            string sql = "select count(*) from umFavorite where userid=@userId and contentId=@contentId and contentType=@ContentType";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "UserId", DbType.AnsiString, userId);
            db.AddInParameter(dbCommand, "ContentId", DbType.Int32, contentId);
            db.AddInParameter(dbCommand, "ContentType", DbType.Byte, contentType);
            object obj = db.ExecuteScalar(dbCommand);
            return (Convert.ToInt32(obj) > 0);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FavoriteId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_Delete");
            db.AddInParameter(dbCommand, "FavoriteId", DbType.Int32, FavoriteId);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.Member.FavoriteModel GetModel(int FavoriteId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_GetModel");
            db.AddInParameter(dbCommand, "FavoriteId", DbType.Int32, FavoriteId);

            NoName.NetShop.Member.FavoriteModel model = null;
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
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<NoName.NetShop.Member.FavoriteModel> GetListArray(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,FavoriteId,FavoriteUrl,FavoriteName,InsertTime,ContentId,ContentType ");
            strSql.Append(" FROM umFavorite where userid=@userId");

            List<NoName.NetShop.Member.FavoriteModel> list = new List<NoName.NetShop.Member.FavoriteModel>();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand comm = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(comm, "userId", DbType.String, userId);
            using (IDataReader dataReader = db.ExecuteReader(comm))
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
        public NoName.NetShop.Member.FavoriteModel ReaderBind(IDataReader dataReader)
        {
            NoName.NetShop.Member.FavoriteModel model = new NoName.NetShop.Member.FavoriteModel();
            object ojb;
            model.UserId = dataReader["UserId"].ToString();
            ojb = dataReader["FavoriteId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.FavoriteId = (int)ojb;
            }
            model.FavoriteUrl = dataReader["FavoriteUrl"].ToString();
            model.FavoriteName = dataReader["FavoriteName"].ToString();
            ojb = dataReader["InsertTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InsertTime = (DateTime)ojb;
            }
            ojb = dataReader["ContentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentId = (int)ojb;
            }
            ojb = dataReader["ContentType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentType = (ContentType)Convert.ToInt32(ojb);
            }
            return model;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string userId, int favId)
        {
            string sql = "delete umFavorite from umFavorite where userid=@userId and favoriteId=@favId";
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "favId", DbType.Int32, favId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string userId, string favIds)
        {
            if (Regex.IsMatch(favIds, @"^(\d+,)*\d+$"))
            {
                string sql = "delete umFavorite from umFavorite where userid=@userId and msgId in (" + favIds + ")";
                Database db = NoName.NetShop.Common.DBFactory.DbReader;
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                db.AddInParameter(dbCommand, "userId", DbType.String, userId);
                db.ExecuteNonQuery(dbCommand);
            }
            else
            {
                throw new ShopException("输入有误", true);
            }
        }

        #endregion  成员方法


    }
}

