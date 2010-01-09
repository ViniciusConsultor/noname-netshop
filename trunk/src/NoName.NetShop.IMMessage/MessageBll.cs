using System;
using System.Data;
using System.Collections.Generic;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// 业务逻辑类MessageModelBll 的摘要说明。
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

        public void Add(string content,string subject,string userId,string sender)
        {
            MessageModel model = new MessageModel();
            model.MsgId = 0;
            model.MsgType = 0;
            model.UserId = userId;
            model.SenderId = sender;
            model.Subject = subject;
            model.Content = content;
            dal.Add(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string userId,int msgId)
		{
			dal.Delete(userId,msgId);
		}

        /// <summary>
        /// 删除多条数据
        /// </summary>
        public void Delete(string userId, string msgIds)
        {
            dal.Delete(userId, msgIds);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MessageModel GetModel(int msgId)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(msgId);
		}

        public void SetIsReaded(string userId, int msgId)
        {
            dal.SetIsReaded(userId, msgId);
        }

		#endregion  成员方法
	}
}

