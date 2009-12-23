﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Member
{
    public class FamlyMemberInfo:MemberInfo
    {
        #region Model
        public string  IdCard { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string RegionPath { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }

        #endregion Model

        public override MemberInfo GetFullUserInfo(string userId)
        {
            string sql = "up_umMember_GetFamly";
            Database db = NoName.NetShop.Common.DBFacotry.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "UserId", DbType.String, userId);

            MemberInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;

        }
        public override void SaveExtInfo()
        {
            string sql = "up_umMember_SaveFamly";
            Database db = NoName.NetShop.Common.DBFacotry.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "@userId", DbType.String, UserId);
            db.AddInParameter(dbCommand, "@idcard", DbType.AnsiString, IdCard);
            db.AddInParameter(dbCommand, "@Address", DbType.AnsiString, Address);
            db.AddInParameter(dbCommand, "@country", DbType.AnsiString, Country);
            db.AddInParameter(dbCommand, "@province", DbType.String, Province);
            db.AddInParameter(dbCommand, "@city", DbType.String,City);
            db.AddInParameter(dbCommand, "@county", DbType.String, County);
            db.AddInParameter(dbCommand, "@Mobile", DbType.String, Mobile);
            db.AddInParameter(dbCommand, "@TelePhone", DbType.String, Telephone);
            db.AddInParameter(dbCommand, "@regionPath", DbType.String, RegionPath);
            db.ExecuteNonQuery(dbCommand);
        }

        private FamlyMemberInfo ReaderBind(IDataReader dataReader)
        {
            FamlyMemberInfo model = new FamlyMemberInfo();
            object ojb;
            model.UserId = dataReader["UserId"].ToString();
            model.UserEmail = dataReader["UserEmail"].ToString();
            model.Password = dataReader["Password"].ToString();
            model.UserName = dataReader["UserName"].ToString();
            ojb = dataReader["AllScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AllScore = (int)ojb;
            }
            ojb = dataReader["CurScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CurScore = (int)ojb;
            }
            ojb = dataReader["LastLogin"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastLogin = (DateTime)ojb;
            }
            model.LoginIp = dataReader["LoginIP"].ToString();
            ojb = dataReader["RegisterTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RegisterTime = (DateTime)ojb;
            }
            ojb = dataReader["ModifyTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ModifyTime = (DateTime)ojb;
            }
            ojb = dataReader["UserType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserType = (MemberType)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = (MemberStatus)(Convert.ToInt32(ojb));
            }


            model.IdCard = dataReader["idcard"].ToString();
            model.Address = dataReader["Address"].ToString();
            model.Country = dataReader["country"].ToString();
            model.Province = dataReader["province"].ToString();
            model.City = dataReader["city"].ToString();
            model.County = dataReader["county"].ToString();
            model.Mobile = dataReader["Mobile"].ToString();
            model.Telephone = dataReader["TelePhone"].ToString();
            model.RegionPath = dataReader["regionPath"].ToString();
            return model;
        }

    }
}