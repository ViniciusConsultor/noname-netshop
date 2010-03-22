using System;
using System.Text;
using System.Web.Script.Serialization;
namespace NoName.NetShop.IMMessage
{
	/// <summary>
	/// 实体类MessageModel 。(属性说明自动提取数据库字段的描述信息)
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
        /// 过期时间（针对组公告和全体公告有效）
        /// </summary>
        public DateTime? ExpireTime { get; set; }

        /// <summary>
        /// 用户类型：0 前台用户 1 后台用户
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
		/// 0 个人用户通知 1 全体用户通知（对应的userid暂定为alluser） 2 用户组通知：对应的用户组为用户角色名
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

