﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using NoName.NetShop.Common;
using System.Web.Security;
using System.Data.SqlTypes;

namespace NoName.NetShop.Member
{
    public class MemberInfo
    {
        public string UserId{get;set;}
        public string UserEmail{get;set;}
        public string Password{get;set;}
        public string UserName{get;set;}
        public int AllScore{get;set;}
        public int CurScore{get;set;}
        public DateTime LastLogin{get;set;}
        public string LoginIp{get;set;}
        public DateTime RegisterTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public MemberType UserType{get;set;}
        public MemberStatus Status{get;set;}
        public UserLevel UserLevel { get; set; }
        public Guid SecKey { get; set; }
        public string SecPassword { get; set; }


        /// <summary>
        /// 记录用户的积分消费记录
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="score"></param>
        /// <param name="appId"></param>
        /// <param name="remark"></param>
        public void LogScore(string appType, int score, string appId, string remark)
        {
            string sql = "um_member_logScore";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "UserIds", DbType.String,UserId);
            db.AddInParameter(dbCommand, "@Score",DbType.Int32,score);
            db.AddInParameter(dbCommand, "@appType",DbType.String,appId);
            db.AddInParameter(dbCommand, "@appId",DbType.String,appId);
            db.AddInParameter(dbCommand, "@remark",DbType.String,remark);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 记录用户的积分消费记录，可以是多个用户的
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="score"></param>
        /// <param name="appId"></param>
        /// <param name="remark"></param>
        public static void LogScore(string userIds, NoName.NetShop.Common.ScoreType stype, int score, string appId, string remark)
        {
            string sql = "um_member_logScore";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "@UserIds", DbType.String, userIds);
            db.AddInParameter(dbCommand, "@Score", DbType.Int32, score);
            db.AddInParameter(dbCommand, "@scoreType", DbType.Int16, (int)stype);
            db.AddInParameter(dbCommand, "@appId", DbType.String, appId);
            db.AddInParameter(dbCommand, "@remark", DbType.String, remark);
            db.ExecuteNonQuery(dbCommand);
        }


