using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// 业务逻辑类MessageModelBll 的摘要说明。
    /// 站内信目前不支持回复功能，目前仅实现为通知功能。
    /// 对于消息类型分为三种方式：
    /// 单个用户消息
    /// 用户组消息：前台用户分组（等级？类型？目前不确定），后台用户组（角色）
    /// 全体用户消息：消息接收者alluser
    /// 用户类型：前台用户，后台用户
    /// 涉及关键字段：收信人、消息类型、用户类型
    /// 具体定义：
    /// 用户类型 UserType 0 前台用户 1 后台用户
    /// 消息类型 MsgType 0 单个用户消息 1 全体用户消息 2 用户组消息
    /// 其中 单个用户消息可以有阅读时间 全体消息和用户组消息，没有阅读时间
	/// </summary>
	public class MessageBll
	{
		private readonly MessageDal dal=new MessageDal();
		public MessageBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add (MessageModel model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int msgId)
        {
            dal.Delete(msgId);
        }

    	/// <summary>
		/// 删除某个用户的一条数据
		/// </summary>
		public void Delete(string userId,int usertype,int msgId)
		{
			dal.Delete(userId,usertype,msgId);
		}

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Delete(string userId,int usertype, string msgIds)
        {
            dal.Delete(userId,usertype, msgIds);
        }

        public void Delete(string msgIds)
        {
            dal.Delete(msgIds);
        }

    	/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MessageModel GetModel(int msgId)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(msgId);
		}

        /// <summary>
        /// 获得个人用户的消息列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public List<MessageModel> GetUserMessageList(string userId,int userType,bool isValidMsg)
        {
            string where = "msgtype=0 and userId='" + userId + "' and usertype=" + userType;
            if (isValidMsg)
                where += " and status=0";
            return dal.GetList(where);
        }
        /// <summary>
        /// 获得组用户消息
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userType"></param>
        /// <param name="isValidMsg"></param>
        /// <returns></returns>
        public List<MessageModel> GetGroupMessageList(string roleId, int userType,bool isValidMsg)
        {
            string where = "msgtype=2 and userId='" + roleId + "' and usertype=" + userType;
            if (isValidMsg)
                where += " and (expiretime is null or expireTime>getdate())";
            return dal.GetList(where);
        }

        /// <summary>
        /// 获得公告消息
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="isValidMsg"></param>
        /// <returns></returns>
        public List<MessageModel> GetNoticeList(int userType,bool isValidMsg)
        {
            string where = "msgtype=1 and userId='alluser' and usertype=" + userType;
            if (isValidMsg)
                where += " and (expiretime is null or expireTime>getdate())";
            return dal.GetList(where);
        }

        public List<MessageModel> GetAllList(string userId,string[] roleIds, int userType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("usertype=" + userType + " and (");
            sb.Append("(msgtype=1 and userId='alluser' and (expireTime is null or expireTime>getdate()))");
            if (!String.IsNullOrEmpty(userId))
                sb.Append(" or (msgtype=0 and status=0 and userId='" + userId + "')");

            if (roleIds!=null && roleIds.Length > 0)
            {
                sb.Append(" or (msgtype=2 and userId in ('" + String.Join("','",roleIds) + "') and (expiretime is null or expireTime>getdate()))");
            }
            sb.Append(")");
            return dal.GetList(sb.ToString());
        }


        public void SetIsReaded(int msgId)
        {
            dal.SetIsReaded(msgId);
        }

		#endregion  成员方法
	}
}

