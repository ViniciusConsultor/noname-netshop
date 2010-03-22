using System;
using System.Text;
using System.Web.Script.Serialization;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// ʵ����MessageModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class MessageModel
	{
        public MessageModel()
		{}
		#region Model
		private string _userid;
		private int _msgid;
		private int _msgtype;
		private string _subject;
		private string _content;
		private string _senderid;
		private DateTime _inserttime;
		private DateTime? _readtime;
		private bool _status;

        /// <summary>
        /// ����ʱ�䣨����鹫���ȫ�幫����Ч��
        /// </summary>
        public DateTime? ExpireTime { get; set; }

        /// <summary>
        /// �û����ͣ�0 ǰ̨�û� 1 ��̨�û�
        /// </summary>
        public int UserType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MsgId
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 0 �����û�֪ͨ 1 ȫ���û�֪ͨ����Ӧ��userid�ݶ�Ϊalluser�� 2 �û���֪ͨ����Ӧ���û���Ϊ�û���ɫ��
		/// </summary>
		public int MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SenderId
		{
			set{ _senderid=value;}
			get{return _senderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Status
		{
			set{ _status=value;}
			get{return _status;}
		}

        public string ToJson()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(this);
        }    
		#endregion Model


	}
}

