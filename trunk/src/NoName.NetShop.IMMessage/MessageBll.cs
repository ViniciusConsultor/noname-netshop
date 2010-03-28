using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// ҵ���߼���MessageModelBll ��ժҪ˵����
    /// վ����Ŀǰ��֧�ֻظ����ܣ�Ŀǰ��ʵ��Ϊ֪ͨ���ܡ�
    /// ������Ϣ���ͷ�Ϊ���ַ�ʽ��
    /// �����û���Ϣ
    /// �û�����Ϣ��ǰ̨�û����飨�ȼ������ͣ�Ŀǰ��ȷ��������̨�û��飨��ɫ��
    /// ȫ���û���Ϣ����Ϣ������alluser
    /// �û����ͣ�ǰ̨�û�����̨�û�
    /// �漰�ؼ��ֶΣ������ˡ���Ϣ���͡��û�����
    /// ���嶨�壺
    /// �û����� UserType 0 ǰ̨�û� 1 ��̨�û�
    /// ��Ϣ���� MsgType 0 �����û���Ϣ 1 ȫ���û���Ϣ 2 �û�����Ϣ
    /// ���� �����û���Ϣ�������Ķ�ʱ�� ȫ����Ϣ���û�����Ϣ��û���Ķ�ʱ��
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

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int msgId)
        {
            dal.Delete(msgId);
        }

    	/// <summary>
		/// ɾ��ĳ���û���һ������
		/// </summary>
		public void Delete(string userId,int usertype,int msgId)
		{
			dal.Delete(userId,usertype,msgId);
		}

        /// <summary>
        /// ɾ����������
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
		/// �õ�һ������ʵ��
		/// </summary>
		public MessageModel GetModel(int msgId)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel(msgId);
		}

        /// <summary>
        /// ��ø����û�����Ϣ�б�
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
        /// ������û���Ϣ
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userType"></param>
        /// <param name="isValidMsg"></param>
        /// <returns></returns>
        public List<MessageModel> GetGroupMessageList(string roleId, int userType,bool isValidMsg)
        {
            string where = "msgtype=2 and userId='" + roleId + "' and usertype=" + userType;
            if (isValidMsg)
                where += " and expireTime>getdate()";
            return dal.GetList(where);
        }

        /// <summary>
        /// ��ù�����Ϣ
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="isValidMsg"></param>
        /// <returns></returns>
        public List<MessageModel> GetNoticeList(int userType,bool isValidMsg)
        {
            string where = "msgtype=1 and userId='alluser' and usertype=" + userType;
            if (isValidMsg)
                where += " and expireTime>getdate()";
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

		#endregion  ��Ա����
	}
}