        public static MemberInfo GetBaseInfo(string userId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_GetModel");
            db.AddInParameter(dbCommand, "UserId", DbType.String,userId);

            MemberInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    MemberInfo mbll = new MemberInfo();
                    model = mbll.ReaderBind(dataReader);
                }
            }
            return model;
        }

        public static MemberInfo GetFullInfo(string userId, MemberType userType)
        {
            MemberInfo model = null;
            MemberInfo mbll = null;
            switch (userType)
            {
                case MemberType.Personal:
                    mbll = new PersonMemberInfo();
                    break;
                case MemberType.Famly:
                    mbll = new FamlyMemberInfo();
                    break;
                case MemberType.Company:
                    mbll = new CompanyMemberInfo();
                    break;
                case MemberType.School:
                    mbll = new SchoolMemberInfo();
                    break;

            }
            if (mbll != null)
            {
                model = mbll.GetFullUserInfo(userId);
            }
            return model;
        }

        public static MemberInfo GetFullInfo(string userId)
        {
            MemberInfo minfo = GetBaseInfo(userId);
            return GetFullInfo(userId, minfo.UserType);
        }

        public void Save()
        {
            if (!Exists(UserId, UserEmail))
            {
                Register();
                SaveExtInfo();
            }
            else
            {
                SaveBaseInfo();
                SaveExtInfo();
            }
        }

        public virtual MemberInfo GetFullUserInfo(string userId)
        {
            return null;
        }

        public virtual void SaveExtInfo()
        {
        }

        public bool Register()
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_ADD");
            string md5pass = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
            string key = System.Configuration.ConfigurationManager.AppSettings["usersec"];
            string secpass = NoName.Utility.TripleDesUtil.EncryptString(Password,key);

            db.AddInParameter(dbCommand, "userId", DbType.String, UserId);
            db.AddInParameter(dbCommand, "userName", DbType.AnsiString, UserName);
            db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, UserEmail);
            db.AddInParameter(dbCommand, "Password", DbType.AnsiString, md5pass);
            db.AddInParameter(dbCommand, "AllScore", DbType.Int32, AllScore);
            db.AddInParameter(dbCommand, "CurScore", DbType.Int32, CurScore);
            db.AddInParameter(dbCommand, "UserType", DbType.Byte, (int)UserType);
            db.AddInParameter(dbCommand, "status", DbType.Byte, (int)Status);
            db.AddInParameter(dbCommand,"@LoginIp",DbType.String,LoginIp);
            db.AddInParameter(dbCommand, "@UserLevel", DbType.Int32, (int)UserLevel);
            db.AddInParameter(dbCommand, "SecPassword", DbType.String, secpass);

            db.AddParameter(dbCommand, "returnvalue", DbType.Int32, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);
            db.ExecuteNonQuery(dbCommand);
            int retval = (int)db.GetParameterValue(dbCommand, "returnvalue");
            return retval == 0;
        }

        public bool SaveBaseInfo()
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "update umMember set username=@userName,useremail=@UserEmail,modifytime=getdate() from umMember where userId=@userId";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, UserId);
            db.AddInParameter(dbCommand, "userName", DbType.String, UserName);
            db.AddInParameter(dbCommand, "useremail", DbType.String, UserEmail);
            int result = db.ExecuteNonQuery(dbCommand);
            return result == 1;
        }

        public static bool Login(string userId, string password,string loginIp)
        {
            string sql = "UP_umMember_Login";
            string md5pass = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "@userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "@password", DbType.String, md5pass);
            db.AddInParameter(dbCommand, "@loginIp", DbType.String, loginIp);
            db.AddParameter(dbCommand, "@returnvalue", DbType.Int32, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);
            db.ExecuteNonQuery(dbCommand);
            int retval = (int)db.GetParameterValue(dbCommand, "returnvalue");
            return retval == 0;
       
        }

        public static bool ChangePassword(string userId, string oldpass, string newpass)
        {
            string md5old = FormsAuthentication.HashPasswordForStoringInConfigFile(oldpass, "MD5"); 
            string md5new = FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
            string key = System.Configuration.ConfigurationManager.AppSettings["usersec"];
            string secpass = NoName.Utility.TripleDesUtil.EncryptString(newpass, key);
            string sql = "update umMember set password=@newpass,modifytime=getdate(),secpassword=@secpassword from umMember where userId=@userId and password=@oldpass";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "oldpass", DbType.String, md5old);
            db.AddInParameter(dbCommand, "newpass", DbType.String, md5new);
            db.AddInParameter(dbCommand, "secpassword", DbType.String, secpass);
            int result = db.ExecuteNonQuery(dbCommand);
            return (result == 1);
        }

        public static bool ResetPassword(string userId, string newpass)
        {
            string md5str = FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
            string key = System.Configuration.ConfigurationManager.AppSettings["usersec"];
            string secpass = NoName.Utility.TripleDesUtil.EncryptString(newpass, key);


            string sql = "update umMember set password=@newpass,secpassword=@secpassword,modifytime=getdate() from umMember where userId=@userId";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "newpass", DbType.String, md5str);
            db.AddInParameter(dbCommand, "secpassword", DbType.String, secpass);
            int result = db.ExecuteNonQuery(dbCommand);
            return result == 1;
        }

        public static string GetPassword(string userId, string email)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["usersec"];
            string sql = "select secpassword from umMember where userId=@userId and  userEmail=@userEmail";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "userEmail", DbType.String, email);
            object obj = db.ExecuteScalar(dbCommand);
            string result = String.Empty;
            if (obj != DBNull.Value && obj.ToString() != "")
            {
                result = NoName.Utility.TripleDesUtil.DecryptString(obj.ToString(), key);
            }
            else
            {
                throw new ShopException("获取密码失败");
            }
            return result;
        }

        public static bool SetStatus(string userId, MemberStatus status)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "update umMember set status=@status,modifytime=getdate() from umMember where userId=@userId";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "status", DbType.Int32, (int)status);
            int result = db.ExecuteNonQuery(dbCommand);
            return result == 1;
        }


        public static bool UserIdExists(string userId)
        {
            string sql = "select count(*) from umMember where userId=@userId";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            int result = (int)db.ExecuteScalar(dbCommand);
            return (result == 1);
        }

        public static bool UserEmailExists(string userEmail)
        {
            string sql = "select count(*) from umMember where userEmail=@userEmail";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userEmail", DbType.String, userEmail);
            int result = (int)db.ExecuteScalar(dbCommand);
            return (result == 1);
        }

        public static bool Exists(string userId,string userEmail)
        {
            string sql = "select count(*) from umMember where userId=@userId or userEmail=@userEmail";
            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "userEmail", DbType.String, userEmail);
            int result = (int)db.ExecuteScalar(dbCommand);
            return (result == 1);
        }

        public static bool ExistsOrderProduct(string UserID,int ProductID)
        {
            string sql = @" select top 1 o.orderid from spOrder o
                                inner join sporderitem oi on o.orderid=oi.orderid
                            where userid=@userid and oi.productid=@productid and o.paystatus=1";

            Database db = NoName.NetShop.Common.CommDataAccess.DbReader;

            DbCommand Command = db.GetSqlStringCommand(sql);

            db.AddInParameter(Command, "@userid", DbType.String, UserID);
            db.AddInParameter(Command, "@productid", DbType.Int32, ProductID);

            return db.ExecuteDataSet(Command).Tables[0].Rows.Count > 0;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        private MemberInfo ReaderBind(IDataReader dataReader)
        {
            MemberInfo model = new MemberInfo();
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
            ojb = dataReader["userLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserLevel = (UserLevel)(Convert.ToInt32(ojb));
            }
            model.SecPassword = dataReader["SecPassword"].ToString();
           
            return model;
        }

        /// <summary>
        /// 申请修改会员类型
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        public static void ChangeUserType(string userId, MemberType userType)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "update ummember set newusertype=@usertype,ChangeType=2 where userid=@userId";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "usertype", DbType.Int32, (int)userType);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 申请修改商户级别
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userLevel"></param>
        public static void ChangeUserLevel(string userId, UserLevel userLevel)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "update ummember set newuserlevel=@userLevel,ChangeType=1 where userid=@userId";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.AddInParameter(dbCommand, "userLevel", DbType.Int32, (int)userLevel);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 确认用户修改
        /// </summary>
        /// <param name="userId"></param>
        public static void ConfirmUserChange(string userId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "up_umMember_ConfirmChange";
            DbCommand dbCommand = db.GetStoredProcCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 拒绝用户申请
        /// </summary>
        /// <param name="userId"></param>
        public static void RejectUserChange(string userId)
        {
            Database db = NoName.NetShop.Common.CommDataAccess.DbWriter;
            string sql = "update ummember set ChangeType=0 where userid=@userId";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "userId", DbType.String, userId);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
