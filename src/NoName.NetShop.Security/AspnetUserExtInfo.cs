using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace NoName.Security
{
    public class AspnetUserExtInfo
    {
        #region Model
        private MembershipUser memberUser;

        private string _username;
        private string _truename;
        private string _idcard;
        private string _telephone;
        private string _mobile;
        private string _qq;
        private string _msn;
        private string _email;

        public MembershipUser MemberUser
        {
            get
            {
                return memberUser;
            }
        }

        public bool IsLocked
        {
            get { return memberUser.IsLockedOut; }
        }

        public bool IsApproved
        {
            get { return memberUser.IsApproved; }
        }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName
        {
            set { 
                _username = value;
                memberUser = Membership.GetUser(_username);
            }
            get { return _username; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string TelePhone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        #endregion Model
    }
}
