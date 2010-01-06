using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;

namespace NoName.NetShop.Comment
{
    [Serializable]
    public class TopicModel
    {
        public TopicModel()
        { }
        #region Model
        private int _topicid;
        private string _userid;
        private ContentType _contenttype;
        private int _contentid;
        private string _title;
        private string _content;
        private DateTime _inserttime;
        private DateTime? _lastreplytime;
        private int _lastreplyid;
        private int _replynum;
        private bool _status;
        /// <summary>
        /// 
        /// </summary>
        public int TopicId
        {
            set { _topicid = value; }
            get { return _topicid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ContentType ContentType
        {
            set { _contenttype = value; }
            get { return _contenttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContentId
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastReplyTime
        {
            set { _lastreplytime = value; }
            get { return _lastreplytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LastReplyId
        {
            set { _lastreplyid = value; }
            get { return _lastreplyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReplyNum
        {
            set { _replynum = value; }
            get { return _replynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model
    }
}
