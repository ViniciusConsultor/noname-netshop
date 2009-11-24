using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;


namespace NoName.NetShop.Member
{
    public class PersonMemberInfo:MemberInfo
    {
        #region Model
        public string IdCard { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public int UserLevel{get;set;}

        #endregion Model

        public override MemberInfo GetFullUserInfo(string userId)
        {
            string sql = "up_umMember_GetPerson";
            Database db = NoName.NetShop.Common.DBFacroty.DbReader;
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
            Database db = NoName.NetShop.Common.DBFacroty.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "@userId", DbType.String, UserId);
            db.AddInParameter(dbCommand, "@idcard", DbType.AnsiString, IdCard);
            db.AddInParameter(dbCommand, "@Mobile", DbType.String, Mobile);
            db.AddInParameter(dbCommand, "@TelePhone", DbType.String, Telephone);
            db.AddInParameter(dbCommand, "@UserLevel", DbType.Int32, UserLevel);
            db.ExecuteNonQuery(dbCommand);
        }

        private PersonMemberInfo ReaderBind(IDataReader dataReader)
        {
            PersonMemberInfo model = new PersonMemberInfo();
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
            model.Mobile = dataReader["Mobile"].ToString();
            model.Telephone = dataReader["TelePhone"].ToString();
            ojb = dataReader["UserLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserLevel = (int)ojb;
            }
            return model;

        }


    }
}
