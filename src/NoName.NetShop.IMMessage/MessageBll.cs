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
            dal.Add(model);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string userId,int msgId)
		{
			dal.Delete(userId,msgId);
		}

        /// <summary>
        /// ɾ����������
        /// </summary>
        public void Delete(string userId, string msgIds)
        {
            dal.Delete(userId, msgIds);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public MessageModel GetModel(int msgId)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel(msgId);
		}

        public void SetIsReaded(string userId, int msgId)
        {
            dal.SetIsReaded(userId, msgId);
        }

		#endregion  ��Ա����
	}
}

