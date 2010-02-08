using System;
using System.Data;
using System.Collections.Generic;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// ҵ���߼���MessageModelBll ��ժҪ˵����
	/// </summary>
	public class MessageBll
	{
		private readonly MessageDal dal=new MessageDal();
		public MessageBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
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
            model.UserType = 0; // Ĭ��Ϊǰ̨�û�
            dal.Add(model);
        }

        public void Add(string content, string subject, string userId, string sender,int userType)
        {
            MessageModel model = new MessageModel();
            model.MsgId = 0;
            model.MsgType = 0;
            model.UserId = userId;
            model.SenderId = sender;
            model.Subject = subject;
            model.Content = content;
            model.UserType = userType; // Ĭ��Ϊǰ̨�û�
            dal.Add(model);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string userId,int msgId)
		{
			dal.Delete(userId,msgId,0);
		}
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string userId, int msgId,int userType)
        {
            dal.Delete(userId, msgId, userType);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        public void Delete(string userId, string msgIds)
        {
            dal.Delete(userId, msgIds, 0);
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        public void Delete(string userId, string msgIds,int usertype)
        {
            dal.Delete(userId, msgIds, usertype);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public MessageModel GetModel(int msgId)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel(msgId);
		}

        public void SetIsReaded(int msgId)
        {
            dal.SetIsReaded(msgId);
        }

		#endregion  ��Ա����
	}
}

