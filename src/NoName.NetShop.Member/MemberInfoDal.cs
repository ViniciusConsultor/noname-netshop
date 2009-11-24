using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Member
{
    class MemberInfoDal
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(NoName.NetShop.Member.Model.MemberModel model)
        {
            Database db = NoName.NetShop.Common.DBFacroty.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_umMember_ADD");
            db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
            db.AddInParameter(dbCommand, "UserEmail", DbType.AnsiString, model.UserEmail);
            db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
            db.AddInParameter(dbCommand, "NickName", DbType.AnsiString, model.NickName);
            db.AddInParameter(dbCommand, "AllScore", DbType.Int32, model.AllScore);
            db.AddInParameter(dbCommand, "CurScore", DbType.Int32, model.CurScore);
            db.AddInParameter(dbCommand, "UserType", DbType.Byte, model.UserType);
            db.AddInParameter(dbCommand, "status", DbType.Byte, model.Status);
            db.ExecuteNonQuery(dbCommand);

        }


    }
}
